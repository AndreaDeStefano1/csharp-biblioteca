
class Dvd : Document
{
    public int Time { get; set; }

    public Dvd(int time, string code, string title, int year, string sector, bool avaible, string position, string author) : base(code, title, year, sector, avaible, position, author)
    {
        Time = time;
    }


}