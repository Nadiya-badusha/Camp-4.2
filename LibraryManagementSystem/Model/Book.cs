using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class Book
    {
        public string BookCode { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public Book() { }

        public Book(string bookCode, string title, string author, string genre, decimal price)
        {
            BookCode = bookCode;
            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
        }
    }
}
