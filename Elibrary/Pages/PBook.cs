using System;
using System.Linq;
using ELibrary.DB;
using ConsoleTables;

namespace ELibrary
{
	public class PBook
	{
		public void Add()
		{
			string EBookName;
			string EBookAuthor;
			string EPublisher;
			int    EYearOfPublish;
			string EGenre;
            int EExemplarAmount;
            try
            {
                Console.WriteLine("Введите название книги");
			EBookName = Console.ReadLine();
			Console.WriteLine("Введите автора книги");
			EBookAuthor = Console.ReadLine();
			Console.WriteLine("Введите издатель книги");
			EPublisher = Console.ReadLine();
			Console.WriteLine("Введите год издания книги");
			EYearOfPublish = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите жанр книги");
			EGenre = Console.ReadLine();
                using (TablesContext db = new TablesContext())
                {
                    Genre genre = new Genre { Name = EGenre };
                    Book books = new Book { BookName = EBookName, BookAuthor = EBookAuthor, Publisher = EPublisher, YearOfPublish = EYearOfPublish };
                    db.Genres.Add(genre);
                    db.Books.Add(books);

                    Console.WriteLine("Введите количество экземпляров книги");
                    EExemplarAmount = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < EExemplarAmount; i++)
                    {
                        Console.Write("Введите номер экземпляра {0} > ", i + 1);
                        string EExemplar = Console.ReadLine();
                        Exemplar exemplars = new Exemplar { ExemplarNumber = EExemplar, BookId = books.Id, ExemplarStatus = "In Stock" };
                        db.Exemplars.Add(exemplars);
                    }

                    db.SaveChanges();
                    Console.WriteLine("Объекты успешно сохранены");
                }
            }
            catch (Exception) { Console.WriteLine("Данные введены не верно"); }



        }

        public void Show()
		{
			using (TablesContext db = new TablesContext())
			{
                var book = db.Books;
                Console.WriteLine("Список всех книг:");
                var table = new ConsoleTable("Id", "Название", "Автор");
                foreach (Book b in book)
                {
                        table.AddRow(b.Id, b.BookName, b.BookAuthor);
                }
                table.Write();
            }
		}

        public void Edit(int id)
        {
            string EBookName;
            string EBookAuthor;
            string EPublisher;
            int EYearOfPublish;
            string EGenre;
            string EExemplar;
            using (TablesContext db = new TablesContext())
            {
                try
                {
                    Book bookId = db.Books.Find(id);
                    var genre = db.Genres.Where(g => g.Id == id).FirstOrDefault();
                    var exemplar = db.Exemplars.Where(e => e.Id == id).FirstOrDefault();

                    Console.Write("Изменить название \n {0} -> ", bookId.BookName);
                    EBookName = Console.ReadLine();
                    Console.Write("Изменить автора \n {0} -> ", bookId.BookAuthor);
                    EBookAuthor = Console.ReadLine();
                    Console.Write("Изменить издателя \n {0} -> ", bookId.Publisher);
                    EPublisher = Console.ReadLine();
                    Console.Write("Изменить год издания \n {0} -> ", bookId.YearOfPublish);
                    EYearOfPublish = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Изменить жанр книги \n {0} -> ", genre.Name);
                    EGenre = Console.ReadLine();
                    Console.Write("Изменить номер экземпляра \n {0} -> ", exemplar.ExemplarNumber);
                    EExemplar = Console.ReadLine();

                    bookId.BookName = EBookName;
                    bookId.BookAuthor = EBookAuthor;
                    bookId.Publisher = EPublisher;
                    FindGenre(EGenre);
                    bookId.YearOfPublish = EYearOfPublish;
                    FindExemplar(EExemplar);
                    db.SaveChanges();
                    Console.WriteLine("Объекты успешно сохранены\n");
                }
                catch (System.FormatException) { Console.WriteLine("Поля не должны быть пустыми!"); }
            }
        }

        public void Remove(int id)
        {
            try
            {
                using (TablesContext db = new TablesContext())
                {
                    Book books = db.Books.Find(id);
                    var exemplar = db.Exemplars.Where(e => e.BookId == id).FirstOrDefault();
                    db.Exemplars.Remove(exemplar);
                    db.Books.Remove(books);
                    db.SaveChanges();
                    Console.WriteLine("Данные успешно удалены");
                }
            }
            catch(Exception) { Console.WriteLine("Данные введены не верно"); }
        }
        public void ShowBook(int id)
		{
            using (TablesContext db = new TablesContext())
            {
                Book book = db.Books.Find(id);
                var genre = db.Genres.Where(g => g.Id == id).FirstOrDefault();
                var tryexemplar = db.Exemplars.Where(e => e.Id == id).FirstOrDefault();
                var exemplar = db.Exemplars.Where(e => e.Id == id).FirstOrDefault();

                try
                {
                    Console.WriteLine("Название книги:         " + book.BookName);
                    Console.WriteLine("Автор книги:            " + book.BookAuthor);
                    Console.WriteLine("Жанр книги:             " + genre.Name);
                    Console.WriteLine("Издатель книги:         " + book.Publisher);
                    Console.WriteLine("Год издания книги:      " + book.YearOfPublish);
                    Console.WriteLine("Номер экземпляра книги: " + exemplar.ExemplarNumber);
                } catch { Console.WriteLine("Книга не найдена"); }
            }   
        }

        public void FindByGenre(string GenreName)
        {
            using (TablesContext db = new TablesContext())
            {
                var book = db.Books.Where(b => b.Genre.Name == GenreName).FirstOrDefault();
                var genre = db.Genres.Where(g => g.Name == GenreName).FirstOrDefault();
                try
                {
                    Console.WriteLine("Название книги:         " + book.BookName);
                    Console.WriteLine("Автор книги:            " + book.BookAuthor);
                    Console.WriteLine("Жанр книги:             " + genre.Name);
                    Console.WriteLine("Издатель книги:         " + book.Publisher);
                    Console.WriteLine("Год издания книги:      " + book.YearOfPublish);
                }
                catch (Exception e) { Console.WriteLine("Книга не найдена"); }
            }
        }

        public Genre FindGenre(string generename)
        {
            using (TablesContext db = new TablesContext())
            {
                var find = db.Genres
                    .Where(g => g.Name == generename)
                    .FirstOrDefault();

                if (find == null)
                {
                    find = new Genre { Name = generename };
                    db.Genres.Add(find);
                    db.SaveChanges();
                }
                return find;
            }
        }
        public Exemplar FindExemplar(string exemplarnumber)
        {
            using (TablesContext db = new TablesContext())
            {
                var find = db.Exemplars
                    .Where(e => e.ExemplarNumber == exemplarnumber)
                    .FirstOrDefault();

                if (find == null)
                {
                    find = new Exemplar { ExemplarNumber = exemplarnumber };
                    db.Exemplars.Add(find);
                    db.SaveChanges();
                }
                return find;
            }
        }

        public void FindN(string name)
        {
            try
            {
                using (TablesContext db = new TablesContext())
                {
                    var books = db.Books.Where(b => b.BookName == name).FirstOrDefault();
                    var table = new ConsoleTable("Id", "Название", "Автор");
                    table.AddRow(books.Id, books.BookName, books.BookAuthor);
                    table.Write();
                }
            }
            catch (Exception) { Console.WriteLine("Поиск не дал результатов, попробуйте повторить запрос"); }
        }

        public void FindG(string name)
        {
            using (TablesContext db = new TablesContext())
            {
                var genres = db.Genres.Where(g => g.Name == name);
                var table = new ConsoleTable("Id", "Название");
                foreach (Genre g in genres)
                {
                    foreach(Book b in g.Books) table.AddRow(g.Id, b.BookName);
                }
                table.Write();
            }
        }


    }
}
