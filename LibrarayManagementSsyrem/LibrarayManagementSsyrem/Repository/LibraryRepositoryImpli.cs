using LibrarayManagementSsyrem.Model;
using SqlServerConnectionLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LibrarayManagementSsyrem.Repository
{
    public class LibraryRepositoryImpli : ILibraryRepository
    {
        string winconnString = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        //Get Add Book 
        public async Task AddBookAsync(Book book)
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                string query = "INSERT INTO Books(Title, Author, Genere, Price) VALUES(@BkTitle, @BkAuthor, @BkGenre, @BkPrice)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@BkTitle", book.Title);
                    command.Parameters.AddWithValue("@BkAuthor", book.Author);
                    command.Parameters.AddWithValue("@BkGenre", book.Genre);
                    command.Parameters.AddWithValue("@BkPrice", book.Price);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        //Update Book
        public async Task UpdateBookAsync(Book book)
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                string query = "UPDATE Books SET Title = @BkTitle, Author = @BkAuthor, Genere = @BkGenre, Price = @BkPrice WHERE BookCode = @BkCode";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@BkCode", book.BookCode);
                    command.Parameters.AddWithValue("@BkTitle", book.Title);
                    command.Parameters.AddWithValue("@BkAuthor", book.Author);
                    command.Parameters.AddWithValue("@BkGenre", book.Genre);
                    command.Parameters.AddWithValue("@BkPrice", book.Price);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        //Delete Book
        public async Task DeleteBookAsync(int bookCode)
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                string query = "DELETE FROM Books WHERE BookCode = @BkCode";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@BkCode", bookCode);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        //Get Book by Code
        public async Task<Book> GetBookByCodeAsync(int bookCode)
        {
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                string query = "SELECT BookCode, Title, Author, Genere, Price FROM Books WHERE BookCode = @BkCode";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@BkCode", bookCode);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Book
                            {
                                BookCode = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Author = reader.GetString(2),
                                Genre = reader.GetString(3),
                                Price = reader.GetInt32(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        //Get all Books 
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = new List<Book>();
            using (SqlConnection conn = SqlServerConnectionManager.OpenConnection(winconnString))
            {
                string query = "SELECT BookCode, Title, Author, Genere, Price FROM Books";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            books.Add(new Book
                            {
                                BookCode = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Author = reader.GetString(2),
                                Genre = reader.GetString(3),
                                Price = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return books;
        }
    }
}
