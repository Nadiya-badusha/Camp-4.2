using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.Service;

namespace LibraryManagementSystem
{
        internal class Program
        {
            static async Task Main(string[] args)
            {
                IBookRepository repo = new BookRepositoryImpl();
                IBookService service = new BookServiceImpl(repo);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Library Management System");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. Update Book");
                    Console.WriteLine("3. Delete Book");
                    Console.WriteLine("4. List All Books");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            await AddBookInput(service);
                            break;
                        case "2":
                            await UpdateBookInput(service);
                            break;
                        case "3":
                            await DeleteBookInput(service);
                            break;
                        case "4":
                            await DisplayAllBooks(service);
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Press any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            private static async Task AddBookInput(IBookService service)
            {
                Console.WriteLine("\nEnter Book Details:");

                Console.Write("Book Code: ");
                string code = Console.ReadLine();

                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Author: ");
                string author = Console.ReadLine();

                Console.Write("Genre: ");
                string genre = Console.ReadLine();

                Console.Write("Price: ");
                decimal.TryParse(Console.ReadLine(), out decimal price);

                Book book = new Book(code, title, author, genre, price);
                await service.AddBookServiceAsync(book);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static async Task UpdateBookInput(IBookService service)
            {
                Console.WriteLine("\nUpdate Book Details:");

                Console.Write("Book Code to update: ");
                string code = Console.ReadLine();

                Console.Write("New Title: ");
                string title = Console.ReadLine();

                Console.Write("New Author: ");
                string author = Console.ReadLine();

                Console.Write("New Genre: ");
                string genre = Console.ReadLine();

                Console.Write("New Price: ");
                decimal.TryParse(Console.ReadLine(), out decimal price);

                Book book = new Book(code, title, author, genre, price);
                await service.UpdateBookServiceAsync(book);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static async Task DeleteBookInput(IBookService service)
            {
                Console.WriteLine("\nDelete Book:");

                Console.Write("Enter Book Code to delete: ");
                string code = Console.ReadLine();

                await service.DeleteBookServiceAsync(code);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static async Task DisplayAllBooks(IBookService service)
            {
                Console.WriteLine("\nList of Books:");

                List<Book> books = await service.GetAllBooksServiceAsync();

                if (books.Count == 0)
                {
                    Console.WriteLine("No books found.");
                }
                else
                {
                    Console.WriteLine("{0,-12} | {1,-30} | {2,-20} | {3,-15} | {4,10}", "BookCode", "Title", "Author", "Genre", "Price");
                    Console.WriteLine(new string('-', 95));

                    foreach (var book in books)
                    {
                        Console.WriteLine("{0,-12} | {1,-30} | {2,-20} | {3,-15} | {4,10:C2}",
                            book.BookCode, book.Title, book.Author, book.Genre, book.Price);
                    }
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
}
