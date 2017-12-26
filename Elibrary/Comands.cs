using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ELibrary.Pages;

namespace ELibrary
{
    public class ComandsAdmin
    {
        public void BooksComands()
        {
            List<string> code = new List<string>();
            while (true)
            {
                Console.Write("> ");
                string line = Console.ReadLine();
                switch (line)
                {

                    default:
                        {
                            code.Add("              " + line);
                        }
                        break;
                }
            }
        }
        public void AdminComands()
        {
            PBook BooksPage = new PBook();
            PUser UsersPage = new PUser();
            PTakenBook TnBooksPage = new PTakenBook();

            Console.Clear();
            Console.WriteLine("\nВведите 'help' - получить список команд\n");
            List<string> code = new List<string>();
            while (true)
            {
                Console.Write("> ");
                string line = Console.ReadLine();
                switch (line)
                {
                    case "add book":
                        {
                            Console.WriteLine("\n");
                            BooksPage.Add();
                        }
                        break;

                    case "reterb book":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите Id выданного экземпляра:> ");
                            int eId;
                            eId = Convert.ToInt32(Console.ReadLine());
                            TnBooksPage.Reterb(eId);
                            Console.WriteLine("\n");
                        }
                        break;

                    case "add student":
                        {
                            Console.WriteLine("\n");
                            UsersPage.AddStudent();
                            Console.WriteLine("\n");
                        }
                        break;

                    case "add librarian":
                        {
                            Console.WriteLine("\n");
                            UsersPage.AddLibrarian();
                            Console.WriteLine("\n");
                        }
                        break;

                    case "edit book":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите Id книги:> ");
                            int eId = Convert.ToInt32(Console.ReadLine());
                            BooksPage.Edit(eId);
                        }
                        break;

                    case "edit student":
                        {
                            int eId;
                            Console.WriteLine("\n");
                            Console.Write("Введите Id студента:> ");
                            eId = Convert.ToInt32(Console.ReadLine());
                            UsersPage.EditStudent(eId);
                        }
                        break;

                    case "edit librarian":
                        {
                            int eId;
                            Console.WriteLine("\n");
                            Console.Write("Введите Id студента:> ");
                            eId = Convert.ToInt32(Console.ReadLine());
                            UsersPage.EditLibrarian(eId);
                        }
                        break;

                    case "remove book":
                        {
                            int eId;
                            Console.WriteLine("\n");
                            Console.Write("Введите Id книги:> ");
                            eId = Convert.ToInt32(Console.ReadLine());
                            BooksPage.Remove(eId);
                        }
                        break;
                    case "remove student":
                        {
                            int eId;
                            Console.WriteLine("\n");
                            Console.Write("Введите Id библиотекаря:> ");
                            eId = Convert.ToInt32(Console.ReadLine());
                            UsersPage.RemoveStudent(eId);
                        }
                        break;
                    case "remove librarian":
                        {
                            int eId;
                            Console.WriteLine("\n");
                            Console.Write("Введите Id библиотекаря:> ");
                            eId = Convert.ToInt32(Console.ReadLine());
                            UsersPage.RemoveLibrarian(eId);
                        }
                        break;

                    case "get book list":
                        {
                            Console.WriteLine("\n");
                            BooksPage.Show();
                            Console.WriteLine("\n");
                        }
                        break;
                    case "get student list":
                        {
                            Console.WriteLine("\n");
                            UsersPage.ShowStudent();
                            Console.WriteLine("\n");
                        }
                        break;

                    case "get book bi":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите номер книги:> ");
                            int eId = Convert.ToInt32(Console.ReadLine());
                            BooksPage.ShowBook(eId);
                            Console.WriteLine("\n");
                        }
                        break;

                    case "get tkbook list":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите Id пользователя:> ");
                            int eId;
                            eId = Convert.ToInt32(Console.ReadLine());
                            TnBooksPage.Get(eId);
                            Console.WriteLine("\n");
                        }
                        break;

                    case "get student":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите Id студента > ");
                            int eId;
                            eId = Convert.ToInt32(Console.ReadLine());
                            UsersPage.ShowStudent(eId);
                            Console.WriteLine("\n");
                        }
                        break;

                    case "get librarian":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите Id библиотекаря > ");
                            int eId;
                            eId = Convert.ToInt32(Console.ReadLine());
                            UsersPage.ShowLibrarian(eId);
                            Console.WriteLine("\n");
                        }
                        break;

                    case "find by name":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите название книги > ");
                            string name = Console.ReadLine();
                            BooksPage.FindByName(name);
                            Console.WriteLine("\n");
                        }
                        break;

                    case "find by genre":
                        {
                            Console.WriteLine("\n");
                            Console.Write("Введите жанр книги > ");
                            string genre = Console.ReadLine();
                            BooksPage.FindByGenre(genre);
                            Console.WriteLine("\n");
                        }
                        break;

                    case "exit":
                        {
                            Environment.Exit(0);
                        }
                        break;

                    case "help":
                        {
                            string[] commands = new string[]
                            {
                                        "\n  help ------------- список каманд",
                                        "  add book --------- добавить новую книгу",
                                        "  add student ------ добавить нового студента",
                                        "  add librarian ---- добавить нового библиотекаря",
                                        "  remove book ------ удалить книгу по Id",
                                        "  remove student --- удалить студента по Id",
                                        "  remove librarian - удалить библиотекаря по Id",
                                        "  edit book -------- изменить книгу по Id",
                                        "  edit student ----- изменить студента по Id",
                                        "  get book list ---- просмотреть список всех книг",
                                        "  get student list - просмотреть список всех студентов",
                                        "  get tkbook list -- просмотреть список книг по Id студента",
                                        "  take book  ------- взять книгу по Id",
                                        "  reterb book  ----  возвратить книгу по Id",
                                        "  get book info ---- просмотреть книгу по Id",
                                        "  get student  ----- просмотреть студента по Id",
                                        "  exit ------------- выйти из программы\n"
                            };
                            foreach (var str in commands)
                                Console.WriteLine(str);
                        }
                        break;

                    default:
                        {
                            code.Add("              " + line);
                        }
                        break;
                }
            }
        }

    }
    public class ComandsLibrarian : ComandsAdmin
    {
        public void LibrarianComands()
        {

        }
    }
    class ComandsStudent
    {
    }
}