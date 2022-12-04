using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using TP3F.Models;

namespace TP3F.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            Debug.WriteLine("Hello World !!! .... ");
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\NaimaAttia\\Downloads\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                      //  DateTime date_birth = Convert.ToDateTime(reader["date_birth"].ToString());
                        Debug.WriteLine("id = {0} first_name = {1}  last_name = {2}  email={3}  image= {4}  country= {5} ", id, first_name, last_name, email, image, country/*,date_birth*/);
                    }
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}