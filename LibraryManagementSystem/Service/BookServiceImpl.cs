using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Service
{
    public class BookServiceImpl : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookServiceImpl(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBookServiceAsync(Book book)
        {
            await _bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookServiceAsync(Book book)
        {
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookServiceAsync(string bookCode)
        {
            await _bookRepository.DeleteBookAsync(bookCode);
        }

        public async Task<List<Book>> GetAllBooksServiceAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }
    }
}
