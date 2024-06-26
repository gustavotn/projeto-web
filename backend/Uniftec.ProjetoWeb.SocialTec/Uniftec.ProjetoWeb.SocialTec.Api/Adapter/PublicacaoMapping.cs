using Uniftec.ProjetoWeb.SocialTec.Api.Models;
using Uniftec.ProjetoWeb.SocialTec.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Uniftec.ProjetoWeb.SocialTec.Api.Adapter
{
    public static class PublicacaoMapping
    {
        public static PublicacaoResponseModel ToModel(PublicacaoDto publicacao)
        {
            if (publicacao == null)
                return null;
            else
            {
                PublicacaoResponseModel publicacaoModel = new PublicacaoResponseModel();
                publicacaoModel.Id = publicacao.Id;
                publicacaoModel.Usuario = publicacao.Usuario;
                publicacaoModel.Descricao = publicacao.Descricao;
                publicacaoModel.DataPublicacao = publicacao.DataPublicacao;
                
                foreach (var midia in publicacao.Midias)
                {
                    string tipoConteudo;
                    if (midia.Extensao.Contains("mp4"))
                        tipoConteudo = "video/mp4";
                    else tipoConteudo = "image/png";

                    publicacaoModel.Midias.Add(new FileContentResult(midia.Midia, tipoConteudo));
                }

                return publicacaoModel;
            }
        }
        public static PublicacaoDto ToDto(PublicacaoRequestModel publicacao)
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
                
                foreach (var midia in publicacao.Midias)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        midia.CopyTo(memoryStream);
                        publicacaoDto.Midias.Add(new PublicacaoMidiaDto(memoryStream.ToArray(), Path.GetExtension(midia.FileName)));
                    }
                }

                return publicacaoDto;
            }
        }
    }
}
