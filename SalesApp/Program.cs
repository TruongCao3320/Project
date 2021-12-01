using Microsoft.Extensions.Configuration;
using SalesApp.Member;
using SalesApp.Oder;
using SalesApp.OderDetail;
using SalesApp.Product;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
          public static IConfiguration Configuration;
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("Account.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
