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
                    Console.WriteLine("Введите номер экземпляра");
                    string EExemplar = Console.ReadLine();
                    Exemplar exemplars = new Exemplar { ExemplarNumber = EExemplar, Book = books, ExemplarStatus = "In Stock" };
                    db.Exemplars.Add(exemplars);
                }

                db.SaveChanges();
				Console.WriteLine("Объекты успешно сохранены");
			}



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
                Book bookId = db.Books.Find(id);
                var genre = db.Genres.Where(g => g.Id == id).FirstOrDefault();
                var exemplar = db.Exemplars.Where(e => e.Id == id).FirstOrDefault();

                Console.WriteLine("Изменить название \n {0} -> ", bookId.BookName);
                EBookName = Console.ReadLine();
                Console.WriteLine("Изменить автора \n {0} -> ", bookId.BookAuthor);
                EBookAuthor = Console.ReadLine();
                Console.WriteLine("Изменить издателя \n {0} -> ", bookId.Publisher);
                EPublisher = Console.ReadLine();
                Console.WriteLine("Изменить год издания \n {0} -> ", bookId.YearOfPublish);
                EYearOfPublish = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Изменить жанр книги \n {0} -> ", genre.Name);
                EGenre = Console.ReadLine();
                Console.WriteLine("Изменить номер экземпляра \n {0} -> ", exemplar.ExemplarNumber);
                EExemplar = Console.ReadLine();

                bookId.BookName =      EBookName;
                bookId.BookAuthor =    EBookAuthor;
                bookId.Publisher =     EPublisher;
                FindGenre(EGenre);
                bookId.YearOfPublish = EYearOfPublish;
                FindExemplar(EExemplar);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены\n");
            }
        }

        public void Remove(int id)
        {
            using (TablesContext db = new TablesContext())
            {
                Book book = db.Books.Find(id);
                var exemplar = db.Exemplars.Where(e => e.Id == id).FirstOrDefault();
                db.Books.Remove(book);
                db.Exemplars.Remove(exemplar);
                db.SaveChanges();
                Console.WriteLine("Данные успешно удалены");
            }
        }
        public void ShowBook(int id)
		{
            using (TablesContext db = new TablesContext())
			{
                Book book = db.Books.Find(id);
                var genre = db.Genres.Where(g => g.Id == id).FirstOrDefault();
                var exemplar = db.Exemplars.Where(e => e.Id == id).FirstOrDefault();

                Console.WriteLine("Название книги:        "+book.BookName);
                Console.WriteLine("Автор книги:            " + book.BookAuthor);
                Console.WriteLine("Жанр книги:             " + genre.Name);
                Console.WriteLine("Издатель книги:         " + book.Publisher);
                Console.WriteLine("Год издания книги:      " + book.YearOfPublish);
                Console.WriteLine("Номер экземпляра книги: " + exemplar.ExemplarNumber);
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

    }
}
