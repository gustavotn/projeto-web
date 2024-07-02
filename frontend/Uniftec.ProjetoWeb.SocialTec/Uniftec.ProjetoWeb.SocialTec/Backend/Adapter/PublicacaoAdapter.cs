using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Backend.Adapter
{
    public class PublicacaoAdapter
    {
        public static PublicacaoModel ToPublicacaoModel(PublicacaoCadastroModel publicacaoCadastro)
        {
            List<IFormFile> midias = [];
            midias.Add(publicacaoCadastro.Midia);

            return new()
            {
                Usuario = publicacaoCadastro.IdUsuario,
                Descricao = publicacaoCadastro.Descricao,
                Midias = midias,
            };
        }
    }
}
