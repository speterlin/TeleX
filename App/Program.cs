using System;
using System.Collections.Generic;
using Transaction;
using Utils;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the TeleX Rate Calculator!");
            List<Transaction.Transaction> transactions = new List<Transaction.Transaction>();
            var repeat = true;
            while(repeat) {
                Console.WriteLine("Will you load a file ('File') or manually ('Manual') enter information? Type 'Finish' when you are finished entering data.");
                var input = Console.ReadLine();
                if (input == "File")
                {
                    var fileTransactions = FileInput.HandleFileInput();
                    transactions.AddRange(fileTransactions);
                }
                else if (input == "Manual")
                {
                    var transaction = UserInput.HandleUserInput();
                    transactions.Add(transaction);
                }
                else if (input == "Finish") 
                {
                    repeat = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'File' or 'Manual' or 'Finish'");
                }
            }
            Console.WriteLine("Here are estimated rates of your calls / texts / data usage");
            foreach (var transaction in transactions) {
                Console.WriteLine($"Your {transaction.Type} at {transaction.Time} for {transaction.DisplayDuration()} from number {transaction.PhoneNumber} has an estimated cost of {transaction.DisplayRate()}");
            }
        }
    }
}