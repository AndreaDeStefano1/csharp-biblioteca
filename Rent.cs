
class Rent
{
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Name { get; set; }
    public string UserFullName { get; set; }

    public Rent(string startDate, string endDate, string name, string userFullName)
    {
        StartDate = startDate;
        EndDate = endDate;
        Name = name;
        UserFullName = userFullName;
    }
}