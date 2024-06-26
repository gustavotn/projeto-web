using System;
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
        private string diretorioMidias;

        public PublicacaoApplication() 
        {
            string strConexao = "Server=pgsql.jmenzen.com.br;Port=5432;Database=jmenzen4;User Id=jmenzen4;Password='8N9;FLC?;@?I';";
            this.publicacaoRepository = new PublicacaoRepository(strConexao);

            this.diretorioMidias = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SocialTec", "Midias");

            if (!Directory.Exists(this.diretorioMidias))
                Directory.CreateDirectory(this.diretorioMidias);
        }

        public Guid Inserir(PublicacaoDto publicacao)
        {
            publicacao.Id = Guid.NewGuid();
            Publicacao pub = PublicacaoAdapter.ToDomain(publicacao);

            string diretorioRaizPub = Path.Combine(this.diretorioMidias, publicacao.Id.ToString());

            if (!Directory.Exists(diretorioRaizPub))
                Directory.CreateDirectory(diretorioRaizPub);

            foreach (var midia in publicacao.Midias)
            {
                string nomeArquivo = Guid.NewGuid().ToString();
                string caminhoCompletoArquivo = Path.Combine(diretorioRaizPub, nomeArquivo + midia.Extensao);

                File.WriteAllBytes(caminhoCompletoArquivo, midia.Midia);

                pub.AdicionaMidia(caminhoCompletoArquivo);
            }

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
            Publicacao pub = publicacaoRepository.Procurar(id);

            foreach (var url in pub.UrlsMidia)
            {
                File.Delete(url);

                try
                {
                    Directory.Delete(url.Replace(Path.GetFileName(url), string.Empty));
                }
                catch
                { }
            }

            publicacaoRepository.Excluir(id);
        }
        public PublicacaoDto Procurar(Guid id)
        {
            Publicacao pub = publicacaoRepository.Procurar(id);

            var pubDto = PublicacaoAdapter.ToDto(pub);

            foreach (var url in pub.UrlsMidia)
            {
                pubDto.Midias.Add(new PublicacaoMidiaDto(File.ReadAllBytes(url), Path.GetExtension(url)));
            }

            return pubDto;
        }
        public List<PublicacaoDto> ProcurarTodos(string idUsuario)
        {
            List<PublicacaoDto> publicacaoDto = new List<PublicacaoDto>();
            var publicacaoes = publicacaoRepository.ProcurarTodos(idUsuario);
            foreach(var pub in publicacaoes)
            {
                var pubDto = PublicacaoAdapter.ToDto(pub);

                foreach (var url in pub.UrlsMidia)
                {
                    pubDto.Midias.Add(new PublicacaoMidiaDto(File.ReadAllBytes(url), Path.GetExtension(url)));
                }

                publicacaoDto.Add(pubDto);
            }
            return publicacaoDto;
        }
    }
}
