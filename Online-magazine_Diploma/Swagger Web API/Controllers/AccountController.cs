using Microsoft.AspNetCore.Mvc;

namespace Swagger_Web_API.Controllers
{
    public class AccountController : Controller
    {

        /// <summary>
        /// Авторизация пользователя (Login)
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
