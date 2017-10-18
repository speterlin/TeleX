using System;

namespace Transaction
{
    public class Transaction
    {
        // Maybe add validations such as [Required] and [Range(0, 1000)] in the future as a double check to the Valdiations.cs
        public string Type;
        public int Duration;
        public DateTime Time;
        public string PhoneNumber;
        public string Location;
        public string DisplayDuration()
        {
            // string the adds minutes / kb / mb depending on transaction type
            var durationUnit = Type == "Call" ? "minute" : Type == "Text" ? "KB" : "MB";
            if (durationUnit == "minute" && Duration != 1) {
                durationUnit += "s";
            }
            return $"{Duration} {durationUnit}";
        }
        public string DisplayRate()
        {
            // dollar for now, maybe change
            return $"${EstimateRate()}";
        }
        public int EstimateRate()
        {
            var rate = new double();
            if (Type == "Call") {
                //per minute
                rate = 0.5;
            } else if (Type == "Text") {
                //per kb
                rate = 0.1;
            } else if (Type == "Data") {
                //per mb
                rate = 0.75;
            }
            // can add other factors for location, time etc.
            return (int)(rate * Duration);
        }
    }
}
