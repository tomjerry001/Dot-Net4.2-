using Camp4MachineTest.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem
{
    public class LibraryManagement
    {
        private readonly ILibraryService _libraryService;

        public LibraryManagement(ILibraryService libraryService) // Constructor injection
        {
            _libraryService = libraryService;
        }

        public static void Main(string[] args)  // Main entry point of the application
        {
            bool exit = false;
            var libraryApp = new LibraryManagement(new LibraryServiceImpl(new LibraryRepositoryImpl())); // Create an instance of LibraryManagement

            while (true)
            {
                Console.WriteLine("                 >>>>>>>>>>>>> Library Management System >>>>>>>>>>>>>>");
                Console.WriteLine("                 -------------------------------------------------------");
                Console.WriteLine("                 -1. Add Book                                          -");
                Console.WriteLine("                 -2. Edit Book                                         -");
                Console.WriteLine("                 -3. Remove Book                                       -");
                Console.WriteLine("                 -4. Search By Author                                  -");
                Console.WriteLine("                 -5. Search By Title                                   -");
                Console.WriteLine("                 -6. List All Books                                    -");
                Console.WriteLine("                 -7. Exit                                              -");
                Console.WriteLine("                 -------------------------------------------------------");

                Console.WriteLine("Enter your choice");

                // Read user input and parse it as an integer choice
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid Choice. Please try again."); // Handle invalid choices
                    continue;
                }

                switch (choice) // Execute actions based on the user's choice
                {
                    case 1:
                        libraryApp._libraryService.AddBook(); // Call the method to add a new book
                        break;
                    case 2:
                        Console.WriteLine("Enter ISBN of the book to update:");
                        string isbnToUpdate = Console.ReadLine(); // Enter the ISBN for the book to update
                        libraryApp._libraryService.EditBook(isbnToUpdate); // Call the method to edit the book
                        break;
                    case 3:
                        Console.WriteLine("Enter ISBN of the book to remove:");
                        string isbnToRemove = Console.ReadLine(); // Enter the ISBN number to remove the Book
                        libraryApp._libraryService.RemoveBook(isbnToRemove); // Call the method to remove the book
                        break;
                    case 4:
                        Console.WriteLine("Enter Author name to search:");
                        string authorToSearch = Console.ReadLine(); // Enter the author's name to search
                        libraryApp._libraryService.SearchByAuthor(authorToSearch); // Call the method to search books by author
                        break;
                    case 5:
                        Console.WriteLine("Enter Title to search:");
                        string titleToSearch = Console.ReadLine(); // Enter the title to search
                        libraryApp._libraryService.SearchByTitle(titleToSearch); // Call the method to search books by title
                        break;
                    case 6:
                        libraryApp._libraryService.ListAllBooks(); // Call the method to list all books
                        break;
                    case 7:
                        return; // Exit the application
                }
            }
        }
    }
}