using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace eProjectsSemIII.Libs
{
    public class Strings
    {
        public string Capacital(string str)
        {
            if (str != null)
            {
                StringBuilder sb = new StringBuilder(str);
                sb[0] = Char.ToUpper(sb[0]);
                return sb.ToString();
            }
            else
            {
                return "";
            }
        }

    }
}