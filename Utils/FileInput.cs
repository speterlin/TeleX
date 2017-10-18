using System;
using System.IO;
using System.Collections.Generic;
using Transaction;

namespace Utils
{
    public static class FileInput 
    {
        public static List<Transaction.Transaction> HandleFileInput () {
            List<Transaction.Transaction> transactions = new List<Transaction.Transaction>();
            Console.WriteLine("Please enter file path, or 'Exit' to return:");
            var input = Console.ReadLine();
            if (input == "Exit") {
                return transactions;
            }
            if (!File.Exists(input)) {
                Console.WriteLine("File path does not exist");
                return transactions;
            } 
            string[] lines = System.IO.File.ReadAllLines(input);
            for (int i = 0; i < lines.Length; i++)
            {
                //skip the first line, assuming this is the title and such
                if (i == 0)
                {
                    continue;
                }
                var transaction = new Transaction.Transaction();
                //assuming csv file input with transaction Type, Duration, Time, PhoneNumber, and Location (in that order)
                var items = lines[i].Split(',', '\t', ';');
                if (Transaction.Validations.TypeIsValid(items[0]))
                {
                    transaction.Type = items[0];
                }
                else
                {
                    Console.WriteLine($"Invalid Type entry on line {i}, enter 'Call', 'Text', or 'Data' in the Type column and re-upload file");
                    break;
                }
                if (Transaction.Validations.DurationIsValid(items[1]))
                {
                    transaction.Duration = int.Parse(items[1]);
                }
                else
                {
                    Console.WriteLine($"Invalid Duration entry on line {i}, please enter a positive integer value between 0 and 1000 in the Duration column and re-upload file");
                    break;
                }
                if (Transaction.Validations.TimeIsValid(items[2]))
                {
                    transaction.Time = DateTime.Parse(items[2]);
                }
                else
                {
                    Console.WriteLine($"Invalid Time entry on line {i}, please enter a valid date and time (in the past) in the Time column and re-upload file");
                    break;
                }
                if (Transaction.Validations.PhoneNumberIsValid(items[3]))
                {
                    transaction.PhoneNumber = items[3];
                }
                else
                {
                    Console.WriteLine($"Invalid Phone Number entry on line {i}, please enter a valid phone number in the Phone Number column and re-upload file");
                    break;
                }
                if (Transaction.Validations.LocationIsValid(items[4]))
                {
                    transaction.Location = items[4];
                }
                else
                {
                    Console.WriteLine($"Invalid Location entry on line {i}, please enter a valid location in the Location column and re-upload file");
                    break;
                }
                transactions.Add(transaction);
            }
            return transactions;
        }
    }
}
