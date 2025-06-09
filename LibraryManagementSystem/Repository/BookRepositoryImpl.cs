using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem.Repository
{
    public class BookRepositoryImpl : IBookRepository
    {
        private readonly string constring = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        public async Task AddBookAsync(Book book)
        {
            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "INSERT INTO Books (BookCode, Title, Author, Genre, Price) " +
                               "VALUES (@BookCode, @Title, @Author, @Genre, @Price)";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@BookCode", book.BookCode);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Price", book.Price);

                int rows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} book(s) added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding book to database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "UPDATE Books SET Title=@Title, Author=@Author, Genre=@Genre, Price=@Price WHERE BookCode=@BookCode";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@BookCode", book.BookCode);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Price", book.Price);

                int rows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} book(s) updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating book in database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteBookAsync(string bookCode)
        {
            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "DELETE FROM Books WHERE BookCode = @BookCode";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@BookCode", bookCode);

                int rows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} book(s) deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting book from database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = new List<Book>();

            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "SELECT BookCode, Title, Author, Genre, Price FROM Books";

                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    books.Add(new Book(
                        reader["BookCode"].ToString(),
                        reader["Title"].ToString(),
                        reader["Author"].ToString(),
                        reader["Genre"].ToString(),
                        Convert.ToDecimal(reader["Price"])
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading books from database");
                Console.WriteLine(ex.Message);
            }

            return books;
        }
    }
}
