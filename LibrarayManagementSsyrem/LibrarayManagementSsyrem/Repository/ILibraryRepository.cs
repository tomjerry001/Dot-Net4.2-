using LibrarayManagementSsyrem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarayManagementSsyrem.Repository
{
    public interface ILibraryRepository
    {
        //Add Book
        Task AddBookAsync(Book book);
        //Update Book
        Task UpdateBookAsync(Book book);
        //Delete Book
        Task DeleteBookAsync(int bookCode);
        
        Task<Book> GetBookByCodeAsync(int bookCode);
        //Get all Books
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
