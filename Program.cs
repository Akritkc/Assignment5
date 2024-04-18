using Assignment5;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new Mailbox
        Mailbox mailbox = new Mailbox();

        // Add some mail items to the mailbox
        mailbox.AddMail(new Letter(200.0, "express", "Chemin des Acacias 28, 1009 Pully", "A3"));
        mailbox.AddMail(new Letter(800.0, "normal", "Invalid address", "A4"));
        mailbox.AddMail(new Advertisement(1500.0, "express", "Les Moilles 13A, 1913 Saillon"));
        mailbox.AddMail(new Advertisement(3000.0, "normal", "Invalid address"));
        mailbox.AddMail(new Parcel(5000.0, "express", "Grand rue 18, 1950 Sion", 30.0));
        mailbox.AddMail(new Parcel(3000.0, "express", "Chemin des fleurs 48, 2800 Delemont", 70.0));

        // Stamp the mailbox
        double totalPostage = mailbox.Stamp();
        Console.WriteLine($"The total amount of postage is {totalPostage:F1}");

        // Display the mailbox contents
        mailbox.Display();

        // Get the number of invalid mails
        int invalidMails = mailbox.InvalidMails();
        Console.WriteLine($"The box contains {invalidMails} invalid mails");
    }
}