using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, CreateBookDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
