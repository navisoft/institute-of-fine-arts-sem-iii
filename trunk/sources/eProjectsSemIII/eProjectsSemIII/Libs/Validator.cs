using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace eProjectsSemIII.Libs
{
    public static class Validator
    {
        public static bool ISAlias(string str)
        {
            string pattern = "^[a-z0-9]+[a-z-0-9]+[a-z0-9]+$";
            Regex myRegex = new Regex(pattern);
            return myRegex.IsMatch(str.ToLower());
        }
        public static bool ISEmail(string str)
        {
            Regex re = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (re.IsMatch(str))
                return true;
            else
                return false;
        }
        public static bool ISPhoneNumber(string str)
        {
            Regex re = new Regex(@"^[(]{0,1}[+]{0,1}[0-9+]{0,6}[)]{0,1}[0-9]{9,13}$");
            if (re.IsMatch(str))
                return true;
            else
                return false;
        }

        public static bool ISPrice(string str)
        {
            Regex re = new Regex(@"^[0-9]+(\.?[0-9])*(,?[0-9])*$");
            if (re.IsMatch(str))
                return true;
            else
                return false;
        }
    }
}