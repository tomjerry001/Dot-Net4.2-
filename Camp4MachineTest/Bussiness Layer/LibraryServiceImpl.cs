using Camp4MachineTest.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem
{
    public class LibraryServiceImpl : ILibraryService
    {
        private Dictionary<string, Book> books;
        private readonly ILibraryRepository libraryRepository;

        public LibraryServiceImpl(ILibraryRepository _libraryRepository)
        {
            libraryRepository = _libraryRepository;
            books = libraryRepository.LoadBooks() ?? new Dictionary<string, Book>();
        }

        public void AddBook()
        {
            try
            {
                Console.WriteLine("Enter Book details:");

                string isbn;
                while (true)
                {
                    Console.WriteLine("ISBN:");
                    isbn = Console.ReadLine();
                    if (Regex.IsMatch(isbn, @"^\d{13}$"))
                    {
                        if (!books.ContainsKey(isbn))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A book with this ISBN already exists.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ISBN. It should be 13 digits.");
                    }
                }

                string title;
                while (true)
                {
                    Console.WriteLine("Title:");
                    title = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Title cannot be empty.");
                    }
                }

                string author;
                while (true)
                {
                    Console.WriteLine("Author:");
                    author = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(author))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Author cannot be empty.");
                    }
                }

                DateTime publishedDate;
                while (true)
                {
                    Console.WriteLine("Published Date (YYYY-MM-DD):");
                    if (DateTime.TryParse(Console.ReadLine(), out publishedDate))
                    {
                        if (publishedDate <= DateTime.Now)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Published date cannot be in the future.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
                    }
                }

                books.Add(isbn, new Book
                {
                    ISBN = isbn,
                    Title = title,
                    Author = author,
                    PublishedDate = publishedDate
                });

                libraryRepository.SaveBooks(books);

                Console.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void EditBook(string isbn)
        {
            try
            {
                if (books.TryGetValue(isbn, out Book book))
                {
                    Console.WriteLine("Select the detail to update:");
                    Console.WriteLine("1. Title");
                    Console.WriteLine("2. Author");
                    Console.WriteLine("3. Published Date");
                    Console.WriteLine("4. Exit");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                string newTitle;
                                while (true)
                                {
                                    Console.WriteLine("Enter new title:");
                                    newTitle = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(newTitle))
                                    {
                                        book.Title = newTitle;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Title cannot be empty.");
                                    }
                                }
                                break;
                            case 2:
                                string newAuthor;
                                while (true)
                                {
                                    Console.WriteLine("Enter new author:");
                                    newAuthor = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(newAuthor))
                                    {
                                        book.Author = newAuthor;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Author cannot be empty.");
                                    }
                                }
                                break;
                            case 3:
                                DateTime newPublishedDate;
                                while (true)
                                {
                                    Console.WriteLine("Enter new published date (YYYY-MM-DD):");
                                    if (DateTime.TryParse(Console.ReadLine(), out newPublishedDate))
                                    {
                                        if (newPublishedDate <= DateTime.Now)
                                        {
                                            book.PublishedDate = newPublishedDate;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Published date cannot be in the future.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.");
                                    }
                                }
                                break;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                                break;
                        }

                        libraryRepository.SaveBooks(books);
                        Console.WriteLine("Book details updated.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void RemoveBook(string isbn)
        {
            try
            {
                if (books.Remove(isbn))
                {
                    libraryRepository.SaveBooks(books);
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void SearchByAuthor(string author)
        {
            try
            {
                var foundBooks = books.Values.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
                if (foundBooks.Any())
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("| ISBN        | Title        | Author       | Published Date    |");
                    Console.WriteLine("-----------------------------------------------------------------");
                    foreach (var book in foundBooks)
                    {
                        Console.WriteLine($"| {book.ISBN,-12} | {book.Title,-12} | {book.Author,-12} | {book.PublishedDate:yyyy-MM-dd} |");
                    }
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("No books found for this author.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void SearchByTitle(string title)
        {
            try
            {
                var foundBooks = books.Values.Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
                if (foundBooks.Any())
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("| ISBN        | Title        | Author       | Published Date    |");
                    Console.WriteLine("-----------------------------------------------------------------");
                    foreach (var book in foundBooks)
                    {
                        Console.WriteLine($"| {book.ISBN,-12} | {book.Title,-12} | {book.Author,-12} | {book.PublishedDate:yyyy-MM-dd} |");
                    }
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("No books found with this title.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void ListAllBooks()
        {
            try
            {
                if (books.Count > 0)
                {
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("| ISBN        | Title        | Author       | Published Date    |");
                    Console.WriteLine("-----------------------------------------------------------------");
                    foreach (var book in books.Values)
                    {
                        Console.WriteLine($"| {book.ISBN,-12} | {book.Title,-12} | {book.Author,-12} | {book.PublishedDate:yyyy-MM-dd} |");
                    }
                    Console.WriteLine("-----------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("No books available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
