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
            string strConexao = ""; //Incluir string de conexão
            var publicacaoRepository = new PublicacaoRepository(strConexao);
            try
            {
                Publicacao publicacao = new Publicacao();
                publicacao.Id = Guid.NewGuid();
                publicacao.Usuario = "Gabriel";
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
            string strConexao = ""; //Incluir string de conexão
            var publicacaoRepository = new PublicacaoRepository(strConexao); try
            {
                Publicacao publicacao = new Publicacao();
                publicacao.Id = Guid.NewGuid(); //Substituir por um ID existente
                publicacao.Usuario = "Jorge";
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
            string strConexao = ""; //Incluir string de conexão
            var publicacaoRepository = new PublicacaoRepository(strConexao);
            try
            {
                var publicacao = publicacaoRepository.Procurar(Guid.NewGuid()); //Substituir por um ID existente
                if (publicacao.Descricao == "Teste descricao")
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
            string strConexao = ""; //Incluir string de conexão
            var publicacaoRepository = new PublicacaoRepository(strConexao);
            try
            {
                var publicacoes = publicacaoRepository.ProcurarTodos();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
