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
    }
}