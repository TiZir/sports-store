using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

    public class CLR_Tikhonov
    {

        public static bool PhoneNumber(string phoneNumber) 
        {
            string check = @"\d{11}";
            return Regex.IsMatch(phoneNumber, check);
        }

        public static string CheckUpper(string Word)
        {
            TextInfo w1 = CultureInfo.CurrentCulture.TextInfo;
            return w1.ToTitleCase(Word);
        }

    }
