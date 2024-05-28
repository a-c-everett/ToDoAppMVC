using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Todo.Models;
using Todo.Models.ViewModels;

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
        var todoListViewModel = GetTodos();
        return View(todoListViewModel);
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

    internal TodoViewModel GetTodos()
    {
        List<TodoItem> todoList = new();

        using (SqliteConnection connection = new SqliteConnection("Data Source=db.sqlite"))
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = $"SELECT * FROM Todo";

                using ( var reader = command.ExecuteReader() ){
                    if (reader.HasRows){
                        while (reader.Read()){
                            todoList.Add(
                                new TodoItem{
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                }
                            );
                        }

                    }
                    return new TodoViewModel{
                        TodoList = todoList
                    };
                    
                }
            }
        }
        
    }


    
    
}
