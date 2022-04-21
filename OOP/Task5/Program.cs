using System;
using System.Collections.Generic;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StorageInterface storage = new StorageInterface();
            storage.OpenMenu();
        }
    }

    class StorageInterface
    {
        private BookStorage books = new BookStorage();
        private bool _isClose = false;
        private int _currentYear = 2022;

        public void OpenMenu ()
        {
            while (_isClose == false)
            {
                Console.Clear();
                Console.WriteLine("1 - добавить книгу, 2 - взять книгу, 3 - найти книгу, 4 - показать все книги");
                SelectCommand();
            }
        }

        private void SelectCommand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);
            Console.Clear();

            switch (menuComand)
            {
                case '1':
                    AddBookCommand();
                    break;

                case '2':
                    TakeTheBookCommand();
                    break;

                case '3':
                    FindTheBookCommand();
                    break;

                case '4':
                    ShowAllBooksCommand();
                    break;

                default:
                    _isClose = true;
                    break;
            }
        }

        private void ShowSearchedBooks(string parameter)
        {
            string parameterToSearch = Convert.ToString(parameter);
            books.ShowBooks(parameter);
            Console.WriteLine("Чтобы продолжить нажмите любую кнопку...");
            Console.ReadKey(true);
        }

        private void AddBookCommand()
        {
            Console.Write("Введите название книги: ");
            string bookName = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string bookAuthor = Console.ReadLine();
            Console.Write("Введите год выпуска книги книги: ");

            if (int.TryParse(Console.ReadLine(), out int result) && result > 0 && result < _currentYear)
            {
                int yearRelease = result;
                books.AddBook(new Book(bookName, bookAuthor, yearRelease));
            }
            else
            {
                Console.WriteLine("Год может быть числом от 0 до текущего!");
            }
        }

        private void TakeTheBookCommand()
        {
            Console.Write("Введите номер книги, которую хотите взять: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                int bookNumber = number;
                books.TakeTheBook(bookNumber);
            }
            else
            {
                Console.WriteLine("Номер книги должен быть числом!");
            }
        }

        private void FindTheBookCommand()
        {
            Console.Write("1 - поиск по названию, 2 - поиск по автору, 3 - поиск по году выпуска.");
            char searchComand = Convert.ToChar(Console.ReadKey(true).Key);
            Console.WriteLine();

            switch (searchComand)
            {
                case '1':
                    Console.Write("Введите название книги: ");
                    string nameToSearch = Console.ReadLine();
                    ShowSearchedBooks(nameToSearch);
                    break;

                case '2':
                    Console.Write("Введите автора книги: ");
                    string authorToSearch = Console.ReadLine();
                    ShowSearchedBooks(authorToSearch);
                    break;

                case '3':
                    Console.Write("Введите год выпуска книги книги: ");
                    string yearToSearch = Console.ReadLine();

                    if (int.TryParse(yearToSearch, out int year) && year > 0 && year < _currentYear)
                    {
                        ShowSearchedBooks(yearToSearch);
                    }
                    else
                    {
                        Console.WriteLine("Год может быть числом от 0 до текущего!");
                    }
                    break;
            }
        }

        private void ShowAllBooksCommand()
        {
            books.ShowBooks("all");
            Console.WriteLine("Чтобы продолжить нажмите любую кнопку...");
            Console.ReadKey(true);
        }
    }

    class BookStorage
    {
        private List<Book> _books = new List<Book>();
        private int _bookId;

        public void AddBook (Book book)
        {
            _books.Add(book);
        }

        public void TakeTheBook (int id)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                 if (id - 1 == i)
                {
                    _books.RemoveAt(i);
                }
            }
        }

        public void ShowBooks(string searchParameter)
        {
            _bookId = 0;

            foreach (Book book in _books)
            {
                _bookId++;

                if (searchParameter == book.BookName)
                {
                    Console.WriteLine($"{book.BookName}, athor: {book.Author}, release year: {book.ReleaseYear}");
                }
                else if (searchParameter == book.Author)
                {
                    Console.WriteLine($"{book.BookName}, athor: {book.Author}, release year: {book.ReleaseYear}");
                }
                else if (searchParameter == "all")
                {
                    Console.WriteLine($"{book.BookName}, athor: {book.Author}, release year: {book.ReleaseYear}");
                }
            }   
        }

        public void ShowBooks(int searchParameter)
        {
            _bookId = 0;

            foreach (Book book in _books)
            {
                _bookId++;

                if (searchParameter == book.ReleaseYear)
                {
                    Console.WriteLine($"{book.BookName}, athor: {book.Author}, release year: {book.ReleaseYear}");
                }
            }
        }
    }

    class Book
    {
        public string BookName { get;  private set; }

        public string Author { get; private set; }

        public int ReleaseYear { get; private set; }

        public Book(string bookName, string author, int realeseYear )
        {
            BookName = bookName;
            Author = author;
            ReleaseYear = realeseYear;
        }
    }
}