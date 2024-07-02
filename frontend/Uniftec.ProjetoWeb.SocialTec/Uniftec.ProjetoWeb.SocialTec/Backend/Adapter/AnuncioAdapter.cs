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
    }
}
