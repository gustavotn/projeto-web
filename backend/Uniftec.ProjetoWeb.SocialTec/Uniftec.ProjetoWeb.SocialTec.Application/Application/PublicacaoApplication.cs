﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniftec.ProjetoWeb.SocialTec.Application.Adapter;
using Uniftec.ProjetoWeb.SocialTec.Application.Dto;
using Uniftec.ProjetoWeb.SocialTec.Domain.Entities;
using Uniftec.ProjetoWeb.SocialTec.Repository.Repository;

namespace Uniftec.ProjetoWeb.SocialTec.Application.Application
{
    public class PublicacaoApplication
    {
        private PublicacaoRepository publicacaoRepository;
        public PublicacaoApplication() 
        {
            string strConexao = "";
            this.publicacaoRepository = new PublicacaoRepository(strConexao);
        }

        public Guid Inserir(PublicacaoDto publicacao)
        {
            Publicacao pub = PublicacaoAdapter.ToDomain(publicacao);
            pub.Id = Guid.NewGuid();
            publicacaoRepository.Inserir(pub);
            return pub.Id;
        }
        public Guid Alterar(PublicacaoDto publicacao)
        {
            Publicacao pub = PublicacaoAdapter.ToDomain(publicacao);
            publicacaoRepository.Alterar(pub);
            return pub.Id;
        }
        public void Excluir(Guid id)
        {
            publicacaoRepository.Excluir(id);
        }
        public PublicacaoDto Procurar(Guid id)
        {
            Publicacao pub = publicacaoRepository.Procurar(id);
            return PublicacaoAdapter.ToDto(pub);
        }
        public List<PublicacaoDto> ProcurarTodos()
        {
            List<PublicacaoDto> publicacaoDto = new List<PublicacaoDto>();
            var publicacaoes = publicacaoRepository.ProcurarTodos();
            foreach(var pub in publicacaoes)
            {
                publicacaoDto.Add(PublicacaoAdapter.ToDto(pub));
            }
            return publicacaoDto;
        }
    }
}