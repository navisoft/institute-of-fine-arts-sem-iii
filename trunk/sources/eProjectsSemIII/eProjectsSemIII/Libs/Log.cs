using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace eProjectsSemIII.Libs
{
    public class Log
    {
        private string path;
        private string page;

        public Log(string path, string page)
        {
            this.path = path;
            this.page = page;
        }
        public void WriteLog(string content)
        {
            StreamWriter objStreamWriter = new StreamWriter(path+"\\log\\log.log",true);
            objStreamWriter.WriteLine("------------------------------------" + DateTime.Now + "--------" + page + "----------------------------------");
            objStreamWriter.WriteLine(content);
            objStreamWriter.Flush();
            objStreamWriter.Close();
        }
    }
}