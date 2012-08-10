using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace eProjectsSemIII.Configs
{
    public class GlobalInfo
    {
        public static decimal NumberRecordInPage
        {
            get
            {
                return Convert.ToDecimal(ConfigurationManager.AppSettings["NumberRecordInPage"]);
            }
        }
        public static int NumLinkPagingDisplay
        {
            get
            {
                return Convert.ToInt16(ConfigurationManager.AppSettings["NumberLinkPagingDisplay"]);
            }
        }
    }
}