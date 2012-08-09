using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Libs
{
    public static class Paging
    {
        public static int numPage { get; set; }
        public static int numLinkDisplay { get; set; }
        public static int currentPage { get; set; }
        public static int GetPage(string page)
        {
            try
            {
                string[] strPage = page.Split('-');
                try
                {
                    return Convert.ToInt32(strPage[1]);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return 1;
            }
        }
        public static string GenerateLinkPaging(string url)
        {
            string linkDisplay = "";
            int i = 0;
            int pageDisplay = 0;
            double middleFloat = Convert.ToDouble(numLinkDisplay) / 2;
            int middle = Convert.ToInt16(Math.Ceiling(middleFloat));
            if (numPage > 1)
            {
                if (numPage > numLinkDisplay)
                {
                    if (currentPage > middle)
                    {
                        if (numPage - (currentPage - 1) >= middle)
                        {
                            for (i = (currentPage - middle); i < currentPage - 1; i++)
                            {
                                pageDisplay = i + 1;
                                linkDisplay += "<div class='link'><a href='/" + url + "/page-" + pageDisplay + "' class='link_click'" + pageDisplay + "'>" + pageDisplay + "</div></a>";
                            }
                            linkDisplay += "<div class='notlink'>" + currentPage + "</div>";
                            for (i = (currentPage * 1); i < (currentPage * 1 + middle - 1); i++)
                            {
                                pageDisplay = i + 1;
                                linkDisplay += "<div class='link'><a href='/" + url + "/page-" + pageDisplay + "' class='link_click'" + pageDisplay + "'>" + pageDisplay + "</div></a>";
                            }
                        }
                        else
                        {
                            for (i = (numPage - numLinkDisplay); i < numPage; i++)
                            {
                                pageDisplay = i + 1;
                                if (currentPage == pageDisplay)
                                {
                                    linkDisplay += "<div class='notlink'>" + pageDisplay + "</div>";
                                }
                                else
                                {
                                    linkDisplay += "<div class='link'><a href='/" + url + "/page-" + pageDisplay + "' class='link_click' id='current_page_" + pageDisplay + "'>" + pageDisplay + "</div></a>";
                                }
                            }
                        }
                    }
                    else
                    {
                        for (i = 0; i < numLinkDisplay; i++)
                        {
                            pageDisplay = i + 1;
                            if (currentPage == pageDisplay)
                            {
                                linkDisplay += "<div class='notlink'>" + pageDisplay + "</div>";
                            }
                            else
                            {
                                linkDisplay += "<div class='link'><a href='/" + url + "/page-" + pageDisplay + "' class='link_click'" + pageDisplay + "'>" + pageDisplay + "</div></a>";
                            }
                        }
                    }
                }
                else
                {
                    for (i = 0; i < numPage; i++)
                    {
                        pageDisplay = i + 1;
                        if (currentPage == pageDisplay)
                        {
                            linkDisplay += "<div class='notlink'>" + pageDisplay + "</div>";
                        }
                        else
                        {
                            linkDisplay += "<div class='link'><a href='/" + url + "/page-" + pageDisplay + "' class='link_click'" + pageDisplay + "'>" + pageDisplay + "</div></a>";
                        }
                    }
                }
            }
            return linkDisplay;
        }
    }
}