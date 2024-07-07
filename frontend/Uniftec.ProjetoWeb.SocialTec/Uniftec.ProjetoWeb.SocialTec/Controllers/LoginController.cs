using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginData = new
            {
                email = model.Email,
                senha = model.Password
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://grupo3.neurosky.com.br/api/Usuario/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<CadastroViewModel>(responseContent);

                HttpContext.Session.SetString("IdUsuario", user.Id.ToString());
                HttpContext.Session.SetString("TipoUsuario", user.Tipo.ToString());
                HttpContext.Session.SetString("NomeUsuario", user.Nome+" "+user.Sobrenome);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login inválido");
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("IdUsuario", "");
            return RedirectToAction("Index", "Login");
        }
    }
}
