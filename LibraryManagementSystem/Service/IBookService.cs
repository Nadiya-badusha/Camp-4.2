using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Service
{
    public interface IBookService
    {
        Task AddBookServiceAsync(Book book);
        Task UpdateBookServiceAsync(Book book);
        Task DeleteBookServiceAsync(string bookCode);
        Task<List<Book>> GetAllBooksServiceAsync();
    }
}
