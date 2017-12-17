using System.Collections.Generic;

public class Student
{
    public int    Id                 { get; set; }
    public string StudLogin          { get; set; }
    public string StudPassword       { get; set; }
    public string StudFirstName      { get; set; }
    public string StudLastName       { get; set; }
    public string StudPatronymicName { get; set; }
    public string StudCardNumber     { get; set; }
    public string StudAdress         { get; set; }
    public string StudPhone          { get; set; }

    public List<TakenBook> TakenBooks { get; set; }
    public Student()
    {
        TakenBooks = new List<TakenBook>();
    }
}

public class TakenBook
{
    public int    Id         { get; set; }
    public string IssueDate  { get; set; }
    public string ReterbDate { get; set; }

    public int?    StudId  { get; set; }
    public Student Student { get; set; }

    public int?     ExemplarId { get; set; }
    public Exemplar Exemplar   { get; set; }
}

public class Exemplar
{
    public int    Id             { get; set; }
    public string ExemplarStatus { get; set; }
    public string ExemplarNumber { get; set; }

    public int? BookId { get; set; }
    public Book Book   { get; set; }

    public List<TakenBook> TakenBooks { get; set; }
    public Exemplar()
    {
        TakenBooks = new List<TakenBook>();
    }
}

public class Book
{
	public int    Id            { get; set; }
	public string BookName      { get; set; }
	public string BookAuthor    { get; set; }
	public string Publisher     { get; set; }
	public int    YearOfPublish { get; set; }

	public int?  GenreId { get; set; }
	public Genre Genre   { get; set; }

	public List<Exemplar> Exemplars { get; set; }
	public Book()
	{
		Exemplars = new List<Exemplar>();
	}

}

public class Genre
{
	public int    Id   { get; set; }
	public string Name { get; set; }

	public List<Book> Books { get; set; }
	public Genre()
	{
		Books = new List<Book>();
	}
}