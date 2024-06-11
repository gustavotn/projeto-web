using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniftec.ProjetoWeb.SocialTec.Application.Dto;
using Uniftec.ProjetoWeb.SocialTec.Domain.Entities;

namespace Uniftec.ProjetoWeb.SocialTec.Application.Adapter
{
    public static class PublicacaoAdapter
    {
        public static Publicacao ToDomain(PublicacaoDto publicacao)
        {
            if (publicacao == null)
                return null;
            else
            {
                Publicacao publicacaoDomain = new Publicacao();
                publicacaoDomain.Id = publicacao.Id;
                publicacaoDomain.Usuario = publicacao.Usuario;
                publicacaoDomain.Descricao = publicacao.Descricao;
                publicacaoDomain.DataPublicacao = publicacao.DataPublicacao;
                foreach(var url in publicacao.UrlsMidia)
                {
                    publicacaoDomain.AdicionaMidia(url);
                }
                return publicacaoDomain;
            }
        }
        public static PublicacaoDto ToDto(Publicacao publicacao)
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
