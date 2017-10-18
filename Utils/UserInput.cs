using System;
using System.Linq;
using Transaction;

namespace Utils
{
    public static class UserInput
    {
        public static Transaction.Transaction HandleUserInput () {
            var transaction = new Transaction.Transaction();
            var repeat = true;
            while (repeat) {
                Console.WriteLine("Is this a call, text, or data type?");
                var type = Console.ReadLine();
                if (Transaction.Validations.TypeIsValid(type)) {
                    repeat = false;
                    transaction.Type = type;
                } else {
                    Console.WriteLine("Please enter 'Call', 'Text', or 'Data'");
                }
            }
            repeat = true;
            while (repeat)
            {
                var msg = "";
                if (transaction.Type == "Call") { msg = "How many minutes was the call?"; }
                else if (transaction.Type == "Text") { msg = "How many KB was the text?"; }
                else if (transaction.Type == "Data") { msg = "How many MB was used in the data transaction?"; }
                Console.WriteLine(msg);
                var duration = Console.ReadLine();
                if (Transaction.Validations.DurationIsValid(duration)) 
                {
                    repeat = false;
                    transaction.Duration = int.Parse(duration);
                }
                else
                {
                    Console.WriteLine("Please enter a positive integer value between 0 and 1000");
                }
            }
            repeat = true;
            while (repeat)
            {
                Console.WriteLine($"At what time did the {transaction.Type} happen?");
                var time = Console.ReadLine();
                if (Transaction.Validations.TimeIsValid(time)) 
                {
                    repeat = false;
                    transaction.Time = DateTime.Parse(time);
                }
                else
                {
                    Console.WriteLine("Please enter a valid date and time in the past");
                }
            }
            repeat = true;
            while (repeat)
            {
                Console.WriteLine($"What is the phone number associated with the {transaction.Type}?");
                var phoneNumber = Console.ReadLine();
                if (Transaction.Validations.PhoneNumberIsValid(phoneNumber))
                {
                    repeat = false;
                    transaction.PhoneNumber = phoneNumber;
                }
                else
                {
                    Console.WriteLine("Please enter a valid phone number");
                }
            }
            repeat = true;
            while (repeat)
            {
                Console.WriteLine($"What is the location of the {transaction.Type}? You can also skip this question by typing 'Skip'");
                var location = Console.ReadLine();
                if (location == "Skip")
                {
                    repeat = false;
                    break;
                }
                else if (Transaction.Validations.LocationIsValid(location))
                {
                    repeat = false;
                    transaction.Location = location;
                }
                else
                {
                    Console.WriteLine("Please enter a valid location or type 'Skip' to skip this input");
                }
            }
            // maybe add a commit confirmation or a way for users to go back on previous questions
            return transaction;
        }
    }
}
