using System;

namespace Transaction
{
    public class Validations
    {
        public static bool TypeIsValid (string type) {
            if (type == "Call" || type == "Text" || type == "Data") {
                return true;
            } else {
                return false;
            }   
        }
        public static bool DurationIsValid (string duration) {
            if (int.TryParse(duration, out int durationValue)) {
                if (durationValue >= 0 && durationValue <= 1000) {
                    return true;
                } else {
                    return false;
                }   
            } else {
                return false;
            }
        }   
        public static bool TimeIsValid (string time) {
            // check if time is not in the future, also ensure this is in valid time format dd:mm:yy hh:mm:ss
            if (DateTime.TryParse(time, out DateTime timeValue)) {
                if (timeValue < DateTime.Now) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
        public static bool PhoneNumberIsValid (string phoneNumber) {
            // has to be correct format with country code, for now just ensure that it's present, later can implement regex
            if (!String.IsNullOrEmpty(phoneNumber))  {
                return true;
            } else {
                return false;
            }
        }
        public static bool LocationIsValid (string location) {
            // optional field, need to implement check if location can be found on a map at later time
            return true;
        } 
    }
}
