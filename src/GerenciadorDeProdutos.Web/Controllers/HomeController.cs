using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProdutos.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
