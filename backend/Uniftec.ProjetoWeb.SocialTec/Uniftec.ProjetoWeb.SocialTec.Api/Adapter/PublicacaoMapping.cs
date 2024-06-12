using Uniftec.ProjetoWeb.SocialTec.Api.Models;
using Uniftec.ProjetoWeb.SocialTec.Application.Dto;

namespace Uniftec.ProjetoWeb.SocialTec.Api.Adapter
{
    public static class PublicacaoMapping
    {
        public static PublicacaoModel ToModel(PublicacaoDto publicacao)
        {
            if (publicacao == null)
                return null;
            else
            {
                PublicacaoModel publicacaoModel = new PublicacaoModel();
                publicacaoModel.Id = publicacao.Id;
                publicacaoModel.Usuario = publicacao.Usuario;
                publicacaoModel.Descricao = publicacao.Descricao;
                publicacaoModel.DataPublicacao = publicacao.DataPublicacao;
                foreach (var url in publicacao.UrlsMidia)
                {
                    publicacaoModel.UrlsMidia.Add(url);
                }
                return publicacaoModel;
            }
        }
        public static PublicacaoDto ToDto(PublicacaoModel publicacao)
        {
            if (publicacao == null)
                return null;
            else
            {
                PublicacaoDto publicacaoDto = new PublicacaoDto();
                publicacaoDto.Id = publicacao.Id;
                publicacaoDto.Usuario = publicacao.Usuario;
                publicacaoDto.Descricao = publicacao.Descricao;
                publicacaoDto.DataPublicacao = publicacao.DataPublicacao;
                foreach (var url in publicacao.UrlsMidia)
                {
                    publicacaoDto.UrlsMidia.Add(url);
                }
                return publicacaoDto;
            }
        }
    }
}
