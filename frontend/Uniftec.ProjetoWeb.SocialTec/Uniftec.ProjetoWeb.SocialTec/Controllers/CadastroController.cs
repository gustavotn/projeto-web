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

        public HttpClient Get_httpClient()
        {
            return _httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> Index(CadastroViewModel model, HttpClient _httpClient)
        {
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
                return RedirectToAction("Index", "Perfil");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar usuário");
                return View(model);
            }
        }
    }
}
