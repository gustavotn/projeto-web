using Microsoft.AspNetCore.Mvc;
using Uniftec.ProjetoWeb.SocialTec.Backend.Adapter;
using Uniftec.ProjetoWeb.SocialTec.Backend.HTTPClient;
using Uniftec.ProjetoWeb.SocialTec.Backend.Models;
using Uniftec.ProjetoWeb.SocialTec.Backend.Utils;
using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Controllers
{
    public class PublicacaoController : Controller
    {
        [HttpPost]
        public IActionResult CriarPublicacao(PublicacaoCadastroModel publicacaoCadastro)
        {
            var userId = HttpContext.Session.GetString("IdUsuario");
            publicacaoCadastro.IdUsuario = Guid.Parse(userId);
            var publicacaoModel = PublicacaoAdapter.ToPublicacaoModel(publicacaoCadastro);
            publicacaoModel.DataPublicacao = DateTime.Now;

            var id = new APIHttpClient(Endpoints.GRUPO_5).Post("Publicacao?Usuario=" + publicacaoModel.Usuario + "&Descricao=" + publicacaoModel.Descricao + "&DataPublicacao=" + publicacaoModel.DataPublicacao.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), publicacaoModel);

            return RedirectToAction("Index","Home");

        }

        [HttpPost]
        public IActionResult CriarAnuncio(AnuncioCadastroModel anuncioCadastro)
        {
            var anuncioModel = AnuncioAdapter.ToAnuncioModel(anuncioCadastro);

            var id = new APIHttpClient(Endpoints.GRUPO_1).Post("Anuncio?UrlImagem=" + anuncioModel.UrlImagem + "&Link=" + anuncioModel.Link + "&Texto=" + anuncioModel.Texto, anuncioModel);

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public IActionResult CriarStorie(StorieCadastroModel storieCadastro)
        {
            var userId = HttpContext.Session.GetString("IdUsuario");
            
            storieCadastro.IdUsuario = Guid.Parse(userId);
            var storieModel = StorieAdapter.ToStorieModel(storieCadastro);
            storieModel.Usuario = new UsuarioStorie();
            storieModel.Usuario.Id = Guid.Parse(userId);
            storieModel.Usuario.Nome = HttpContext.Session.GetString("NomeUsuario"); ;
            storieModel.DataEnvio = DateTime.Now;
            storieModel.NumVisualização = 0;
            storieModel.Situacao = 1;

            var id = new APIHttpClient(Endpoints.GRUPO_2).Post("Storie?IdUsuario=" + storieModel.IdUsuario + "&DataEnvio=" + storieModel.DataEnvio.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + "&NumVisualização=" + storieModel.NumVisualização + "&Situacao=" + storieModel.Situacao, storieModel);

            return RedirectToAction("Index", "Home");

        }
    }
}
