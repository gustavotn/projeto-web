using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniftec.ProjetoWeb.SocialTec.Domain.Entities;
using Uniftec.ProjetoWeb.SocialTec.Repository.Repository;

namespace Uniftec.ProjetoWeb.SocialTec.Test
{
    [TestClass]
    public class ProdutoRepositoryTest
    {
        [TestMethod]
        public void InserirTest()
        {
            string strConexao = "Server=pgsql.jmenzen.com.br;Port=5432;Database=jmenzen4;User Id=jmenzen4;Password='8N9;FLC?;@?I';";
            var publicacaoRepository = new PublicacaoRepository(strConexao);
            try
            {
                Publicacao publicacao = new Publicacao();
                publicacao.Id = Guid.NewGuid();
                publicacao.Usuario = "486af80f-af60-4a9c-b4a1-5ec64b0b89c1";
                publicacao.Descricao = "Teste descricao";
                publicacao.DataPublicacao = DateTime.Now;
                publicacao.AdicionaMidia("https://google.com.br");
                publicacaoRepository.Inserir(publicacao);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void AlterarTest()
        {
            string strConexao = "Server=pgsql.jmenzen.com.br;Port=5432;Database=jmenzen4;User Id=jmenzen4;Password='8N9;FLC?;@?I';";
            var publicacaoRepository = new PublicacaoRepository(strConexao); try
            {
                Publicacao publicacao = new Publicacao();
                publicacao.Id = Guid.Parse("2d4c583e-a51e-4c0b-b382-13217b1d86b5"); //Substituir por um ID existente
                publicacao.Usuario = "486af80f-af60-4a9c-b4a1-5ec64b0b89c1";
                publicacao.Descricao = "Teste alteracao";
                publicacao.DataPublicacao = DateTime.Now;
                publicacao.AdicionaMidia("https://www.google.com.br");
                publicacaoRepository.Alterar(publicacao);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTest()
        {
            string strConexao = "Server=pgsql.jmenzen.com.br;Port=5432;Database=jmenzen4;User Id=jmenzen4;Password='8N9;FLC?;@?I';";
            var publicacaoRepository = new PublicacaoRepository(strConexao);
            try
            {
                var publicacao = publicacaoRepository.Procurar(Guid.Parse("2d4c583e-a51e-4c0b-b382-13217b1d86b5")); //Substituir por um ID existente
                if (publicacao.Descricao == "Teste alteracao")
                {
                    Assert.IsTrue(true);
                }
                else
                {

                    Assert.IsTrue(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ProcurarTodosTest()
        {
            string strConexao = "Server=pgsql.jmenzen.com.br;Port=5432;Database=jmenzen4;User Id=jmenzen4;Password='8N9;FLC?;@?I';";
            var publicacaoRepository = new PublicacaoRepository(strConexao);
            try
            {
                var publicacoes = publicacaoRepository.ProcurarTodos("");
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
