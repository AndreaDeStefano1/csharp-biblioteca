Biblioteca B = new Biblioteca();

bool exit = false;
B.SetUserList();
B.SetBookList();
B.SetDvdList();
User user = new User("XXX", "xxxx", "xxxx", "xxx", 3319262524);



while (!exit)
{
    if (B.logged == false)
    {
        Console.WriteLine("Devi effettuare il Login");
        
        user = B.Login();
    }
    else
    {
        
        // dati di accesso
        // email: m@m.it
        // password: ...


     Menu:
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Menu");
        Console.WriteLine("1 Cerca Libro");
        Console.WriteLine("2 Cerca DVD");
        Console.WriteLine("3 Cerca Prestito");
        int userChoice = Convert.ToInt32(Console.ReadLine());   
        switch (userChoice)
        {
            case 1 :

                Book foundBook = B.Search(B.Books);
                if (foundBook != null)
                {
                    B.Print(foundBook);
                    Console.WriteLine("1.Torna");
                    Console.WriteLine("2:Prestito");
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            goto Menu;

                        case 2 :
                            B.SetRent(foundBook, user);
                            Console.WriteLine("Grazie!");
                            goto Menu;

                    }

                }
                break;

            case 2 :

                Dvd foundDvd = B.Search(B.Dvds);
                if (foundDvd != null)
                {
                    B.Print(foundDvd);
                    Console.WriteLine("1.Torna");
                    Console.WriteLine("2:Prestito");
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            goto Menu;
                            

                        case 2 :
                            B.SetRent(foundDvd, user);
                            break;
                    }

                }
                break;

            case 3:
                Console.WriteLine("Inserisci il nome completo dell utente");
                string userName = Console.ReadLine();
                B.PrintRent(B.SearchRent(userName));
                Console.WriteLine();
                Console.WriteLine("1. esci");
                Console.WriteLine();
                int userFlag = Convert.ToInt32(Console.ReadLine());
                switch (userFlag)
                {
                    case 1:

                        goto Menu;
                }
                break;

                default :
                    Console.WriteLine("Ciao!!");
                    exit = true;


                    break;
        }
    }
}























class Biblioteca
{
    public bool logged = false;
    public List<Book> Books = new List<Book>();
    public List<Dvd> Dvds = new List<Dvd>();
    public List<User> Users = new List<User>();
    List<Rent> Rents = new List<Rent>();
    

    public void SetUserList()
    {
        User u = new User("Rossi", "Mario", "m@m.it", "password", 3312323259);
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

    public User Login()
    {
        User:
        
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
                    return u;
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
        goto User;
        
    }

    public Document Search(List<Document> documents)
    {
    Search:
        Console.WriteLine("Inserisci la ricerca");
        string input = Console.ReadLine();

        foreach (Document document in documents)
        {

            if (input.ToLower() == document.Title.ToLower())
            {
                Document d = document;
                return d;
            }
            Console.WriteLine("Inserimento non valido");
        }
        goto Search;
    }


    public Book Search(List<Book> books)
    {
    Search:
        Console.WriteLine("Inserisci la ricerca");
        string input = Console.ReadLine();

        foreach (Book book in books)
        {

            if (book.Title.ToLower().Contains(input.ToLower()) || book.Code.ToLower().Contains(input.ToLower()))
            {
                Book b = book;
                return b;
            }

        }
        Console.WriteLine("non torvato");
        goto Search;
    }

    public Dvd Search(List<Dvd> dvds)
    {
    Search:
        Console.WriteLine("Inserisci la ricerca");
        string input = Console.ReadLine();

        foreach (Dvd dvd in dvds)
        {

            if (dvd.Title.ToLower().Contains(input.ToLower()) || dvd.Code.ToLower().Contains(input.ToLower()))
            {
                Dvd b = dvd;
                return b;
            }
 
        }
        Console.WriteLine("non torvato");
        goto Search;
    }

    public void Print(Document d)
    {
        Console.WriteLine();
        Console.WriteLine("Titolo: " + d.Title);
        Console.WriteLine("Anno di pubblicazione: " + d.Year);
        Console.WriteLine("Codice: " + d.Code);
        Console.WriteLine("Genere: " + d.Sector);
        Console.WriteLine("Disponibile: " + (d.Avaible ? "si" : "no"));
        Console.WriteLine("Posizione: " + d.Position);
        Console.WriteLine();        
    }


    public void Print(Book b)
    {
        Console.WriteLine();
        Console.WriteLine("Titolo: " + b.Title);
        Console.WriteLine("Anno di pubblicazione: " + b.Year);
        Console.WriteLine("Codice: " + b.Code);
        Console.WriteLine("Genere: " + b.Sector);
        Console.WriteLine("Disponibile: " + (b.Avaible ? "si" : "no"));
        Console.WriteLine("Posizione: " + b.Position);
        Console.WriteLine();        
    }

    public void SetRent(Book book , User user)
    {
        if (book.Avaible)
        {
        book.Avaible = false;
        Console.WriteLine("Inserisci data di inizio prestito (DD/MM/YYYY)");
        string startDate = Console.ReadLine();  
        Console.WriteLine("Inserisci data di fine prestito (DD/MM/YYYY)");
        string endDate = Console.ReadLine();
        Rent r = new Rent(startDate, endDate, book.Title, user.GetFullName(user.Name, user.Surname));
        Rents.Add(r);
        }
        else
        {
            Console.WriteLine("Non è possibili effettuare il prestito un libro non disponibile");
        }
    }
    
    public void SetRent(Dvd dvd , User user)
    {
        if (dvd.Avaible)
        {
            dvd.Avaible = false;
            Console.WriteLine("Inserisci data di inizio prestito (DD/MM/YYYY)");
            string startDate = Console.ReadLine();
            Console.WriteLine("Inserisci data di fine prestito (DD/MM/YYYY)");
            string endDate = Console.ReadLine();
            Rent r = new Rent(startDate, endDate, dvd.Title, user.GetFullName(user.Name, user.Surname));
            Rents.Add(r);
        }
        else
        {
            Console.WriteLine("Non è possibili effettuare il prestito un dvd non disponibile");

        }
    }

    public Rent SearchRent(string fullName)
    {
        if(Rents.Count > 0)
        {
            Ricerca:
            foreach (Rent r in Rents)
            {
                if (r.UserFullName.ToLower().Contains(fullName.ToLower()))
                {
                    return r;
                }
            }
            Console.WriteLine("La ricerca non ha restituito nessun risultato, riprova");
            goto Ricerca;
        }
        Rent rent = new Rent("xxx", "xxx", "xxx", "xxx");
        return rent;
    }

    public void PrintRent(Rent rent)
    {
        if(rent.Name != "xxx")
        {
            Console.WriteLine();
            Console.WriteLine("Titolo prestato: " + rent.Name);
            Console.WriteLine("Nome: " + rent.UserFullName);
            Console.WriteLine("Inizio prestito: " + rent.StartDate);
            Console.WriteLine("Fine prestito: " + rent.EndDate);
            Console.WriteLine();
        }

    }
}