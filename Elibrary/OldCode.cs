// создаем два объекта User
                Genre genre = new Genre { Name = "Roman" };
                 добавляем их в бд
                db.Genres.Add(genre);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                 //получаем объекты из бд и выводим на консоль
                var genres = db.Genres;
                Console.WriteLine("Список объектов:");
                foreach (Genre g in genres)
                {
                	Console.WriteLine("{0} - {1}", g.Id, g.Name);
                }


                Book books = new Book { BookName = "Roboson", BookAuthor = "Danoel Defo", Genre = genre, Publisher = "Piter", YearOfPublish = 1223 };
                // добавляем их в бд
                db.Books.Add(books);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                Exemplar exemplars = new Exemplar { ExemplarNumber = "23g6442724t", Book = books };
                // добавляем их в бд
                db.Exemplars.Add(exemplars);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var book = db.Books;
                Console.WriteLine("Список объектов:");
                foreach (Book b in book)
                {
                	Console.WriteLine("{0} - {1} {2} {3} {4} {5}", b.Id, b.BookName, b.BookAuthor, b.Genre.Name, b.Publisher, b.YearOfPublish);
                }

                foreach (Genre g in db.Genres)
                {
                	Console.WriteLine("Genre: {0}", g.Name);
                	foreach (Book bk in g.Books)
                	{
                		Console.WriteLine("{0} - {1}", bk.BookName, bk.BookAuthor);
                	}
                	Console.WriteLine();
                }

                foreach (Exemplar e in db.Exemplars)
                {
                	Console.WriteLine("Exemplar: {0}", e.ExemplarNumber);
                	Console.WriteLine("{0}", e.Book.BookName);

                	Console.WriteLine();
                }

                Console.ReadLine();
