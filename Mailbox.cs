using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Mailbox
    {
        // List to store the mail items
        private List<Mail> mails = new List<Mail>();

        // Method to add a new mail item to the mailbox
        public void AddMail(Mail mail)
        {
            mails.Add(mail);
        }

        // Method to calculate the total postage for all mail items in the mailbox
        public double Stamp()
        {
            double totalPostage = 0;
            foreach (var mail in mails)
            {
                totalPostage += mail.CalculatePostage();
            }
            return totalPostage;
        }

        // Method to count the number of invalid mail items in the mailbox
        public int InvalidMails()
        {
            int invalidCount = 0;
            foreach (var mail in mails)
            {
                if (!mail.IsValid())
                {
                    invalidCount++;
                }
            }
            return invalidCount;
        }

        // Method to display the contents of the mailbox
        public void Display()
        {
            foreach (var mail in mails)
            {
                double postage = mail.CalculatePostage();
                Console.WriteLine($"{mail.GetType().Name} Weight: {mail.weight:F1} grams");
                Console.WriteLine($"Express: {(mail.shippingMethod == "express" ? "yes" : "no")}");
                Console.WriteLine($"Destination: {mail.destinationAddress}");
                Console.WriteLine($"Price: ${postage:F1}");
                if (!mail.IsValid())
                {
                    Console.WriteLine($"{mail.GetType().Name} (Invalid courier)");
                }
                Console.WriteLine();
            }
        }
    }
}
