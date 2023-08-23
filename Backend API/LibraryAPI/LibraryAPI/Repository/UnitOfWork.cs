using LibraryAPI.Data;
using LibraryAPI.IRepository;

namespace LibraryAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Book> _books;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Book> Books => _books ??= new GenericRepository<Book>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
