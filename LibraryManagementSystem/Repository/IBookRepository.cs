using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Repository
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(string bookCode);
        Task<List<Book>> GetAllBooksAsync();
    }
}
