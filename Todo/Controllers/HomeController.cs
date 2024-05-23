using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Todo.Models;

namespace Todo.Controllers;

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

    public RedirectResult Insert(TodoItem todo)
    {   
        using (SqliteConnection connection = new SqliteConnection("Data Source=db.sqlite"))
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"INSERT INTO Todo (name) VALUES ('{todo.Name}')";

                try{
                    command.ExecuteNonQuery();
                }
                catch (Exception ex){
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        return Redirect("http://localhost:5023/");
    }


    
    
}
