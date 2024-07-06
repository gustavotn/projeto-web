using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Uniftec.ProjetoWeb.SocialTec.Models;


namespace Uniftec.ProjetoWeb.SocialTec.Controllers
{
    public class CadastroController : Controller
    {
        private readonly HttpClient _httpClient;

        public CadastroController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CadastroViewModel model)
        {
            model.FotoPerfil = "";
            model.Amigos = [];
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var cadastroData = new
            {
                id = model.Id,
                email = model.Email,
                nome = model.Nome,
                sobrenome = model.Sobrenome,
                senha = model.Senha,
                dataComemorativa = model.DataComemorativa,
                sexo = model.Sexo,
                bio = model.Bio,
                fotoPerfil = model.FotoPerfil,
                cidade = model.Cidade,
                uf = model.Uf,
                telefone = model.Telefone,
                documento = model.Documento,
                tipo = model.Tipo,
                amigos = model.Amigos
            };

            var content = new StringContent(JsonConvert.SerializeObject(cadastroData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://grupo3.neurosky.com.br/api/Usuario", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var userId = JsonConvert.DeserializeObject<string>(responseContent);

                HttpContext.Session.SetString("IdUsuario", userId);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar usuário");
                return View(model);
            }
        }
    }
}
