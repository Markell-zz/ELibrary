using System;
using System.Collections.Generic;
using ELibrary.DB;
using ELibrary.Pages;
using ConsolePasswordMasker;
using System.Linq;

namespace ELibrary
{
	class Program
	{
        static PasswordMasker masker = new PasswordMasker();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "ELibrary";

            PBook BooksPage = new PBook();
            PUser UsersPage = new PUser();

            string login;
            Console.Write("\n Введие логин:  ");
            login = Console.ReadLine();
            Console.Write(" Введие пароль: ");
            string password = masker.Mask(loginText: " Введие пароль: ", charMask: '*', useBeep: true);
            using (TablesContext db = new TablesContext())
            {
                var Elogin = db.Students.Where(s => s.StudLogin == login).FirstOrDefault();
                var EPassword = db.Students.Where(s => s.StudPassword == password).FirstOrDefault();
                if (Elogin != null && EPassword != null)
                {
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

                        case "add student":
                            {
                                Console.WriteLine("\n");
                                UsersPage.AddStudent();
                                Console.WriteLine("\n");
                            }
                            break;

                        case "edit book":
                                {
                                    int eId;
                                    Console.WriteLine("\n");
                                    Console.Write("Введите Id книги:> ");
                                    eId = Convert.ToInt32(Console.ReadLine());
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
                                    Console.Write("Введите Id студента:> ");
                                    eId = Convert.ToInt32(Console.ReadLine());
                                    UsersPage.RemoveStudent(eId);
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
                                    Console.Write("Введите Id книги > ");
                                    int eId;
                                    eId = Convert.ToInt32(Console.ReadLine());
                                    BooksPage.ShowBook(eId);
                                    Console.WriteLine("\n");
                                }
                                break;

                            case "get student bi":
                                {
                                    Console.WriteLine("\n");
                                    Console.Write("Введите Id студента > ");
                                    int eId;
                                    eId = Convert.ToInt32(Console.ReadLine());
                                    UsersPage.ShowStudent(eId);
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
                                        "  remove book ------ удалить книгу по Id",
                                        "  remove student --- удалить студента по Id",
                                        "  edit book -------- изменить книгу по Id",
                                        "  edit student ----- изменить студента по Id",
                                        "  get book list ---- просмотреть список всех книг",
                                        "  get student list - просмотреть список всех студентов",
                                        "  get book bi ------ просмотреть книгу по Id",
                                        "  get student bi --- просмотреть студента по Id",
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
                else
                {
                    Console.WriteLine("Пользователь не найден!");
                }
            }
        }

	}
}
