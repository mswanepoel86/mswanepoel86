using System;
using Pages = Module_Framework.Config.Pages;

namespace Module_Framework
{
    public static class Constants
    {
        public static string BaseUrl => "https://www.saucedemo.com";

        public static string BuildId { get; set; } = DateTime.Now.ToString("F");

        //Todo: set creds to use MS secrets, worked and started failing needs investigation 
        public static string SauceUser { get; set; } = "";

        public static string SauceAccessKey { get; set; } = "";

        public static Pages Pages{ get; set; }


    }
}
