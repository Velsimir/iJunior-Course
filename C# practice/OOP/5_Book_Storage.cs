using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddBook = "Добавить";
            const string ShowAllBooks = "Показать все";
            const string ShowByFilter = "Фильтр";
            const string DeleteBook = "Удалить";
            const string CloseProgramm = "Закрыть";

            WareHouse wareHouse = new WareHouse();
            bool isWorking = true;

            void ErrorMessege()
            {
                Console.Clear();

                Console.WriteLine("Некорректный ввод");

                Console.ReadKey();
            }

            while (isWorking)
            {
                string userInput;

                Console.Write($"Введите команду для продолжения" +
                    $"\n{AddBook} - добавить книгу" +
                    $"\n{ShowAllBooks} - вывести все книги в хранилище" +
                    $"\n{ShowByFilter} - найти книгу по фильтру" +
                    $"\n{DeleteBook} - удалить книгу" +
                    $"\n{CloseProgramm} - выход из программы" +
                    $"\nВвод пользователя: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddBook:
                        wareHouse.AddBook();
                        break;

                    case ShowAllBooks:
                        wareHouse.ShowBooks();
                        break;

                    case ShowByFilter:
                        wareHouse.ShowFilterBooks();
                        break;

                    case DeleteBook:
                        wareHouse.DeleteBook();
                        break;

                    case CloseProgramm:
                        isWorking = false;
                        break;

                    default:
                        ErrorMessege();
                        break;
                }

                Console.Clear();
            }
        }
    }

    enum Genre
    {
        History = 1,
        Fantasy,
        Classic,
        Horror,
        Psychology
    }

    class WareHouse
    {
        private List<Book> _books;
        private int _id = 1;

        public WareHouse()
        {
            _books = new List<Book>();
        }

        public void AddBook()
        {
            string author;
            string nameBook;
            int releaseDate;
            int numberOfGenre;

            author = GetAuthor();

            nameBook = GetName();

            releaseDate = GetReleaseDate();

            numberOfGenre = GetGenre();

            Book book = new Book(author, nameBook, releaseDate, (Genre)numberOfGenre, _id);
            _id++;

            _books.Add(book);
        }

        public void DeleteBook()
        {
            Book book = null;

            if (TryGetBook(ref book) == true)
            {
                _books.Remove(book);
            }
            else
            {
                Console.WriteLine("Книги под введенным вами id не существует\nНажмите клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        public void ShowBooks(bool havePause = true)
        {
            foreach (var book in _books)
            {
                Console.WriteLine($"{book.Id} - {book.Author}\t{book.NameBook}\t{book.ReleaseDate}\t{book.Genre}");
            }

            if (havePause == true)
            {
                Console.WriteLine("Нажмите клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        public void ShowFilterBooks()
        {
            const string Genre = "Жанр";
            const string Author = "Автор";
            const string Name = "Название";

            string userInput;

            Console.Write($"По какому критерию вы хотите найти книгу?\n{Genre}\n{Author}\n{Name}\n");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case Genre:
                    IsGenreFound();
                    break;

                case Author:
                    IsAuthorFound();
                    break;

                case Name:
                    IsNameFound();
                    break;

                default:
                    Console.WriteLine("Некорректный ввод.\nНажмите любую клавишу, чтобы повторить...");
                    Console.ReadKey();
                    break;
            }
        }

        private bool IsGenreFound()
        {
            int value;
            bool haveBook = false;

            value = GetGenre();

            foreach (var book in _books)
            {
                if (book.Genre == (Genre)value)
                {
                    Console.WriteLine($"{book.Id} - {book.Author}\t{book.NameBook}\t{book.ReleaseDate}\t{book.Genre}");
                    haveBook = true;
                }
            }

            if (haveBook == true)
            {
                WriteSuccessMessege();
                return true;
            }
            else
            {
                WriteErrorMessege();
                return false;
            }
        }

        private bool IsAuthorFound()
        {
            bool haveBook = false;

            foreach (var book in _books)
            {
                if (book.Author == GetAuthor())
                {
                    Console.WriteLine($"{book.Id} - {book.Author}\t{book.NameBook}\t{book.ReleaseDate}\t{book.Genre}");
                    haveBook = true;
                }
            }

            if (haveBook == true)
            {
                WriteSuccessMessege();
                return true;
            }
            else
            {
                WriteErrorMessege();
                return false;
            }
        }

        private bool IsNameFound()
        {
            bool haveBook = false;

            foreach (var book in _books)
            {
                if (book.NameBook == GetName())
                {
                    Console.WriteLine($"{book.Id} - {book.Author}\t{book.NameBook}\t{book.ReleaseDate}\t{book.Genre}");
                    haveBook = true;
                }
            }

            if (haveBook == true)
            {
                WriteSuccessMessege();
                return true;
            }
            else
            {
                WriteErrorMessege();
                return false;
            }
        }

        private string GetAuthor()
        {
            Console.Write("\nВведите автора книги: ");
            string author = Console.ReadLine();

            return author;
        }

        private string GetName()
        {
            Console.Write("\nВведите название книги: ");
            string name = Console.ReadLine();

            return name;
        }

        private int GetReleaseDate()
        {
            string message = "\nВведите дату релиза книги: ";
            int releaseDate;

            releaseDate = GetNumber(message);

            Console.Clear();

            return releaseDate;
        }

        private int GetGenre()
        {
            string message = "\nВыберите жанр книги: ";
            int idGenre = 1;
            bool isWorking = true;

            while (isWorking)
            {
                ShowGenre();

                idGenre = GetNumber(message);

                if (idGenre >= 1 && idGenre <= 5)
                {
                    isWorking = false;

                    return idGenre;
                }
                else
                {
                    Console.WriteLine("Указан некорректный жанр.\nНажмите любую клавишу, чтобы повторить ввод...");
                }
            }

            return idGenre;
        }

        private int GetNumber(string message)
        {
            int value = 1;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write($"{message}");

                if (int.TryParse((Console.ReadLine()), out value))
                {
                    isWorking = false;

                    Console.Clear();
                    return value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. \nНажмите клавишу, чтобы повторить...");
                    Console.ReadKey();
                }
            }

            return value;
        }

        private void ShowGenre()
        {
            int number = 1;

            foreach (var genre in (Genre[])Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{number} - {genre}");

                number++;
            }
        }

        private bool TryGetBook(ref Book bookData)
        {
            string message = "\nВведите id книги, которую хотите удалить: ";
            int id;
            bool havePause = false;

            ShowBooks(havePause);

            id = GetNumber(message);

            foreach (var book in _books)
            {
                if (id == book.Id)
                {
                    bookData = book;
                    return true;
                }
            }

            return false;
        }

        private void WriteSuccessMessege()
        {
            Console.WriteLine("Нажмите клавишу, чтобы продолжить");
            Console.ReadKey();
        }

        private void WriteErrorMessege()
        {
            Console.WriteLine("По выбранному вами критерию нет книг");
            Console.ReadKey();
        }
    }

    class Book
    {
        public Book(string author, string nameBook, int releaseDate, Genre genre, int id)
        {
            Id = id;
            Author = author;
            NameBook = nameBook;
            ReleaseDate = releaseDate;
            Genre = genre;
        }
        
        public int Id { get; private set; }
        public string Author { get; private set; }
        public string NameBook { get; private set; }
        public int ReleaseDate { get; private set; }
        public Genre Genre { get; private set; }
    }
}
