﻿
class User
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Pasword { get; set; }
    public uint PhoneNumber { get; set; }

    public User(string surname, string name, string email, string pasword, uint phoneNumber)
    {
        Surname = surname;
        Name = name;
        Email = email;
        Pasword = pasword;
        PhoneNumber = phoneNumber;
    }
}