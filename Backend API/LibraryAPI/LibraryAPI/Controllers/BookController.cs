using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.IRepository;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<BookDTO>>> GetBooks()
        {
            try
            {
                var books = await _unitOfWork.Books.GetAll();
                var results = _mapper.Map<IList<BookDTO>>(books);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetBooks)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}", Name = "GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            try
            {
                var book = await _unitOfWork.Books.Get(q=>q.BookId == id);
                var result = _mapper.Map<BookDTO>(book);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetBooks)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize]
        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post Attempt in {nameof(CreateBook)}");
                return BadRequest(ModelState);
            }

            try
            {
                var book = _mapper.Map<Book>(bookDTO);
                await _unitOfWork.Books.Insert(book);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetBook", new {id = book.BookId }, book);
            }
            catch(Exception ex)
            { 
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateBook)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDTO bookDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update Attempt in {nameof(UpdateBook)}");
                return BadRequest(ModelState);
            }

            try
            {
                var book = await _unitOfWork.Books.Get(q => q.BookId == id);
                if(book == null)
                {
                    _logger.LogError($"Invalid Update Attempt in {nameof(UpdateBook)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(bookDTO, book);
                _unitOfWork.Books.Update(book);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateBook)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if(id < 1)
            {
                _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteBook)}");
                return BadRequest();
            }

            try
            {
                var book = await _unitOfWork.Books.Get(q => q.BookId==id);
                if(book == null)
                {
                    _logger.LogError($"Invalid Delete Attempt in {nameof(DeleteBook)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Books.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteBook)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        //string UploadFile(CreateBookDTO bookDTO)
        //{
        //    string uniqueFileName = null;

        //    if(bookDTO.CoverPicture != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources", "Images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + bookDTO.CoverPicture.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            bookDTO.CoverPicture.CopyTo(fileStream);
        //        }
        //    }

        //    return uniqueFileName;
        //}
    }
}
