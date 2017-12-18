using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELibrary.DB;
using ConsoleTables;

namespace ELibrary.Pages
{
    public class PTakenBook
    {
        public void Add(int Id, string StudentName)
        {
            DateTime thisDay = DateTime.Today;
            using (TablesContext db = new TablesContext())
            {
                Book book = db.Books.Find(Id);
                var exemplar = db.Exemplars.Where(e => e.BookId == Id).FirstOrDefault();
                if (exemplar.ExemplarStatus == "In Stock")
                {
                    var student = db.Students.Where(s => s.StudLogin == StudentName).FirstOrDefault();
                    TakenBook tkbook = new TakenBook { StudId = student.Id, ExemplarId = exemplar.Id, IssueDate = thisDay.ToString("g") };
                    exemplar.ExemplarStatus = "issued";
                    db.TakenBooks.Add(tkbook);
                    db.SaveChanges();
                    Console.WriteLine("Книга успешно выдана");
                }
                else
                {
                    Console.WriteLine("Книги нет в наличии");
                }
            }
        }

        public void Get(int Id)
        {
            using (TablesContext db = new TablesContext())
            {
                try
                {
                    var tkbook = db.TakenBooks.Where(tkb => tkb.StudId == Id).FirstOrDefault();
                    var studentame = db.Students.Where(s => s.Id == Id).FirstOrDefault();
                    var exemplar = db.Exemplars.Where(e => e.Id == tkbook.ExemplarId).FirstOrDefault();
                    var book = db.Books.Where(b => b.Id == exemplar.BookId).FirstOrDefault();
                    Console.WriteLine("Список всех взятых книг пользвателя {0} {1}:", studentame.StudFirstName, studentame.StudLastName);
                    var table = new ConsoleTable("Id", "Название книги", "Дата выдачи", "номер экземпляра книги");
                    var takenbooks = db.TakenBooks;
                    foreach (TakenBook t in takenbooks)
                    {
                        table.AddRow(tkbook.Id, book.BookName, tkbook.IssueDate, exemplar.ExemplarNumber);
                    }
                    table.Write();
                }
                catch (Exception e) { Console.WriteLine("У пользователя нет взятых книг"); }
            }
        }

        public void GetStud(string login)
        {
            using (TablesContext db = new TablesContext())
            {
                try
                {
                    var student = db.Students.Where(s => s.StudLogin == login).FirstOrDefault();
                    var tkbook = db.TakenBooks.Where(tkb => tkb.StudId == student.Id).FirstOrDefault();
                    var exemplar = db.Exemplars.Where(e => e.Id == tkbook.ExemplarId).FirstOrDefault();
                    var book = db.Books.Where(b => b.Id == exemplar.BookId).FirstOrDefault();
                    Console.WriteLine("Список всех взятых книг пользвателя {0} {1}:", student.StudFirstName, student.StudLastName);
                    var table = new ConsoleTable("Id", "Название книги", "Дата выдачи", "номер экземпляра книги");
                    var takenbooks = db.TakenBooks;
                    foreach (TakenBook t in takenbooks)
                    {
                        table.AddRow(tkbook.Id, book.BookName, tkbook.IssueDate, exemplar.ExemplarNumber);
                    }
                    table.Write();
                }
                catch (Exception e) { Console.WriteLine("У вас нет взятых книг"); }
            }
        }

        public void Reterb(int Id)
        {
            DateTime thisDay = DateTime.Today;
            using (TablesContext db = new TablesContext())
            {
                var tkbook = db.TakenBooks.Where(tkb => tkb.Id == Id).FirstOrDefault();
                var exemplar = db.Exemplars.Where(e => e.Id == tkbook.Id).FirstOrDefault();

                tkbook.ReterbDate = thisDay.ToString("g");
                db.TakenBooks.Remove(tkbook);
                exemplar.ExemplarStatus = "In Stock";
                db.SaveChanges();
                Console.WriteLine("Долг успешно закрыт");
            }
        }
    }
}
