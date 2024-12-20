using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web
{
    public class Validation
    {
        public string usr { get; set; }
        public string pass { get; set; }
        public string mail { get; set; }

        public static bool UsernameLength(string usr)
        {
            if (usr.Length < 3 || usr.Length > 50) return false;
            else return true;
        }

        public static bool PasswordLength(string pass)
        {
            if (pass.Length < 8 || pass.Length > 50) return false;
            else return true;
        }

        public static bool Password(string pass)
        {
            bool hasOneDigit = true, hasOneLetter = true;
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsLetter(pass[i]))
                {
                    hasOneLetter = true;
                    break;
                }
                else hasOneLetter = false;
            }
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsDigit(pass[i]))
                {
                    hasOneDigit = true;
                    break;
                }
                else hasOneDigit = false;
            }
            if (pass.Length < 8 || pass.Length > 50) return false;
            else if (hasOneLetter == false || hasOneDigit == false) return false;
            else return true;
        }

        public static bool Mail(string mail)
        {
            if (new EmailAddressAttribute().IsValid(mail)) return true;
            else return false;
        }
    }
}