using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

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

        public int[] ListID(string str)
        {
            string[] IDStr =  str.Split(',');
            int[] ID = new int[IDStr.Length];
            try
            {
                int i = 0;
                foreach (string id in IDStr)
                {
                    ID[i] = Convert.ToInt16(id);
                    i++;
                }
           }
           catch
           {

           }
            return ID;
        }
        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}