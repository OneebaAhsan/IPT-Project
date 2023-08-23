using LibraryAPI.Data;

namespace LibraryAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Book> Books { get; }

        Task Save();
    }
}
