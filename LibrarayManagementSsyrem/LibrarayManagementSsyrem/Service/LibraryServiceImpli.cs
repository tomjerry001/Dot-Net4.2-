using LibrarayManagementSsyrem.Model;
using LibrarayManagementSsyrem.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarayManagementSsyrem.Service
{
    public class LibraryServiceImpli : ILibraryService
    {
        // field
        private readonly ILibraryRepository _libraryRepository;

        // constructor injection
        public LibraryServiceImpli(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        //Add Book
        public async Task AddBookAsync(Book book)
        {
            await _libraryRepository.AddBookAsync(book);
        }

        //Update Book
        public async Task UpdateBookAsync(Book book)
        {
            await _libraryRepository.UpdateBookAsync(book);
        }

        //Delete Book
        public async Task DeleteBookAsync(int bookCode)
        {
            await _libraryRepository.DeleteBookAsync(bookCode);
        }

        //Get Book by code
        public async Task<Book> GetBookByCodeAsync(int bookCode)
        {
            return await _libraryRepository.GetBookByCodeAsync(bookCode);
        }

        //
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _libraryRepository.GetAllBooksAsync();
        }
    }
}
