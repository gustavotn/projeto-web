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
                return RedirectToAction("Index", "Login");

            var usuario = UsuarioAdapter.ExternalModelToModel(new APIHttpClient(Endpoints.GRUPO_3).Get<UsuarioExternalModel>("Usuario/" + idUsuarioLogado));

            var publicacoes = PublicacaoAdapter.ArrayExternalModelToArrayModel(new APIHttpClient(Endpoints.GRUPO_5).Get<List<PublicacaoExternalModel>>("Publicacao?idUsuario=" + idUsuarioLogado));

            var stories = StorieAdapter.ArrayExternalModelToArrayModel(new APIHttpClient(Endpoints.GRUPO_2).Get<List<StorieExternalModel>>("Storie/"));

            var anuncios = AnuncioAdapter.ArrayExternalModelToArrayModel(new APIHttpClient(Endpoints.GRUPO_1).Get<List<AnuncioExternalModel>>("Anuncio/"));

            var usuariosSeguir = UsuarioAdapter.ArrayExternalModelToArrayModel(new APIHttpClient(Endpoints.GRUPO_3).Get<List<UsuarioExternalModel>>("Usuario/"));

            List<Guid> curtidas = new List<Guid>();
            List<ListaCurtidasModel> listaCurtidas = new List<ListaCurtidasModel>();
            List<Guid> listaCurtidasUsuario = new List<Guid>();
            foreach (var pub in publicacoes)
            {
                curtidas = new APIHttpClient(Endpoints.GRUPO_4).Get<List<Guid>>("likes/post/" + pub.Id);
                listaCurtidas.Add(new ListaCurtidasModel()
                {
                    IdPost = pub.Id,
                    NumCurtidas = curtidas.Count,
                });
                if (curtidas.Any(curtida => curtida == Guid.Parse(idUsuarioLogado)))
                {
                    listaCurtidasUsuario.Add(pub.Id);
                }
                pub.Usuario = usuario;
            }

            foreach (var amigo in usuario.Amigos)
            {
                usuariosSeguir.RemoveAll(x => x.Id == amigo.Id);
                var publicacoesAmigo = PublicacaoAdapter.ArrayExternalModelToArrayModel(new APIHttpClient(Endpoints.GRUPO_5).Get<List<PublicacaoExternalModel>>("Publicacao?idUsuario=" + amigo.Id)); ;
                foreach (var pubAmigo in publicacoesAmigo)
                {
                    curtidas = new APIHttpClient(Endpoints.GRUPO_4).Get<List<Guid>>("likes/post/"+pubAmigo.Id);
                    listaCurtidas.Add(new ListaCurtidasModel()
                    {
                        IdPost = pubAmigo.Id,
                        NumCurtidas = curtidas.Count,
                    });
                    if (curtidas.Any(curtida => curtida == Guid.Parse(idUsuarioLogado)))
                    {
                        listaCurtidasUsuario.Add(pubAmigo.Id);
                    }
                    pubAmigo.Usuario = amigo;
                    publicacoes.Add(pubAmigo);
                }
            }

            return View(new HomeModel() {
                Publicacoes = publicacoes.OrderByDescending(p => p.DataPublicacao).ToList(),
                Stories = stories.OrderByDescending(s => s.DataEnvio).ToList(),
                UsuariosSeguir = usuariosSeguir.Take(10).ToList(),
                Anuncios = anuncios.Take(10).ToList(),
                ListaCurtidasUsuario = listaCurtidasUsuario,
                ListaCurtidas = listaCurtidas,
                IdUsuario = idUsuarioLogado,
                TipoUsuario = HttpContext.Session.GetString("TipoUsuario"),
                FotoPerfilUsuario = usuario.FotoPerfil,
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Seguir(Guid id)
        {
            Guid idUsuarioLogado = Guid.Parse(HttpContext.Session.GetString("IdUsuario"));
            CadastroViewModel usuarioSeguir = new APIHttpClient(Endpoints.GRUPO_3).Get<CadastroViewModel>("Usuario/" + id);
            CadastroViewModel usuarioLogado = new APIHttpClient(Endpoints.GRUPO_3).Get<CadastroViewModel>("Usuario/" + idUsuarioLogado);
            usuarioLogado.Amigos.Add(usuarioSeguir);

            var idUsuario = new APIHttpClient(Endpoints.GRUPO_3).Put("Usuario", Guid.Empty, usuarioLogado);
            return Json(usuarioSeguir.Id);
        }

        [HttpPost]
        public IActionResult Curtir(Guid idPost)
        {
            Guid idUsuarioLogado = Guid.Parse(HttpContext.Session.GetString("IdUsuario"));
            var curtidas = new APIHttpClient(Endpoints.GRUPO_4).Get<List<Guid>>("likes/post/" + idPost);
            if (curtidas.Any(curtida => curtida == idUsuarioLogado))
            {
                var post = new APIHttpClient(Endpoints.GRUPO_4).Post<CurtidaModel>("likes/post/" + idPost + "/" + idUsuarioLogado, new CurtidaModel()
                {
                    IdPost = idPost,
                    IdUsuario = idUsuarioLogado
                });
            }
            else
            {
                // retornando 500
                // var delete = new APIHttpClient(Endpoints.GRUPO_4).Delete<Guid>("likes/post/"+idPost+"/", idUsuarioLogado);
                var delete = "";
            }
            return Json(idPost);
        }
    }
}
