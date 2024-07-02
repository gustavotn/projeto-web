using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using Uniftec.ProjetoWeb.SocialTec.Backend.Models;
using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Backend.Adapter
{
    public class PublicacaoAdapter
    {
        public static PublicacaoExternalModel ToPublicacaoModel(PublicacaoCadastroModel publicacaoCadastro)
        {
            List<IFormFile> midias = [];

            return new()
            {
                Usuario = publicacaoCadastro.IdUsuario,
                Descricao = publicacaoCadastro.Descricao,
                //Midias = midias,
            };
        }

        public static PublicacaoModel ExternalModelToModel(PublicacaoExternalModel pubExt)
        {
            var publicacao = new PublicacaoModel();

            publicacao.Id = pubExt.Id;
            publicacao.IdUsuario = pubExt.Usuario;
            publicacao.Descricao = pubExt.Descricao;
            publicacao.DataPublicacao = pubExt.DataPublicacao;
            publicacao.Midias = pubExt.Midias;

            return publicacao;
        }

        public static List<PublicacaoModel> ArrayExternalModelToArrayModel(List<PublicacaoExternalModel> pubsExt)
        {
            var publicacoes = new List<PublicacaoModel>();

            foreach (var pub in pubsExt)
            {
                publicacoes.Add(ExternalModelToModel(pub));
            }
           
            return publicacoes;
        }
    }
}
