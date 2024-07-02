using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Uniftec.ProjetoWeb.SocialTec.Backend.Adapter;
using Uniftec.ProjetoWeb.SocialTec.Backend.HTTPClient;
using Uniftec.ProjetoWeb.SocialTec.Backend.Models;
using Uniftec.ProjetoWeb.SocialTec.Backend.Utils;
using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string idUsuarioLogado = this.HttpContext.Session.GetString("IdUsuario") ?? string.Empty;

            if (string.IsNullOrEmpty(idUsuarioLogado))
                throw new Exception("Não foi possível identificar o usuário logado.");

            var usuario = UsuarioAdapter.ExternalModelToModel(new APIHttpClient(Endpoints.GRUPO_3).Get<UsuarioExternalModel>("Usuario/" + idUsuarioLogado));

            var publicacoes = PublicacaoAdapter.ArrayExternalModelToArrayModel(new APIHttpClient(Endpoints.GRUPO_5).Get<List<PublicacaoExternalModel>>("Publicacao?idUsuario=" + idUsuarioLogado));

            foreach (var pub in publicacoes)
            {
                pub.Usuario = usuario;
            }

            foreach (var amigo in usuario.Amigos)
            {
                var publicacoesAmigo = PublicacaoAdapter.ArrayExternalModelToArrayModel(new APIHttpClient(Endpoints.GRUPO_5).Get<List<PublicacaoExternalModel>>("Publicacao?idUsuario=" + amigo.Id)); ;

                foreach (var pubAmigo in publicacoesAmigo)
                {
                    pubAmigo.Usuario = amigo;
                    publicacoes.Add(pubAmigo);
                }
            }

            return View(new HomeModel() { Publicacoes = publicacoes.OrderByDescending(p => p.DataPublicacao).ToList() });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
