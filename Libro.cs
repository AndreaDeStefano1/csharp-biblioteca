
class Libro : Documento
{
    public int TotalPages { get; set; }

    public Libro(int totalPages) : base( code,  title, int year, string sector, bool avaible, string position, string author)
    {
        TotalPages = totalPages;
    }
}