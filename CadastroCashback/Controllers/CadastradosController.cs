using Microsoft.AspNetCore.Mvc;

namespace CadastroCashback.Controllers
{
    public class CadastradosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }
    }
}
