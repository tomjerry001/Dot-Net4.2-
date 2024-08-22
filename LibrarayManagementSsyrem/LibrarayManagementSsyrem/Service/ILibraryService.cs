using LibrarayManagementSsyrem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarayManagementSsyrem.Service
{
    public interface ILibraryService
    {
        //Add Book
        Task AddBookAsync(Book book);
        //Update Book
        Task UpdateBookAsync(Book book);
        //Delete Book
        Task DeleteBookAsync(int bookCode);
        //Get Book by code
        Task<Book> GetBookByCodeAsync(int bookCode);
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
