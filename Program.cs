using System;
using System.Collections.Generic;

interface IBorrowable
{
    void BorrowBook();
    void ReturnBook();
}

class Person
{
    public int Id;
    public string Name;

    public Person() { }

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Book
{
    public string Title;
    public string Author;
    public string SN;
    public double Price;

    public static int TotalBooks = 0;

    public Book(string title, string author, string sn, double price)
    {
        Title = title;
        Author = author;
        SN = sn;
        Price = price;
        TotalBooks++;
    }

    public Book(Book b)
    {
        Title = b.Title;
        Author = b.Author;
        SN = b.SN;
        Price = b.Price;
        TotalBooks++;
    }

    public void Display()
    {
        Console.WriteLine($"{Title} by {Author}");
    }

    public void Display(bool showPrice)
    {
        if (showPrice)
            Console.WriteLine($"SN: {SN}, Title: {Title}, Author: {Author}, Price: ${Price}");
    }

    public static double operator +(Book b1, Book b2)
    {
        return b1.Price + b2.Price;
    }

    public static void ShowTotalBooks()
    {
        Console.WriteLine("Total Books in Library: " + TotalBooks);
    }
}

class Member : Person, IBorrowable
{
    public Member(int id, string name) : base(id, name) { }

    public void BorrowBook()
    {
        Console.WriteLine(Name + " borrowed a book.");
    }

    public void ReturnBook()
    {
        Console.WriteLine(Name + " returned a book.");
    }
}

class Librarian : Person
{
    public double Salary;

    public Librarian(int id, string name, double salary) : base(id, name)
    {
        Salary = salary;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Employee ID: {Id}, Name: {Name}, Salary: ${Salary}");
    }
}

class Library
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();
    private List<Librarian> librarians = new List<Librarian>();

    public void AddBook(Book b) => books.Add(b);
    public void AddMember(Member m) => members.Add(m);
    public void AddLibrarian(Librarian l) => librarians.Add(l);

    public void ShowBooks()
    {
        Console.WriteLine("\n--- Book List ---");
        foreach (Book b in books)
            b.Display(true);
    }

    public void GenerateReport()
    {
        Console.WriteLine("\n--- Library Report ---");
        Console.WriteLine("Total Books: " + books.Count);
        Console.WriteLine("Total Members: " + members.Count);
        Console.WriteLine("Total Employees: " + librarians.Count);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        Book b1 = new Book("Clean Code", "Robert C. Martin", "OOP1", 32);
        Book b2 = new Book("Head First Design Patterns", "Eric Freeman", "OOP2", 25);
        Book b3 = new Book("Effective Java", "Joshua Bloch", "OOP3", 75);
        
        Book b8 = new Book(b1);

        library.AddBook(b1);
        library.AddBook(b2);
        library.AddBook(b3);
        

        double totalPrice = b1 + b2;
        Console.WriteLine("Total price of first two books: $" + totalPrice);

        Book.ShowTotalBooks();

        Member m1 = new Member(1, "Lokman");
        Member m2 = new Member(2, "Sakib");
        Member m3 = new Member(3, "Pollob");

        library.AddMember(m1);
        library.AddMember(m2);
        library.AddMember(m3);


        m1.BorrowBook();
        m2.ReturnBook();

        Librarian l1 = new Librarian(1156, "Edward", 2200);
        Librarian l2 = new Librarian(1178, "Meherab", 2200);
        Librarian l3 = new Librarian(1179, "Fahim", 2200);
        Librarian l4 = new Librarian(1181, "Abdur Rahman", 2200);

        library.AddLibrarian(l1);
        library.AddLibrarian(l2);
        library.AddLibrarian(l3);
        library.AddLibrarian(l4);

        l1.ShowInfo();
        l2.ShowInfo();
        l3.ShowInfo();
        l4.ShowInfo();

        library.ShowBooks();
        library.GenerateReport();

        Console.ReadKey();
    }
}