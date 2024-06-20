using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Todo.Models;
using Todo.Models.ViewModels;

namespace Todo.Controllers;

public class LoginController : Controller
{
    // Existing actions

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ShowMyView()
    {
        return View("LoginView"); 
    }
}