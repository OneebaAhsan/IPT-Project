using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Diagnostics;

namespace LibraryAPI.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthManager> _logger;
        private ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration, ILogger<AuthManager> logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, _user.Email)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = jwtSettings.GetSection("key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("Lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            return token;
        }

        public async Task<bool> ValidateUser(LoginUserDTO userDTO)
        {
            _user = await _userManager.FindByEmailAsync(userDTO.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userDTO.Password));
        }
    }
}
