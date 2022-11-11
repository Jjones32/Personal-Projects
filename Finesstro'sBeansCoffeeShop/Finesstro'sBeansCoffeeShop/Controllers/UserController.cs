using Finesstro_sBeansCoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;


namespace Finesstro_sBeansCoffeeShop.Controllers
{
    public class UserController : Controller
    {
        public List<User> Users { get; set; } = new List<User>();
        public IActionResult Index()
        {
            return View();
        }

        //This will show the initial blank form for the user to register
        public IActionResult Create()
        {
            return View();
        }

        //This action will deal with the form submission
        [HttpPost]
        public IActionResult Create(User user)
        {
            Users.Add(user);
            return RedirectToAction("Summary", user);
        }

        public IActionResult Summary(User user)
        {
            return View(user);
        }
    }
}
