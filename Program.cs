Biblioteca B = new Biblioteca();

bool exit = false;
B.SetUserList();
B.SetBookList();
B.SetDvdList();

while (!exit)
{
    if(B.logged == false)
    {
        Console.WriteLine("Devi effettuare il Login");
        B.Login();

    }
    else
    {
        Console.Clear();

        Console.WriteLine();
        Console.WriteLine("1 Cerca Libro per Nome");
        int userChoice = Convert.ToInt32(Console.ReadLine());   
        switch (userChoice)
        {
            case 1 :

                Console.Clear();
                B.SearchForName(List<Book> book);
                break;
        }
    }
}

























class Biblioteca
{
    public bool logged = false;
    List<Book> Books = new List<Book>();  
    List<Dvd> Dvds = new List<Dvd>();
    List<User> Users = new List<User>();
    

    public void SetUserList()
    {
        User u = new User("Rossi", "Mario", "mario@rossi.it", "password", 3312323259);
        Users.Add(u);   
    }

    public void SetBookList()
    {
        Book b = new Book(1364, "883010471X", "Il Signore degli Anelli", 1955, "Fantasy", true, "F1", "J.R.R. Tolkien");
        Book b2 = new Book(304, "1644732076", "Harry Potter e la pietra filosofale", 1997, "Fantasy", true, "F2", "J.K. Rowling");
        Book b3 = new Book(170, "8891741558", "Uno psicologo nei lager", 1946, "Saggio", false, "S1", "Viktor Frankl");
        Books.Add(b);   
        Books.Add(b2);  
        Books.Add(b3);  
    }

    public void SetDvdList()
    {
        Dvd d = new Dvd(94, "00019929", "Il Buco", 2019, "Thriller", true, "T1", "Galder Gaztelu-Urrutia");
        Dvd d2 = new Dvd(124, "12312111", "Suicide Squad", 2016, "Azione", false, "A1", "David Ayer");
        Dvd d3 = new Dvd(106, "00019239", "The Adam Project", 2022, "Fantascienza", true, "F1", "Shawn Levy");
        Dvds.Add(d);
        Dvds.Add(d2);       
        Dvds.Add(d3);   

    }

    public void Login()
    {
        User:
        Console.Clear();
        Console.WriteLine("Email:");
        foreach(User u in Users)
        {
            string userInputEmail = Console.ReadLine();
            if (userInputEmail == u.Email )
            {
                Password:  
                Console.WriteLine("Password:");
                string userInputPassword = Console.ReadLine();
                if (userInputPassword == u.Pasword)
                {
                    logged = true;
                    Console.WriteLine("Loggato");
                }
                else
                {
                    Console.WriteLine("Riprova");
                    goto Password;
                }
            }
            else
            {
                goto User;
            }
        }
        
    }

    public Document SearchForName(List<Document> documents)
    {
    SearchForName:
        Console.WriteLine("inserisci il nome del libro da ricercare");
        string input = Console.ReadLine();

        foreach (Document document in documents)
        {

            if (input.ToLower() == document.Title.ToLower())
            {
                Document d = document;
                return d;
            }
            Console.WriteLine("Nome non valido riprova");
        }
        goto SearchForName;
    }


    static Book SearchForName(List<Book> books)
    {
    SearchForName:
        Console.WriteLine("Inserisci il nome del libro da ricercare");
        string input = Console.ReadLine();

        foreach (Book book in books)
        {

            if (input.ToLower() == book.Title.ToLower())
            {
                Book b = book;
                return b;
            }
            Console.WriteLine("Nome non valido riprova");
        }
        goto SearchForName;
    }



}