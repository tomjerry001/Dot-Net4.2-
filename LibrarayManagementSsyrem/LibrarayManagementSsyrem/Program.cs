using LibrarayManagementSsyrem.Model;
using LibrarayManagementSsyrem.Repository;
using LibrarayManagementSsyrem.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarayManagementSsyrem
{
    public class LibraryApp
    {
        static async Task Main(string[] args)
        {
            // create an instance of service
            ILibraryService libraryService = new LibraryServiceImpli(new LibraryRepositoryImpli());

            while (true)
            {
                //menu
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Get Book by Book Code");
                Console.WriteLine("4. Get All Books");
                Console.WriteLine("5. Delete Book");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add book method
                        await AddBook(libraryService);
                        break;
                    case "2":
                        // update book method
                        await UpdateBook(libraryService);
                        break;
                    case "3":
                        // search by code
                        await GetBookByCode(libraryService);
                        break;
                    case "4":
                        // list all
                        await GetAllBooks(libraryService);
                        break;
                    case "5":
                        // delete
                        await DeleteBook(libraryService);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        // Add Book
        private static async Task AddBook(ILibraryService libraryService)
        {
            var book = new Book();

            Console.WriteLine("Enter Book Title:");
            book.Title = Console.ReadLine();

            Console.WriteLine("Enter Book Author:");
            book.Author = Console.ReadLine();

            Console.WriteLine("Enter Book Genre:");
            book.Genre = Console.ReadLine();

            Console.WriteLine("Enter Book Price:");
            book.Price = Convert.ToInt32(Console.ReadLine());

            await libraryService.AddBookAsync(book);
            Console.WriteLine("Book added successfully.");
        }

        // Update book
        private static async Task UpdateBook(ILibraryService libraryService)
        {
            var book = new Book();

            Console.WriteLine("Enter Book Code:");
            book.BookCode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter New Book Title:");
            book.Title = Console.ReadLine();

            Console.WriteLine("Enter New Book Author:");
            book.Author = Console.ReadLine();

            Console.WriteLine("Enter New Book Genre:");
            book.Genre = Console.ReadLine();

            Console.WriteLine("Enter New Book Price:");
            book.Price = Convert.ToInt32(Console.ReadLine());

            await libraryService.UpdateBookAsync(book);
            Console.WriteLine("Book updated successfully.");
        }

        // Serch by book code
        private static async Task GetBookByCode(ILibraryService libraryService)
        {
            Console.WriteLine("Enter Book Code:");
            int bookCode = Convert.ToInt32(Console.ReadLine());

            var book = await libraryService.GetBookByCodeAsync(bookCode);
            if (book != null)
            {
                Console.WriteLine($"Book Code: {book.BookCode}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Price: {book.Price}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        //Get all books
        private static async Task GetAllBooks(ILibraryService libraryService)
        {
            var books = await libraryService.GetAllBooksAsync();
            foreach (var book in books)
            {
                Console.WriteLine($"Book Code: {book.BookCode}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Price: {book.Price}");
            }
        }

        //Delete book
        private static async Task DeleteBook(ILibraryService libraryService)
        {
            Console.WriteLine("Enter Book Code:");
            int bookCode = Convert.ToInt32(Console.ReadLine());

            await libraryService.DeleteBookAsync(bookCode);
            Console.WriteLine("Book deleted successfully.");
        }
    }
}
