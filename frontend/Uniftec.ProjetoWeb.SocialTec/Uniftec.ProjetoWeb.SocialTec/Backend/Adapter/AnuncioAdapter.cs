using Uniftec.ProjetoWeb.SocialTec.Backend.Models;
using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Backend.Adapter
{
    public class AnuncioAdapter
    {
        public static AnuncioModel ToAnuncioModel(AnuncioCadastroModel anuncioCadastro)
        {
            return new()
            {
                UrlImagem = anuncioCadastro.UrlImagem,
                Link = anuncioCadastro.Link,
                Texto = anuncioCadastro.Texto
            };
        }
        public static AnuncioModel ExternalModelToModel(AnuncioExternalModel adExt)
        {
            var anuncio = new AnuncioModel();

            anuncio.Id = adExt.Id;
            anuncio.UrlImagem = adExt.UrlImagem;
            anuncio.Link = adExt.Link;
            anuncio.Texto = adExt.Texto;

            return anuncio;
        }

        public static List<AnuncioModel> ArrayExternalModelToArrayModel(List<AnuncioExternalModel> adsExt)
        {
            var anuncios = new List<AnuncioModel>();

            foreach (var ad in adsExt)
            {
                anuncios.Add(ExternalModelToModel(ad));
            }

            return anuncios;
        }
    }
}
