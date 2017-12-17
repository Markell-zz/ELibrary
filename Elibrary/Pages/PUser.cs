using System;
using System.Collections.Generic;
using System.Linq;
using ELibrary.DB;
using ConsoleTables;

namespace ELibrary.Pages
{
    public class PUser
    {
        public void AddStudent()
        {
            string ELogin;
            string EPassword;
            string EFirstName;
            string ELastName;
            string EPatronymicName;
            string ECardNumber;
            string EPhone;
            string EAdress;

            Console.WriteLine("Введите логин");
            ELogin = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            EPassword = Console.ReadLine();
            Console.WriteLine("Введите имя");
            EFirstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            ELastName = Console.ReadLine();
            Console.WriteLine("Введите отчество");
            EPatronymicName = Console.ReadLine();
            Console.WriteLine("Введите номер читательского билета");
            ECardNumber = Console.ReadLine();
            Console.WriteLine("Введите номер телефона");
            EPhone = Console.ReadLine();
            Console.WriteLine("Введите адрес проживания");
            EAdress = Console.ReadLine();

            using (TablesContext db = new TablesContext())
            {
                // добавляем их в бд
                Student student = new Student { StudLogin = ELogin, StudPassword = EPassword, StudFirstName = EFirstName, StudLastName = ELastName, StudPatronymicName = EPatronymicName, StudCardNumber = ECardNumber, StudAdress = EAdress, StudPhone = EPhone };
                db.Students.Add(student);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
            }
        }

        public void ShowStudent()
        {

            using (TablesContext db = new TablesContext())
            {
                var students = db.Students;
                var table = new ConsoleTable("Id","Логин","Имя", "Фамилия", "Отчество");
                Console.WriteLine("Список всех пользователей:\n");
                foreach (Student s in students)
                {
                    table.AddRow(s.Id, s.StudLogin, s.StudFirstName,s.StudLastName,s.StudPatronymicName);
                }
                table.Write();
            }
        }

        public void EditStudent(int id)
        {
            string ELogin;
            string EPassword;
            string EFirstName;
            string ELastName;
            string EPatronymicName;
            string ECardNumber;
            string EPhone;
            string EAdress;
          using (TablesContext db = new TablesContext())
          {
                Student studentId = db.Students.Find(id);

                Console.Write("Изменить логин \n {0} -> ", studentId.StudLogin);
                ELogin = Console.ReadLine();
                Console.Write("Изменить пароль \n {0} -> ", studentId.StudPassword);
                EPassword = Console.ReadLine();
                Console.Write("Изменить имя \n {0} -> ", studentId.StudFirstName);
                EFirstName = Console.ReadLine();
                Console.Write("Изменить фамилию \n {0} -> ", studentId.StudLastName);
                ELastName = Console.ReadLine();
                Console.Write("Изменить отчество \n {0} -> ", studentId.StudPatronymicName);
                EPatronymicName = Console.ReadLine();
                Console.Write("Изменить номер читательского билета \n {0}->", studentId.StudCardNumber);
                ECardNumber = Console.ReadLine();
                Console.Write("Изменить номер телефона \n {0} -> ", studentId.StudPhone);
                EPhone = Console.ReadLine();
                Console.Write("Изменить адрес проживания \n {0} -> ", studentId.StudAdress);
                EAdress = Console.ReadLine();

                studentId.StudLogin =          ELogin;
                studentId.StudPassword =       EPassword;
                studentId.StudFirstName =      EFirstName;
                studentId.StudLastName =       ELastName;
                studentId.StudPatronymicName = EPatronymicName;
                studentId.StudCardNumber =     ECardNumber;
                studentId.StudAdress =         EAdress;
                studentId.StudPhone =          EPhone;
                db.SaveChanges();

                Console.WriteLine("Объекты успешно сохранены\n");
          }
        }

        public void RemoveStudent(int id)
        {
            using (TablesContext db = new TablesContext())
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
                Console.WriteLine("Данные успешно удалены");
            }
        }

        public void ShowStudent(int id)
        {
            using (TablesContext db = new TablesContext())
            {
                Student student = db.Students.Find(id);

                Console.WriteLine("Логин:                      " + student.StudLogin);
                Console.WriteLine("Имя:                        " + student.StudFirstName);
                Console.WriteLine("Фамилия:                    " + student.StudLastName);
                Console.WriteLine("Отчество:                   " + student.StudPatronymicName);
                Console.WriteLine("Номер читательского билета: " + student.StudCardNumber);
                Console.WriteLine("Номер телефона:             " + student.StudPhone);
                Console.WriteLine("Адрес:                      " + student.StudAdress);
            }
        }

    }
}
