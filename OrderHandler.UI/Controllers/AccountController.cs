using Microsoft.AspNetCore.Mvc;

namespace OrderHandler.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
