using Npgsql;
using NpgsqlTypes;
using Uniftec.ProjetoWeb.SocialTec.Domain.Entities;
using Uniftec.ProjetoWeb.SocialTec.Domain.Repository;

namespace Uniftec.ProjetoWeb.SocialTec.Repository.Repository
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private string strConexao;
        
        public PublicacaoRepository(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public void Alterar(Publicacao publicacao)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE public.publicacao SET usuario=@usuario, descricao=@descricao, datapublicacao=@datapublicacao WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", publicacao.Id);
                    cmd.Parameters.AddWithValue("usuario", publicacao.Usuario);
                    cmd.Parameters.AddWithValue("descricao", publicacao.Descricao);
                    cmd.Parameters.AddWithValue("datapublicacao", DateTime.Now);
                    Console.WriteLine(cmd.ExecuteNonQuery());

                    if (publicacao.UrlsMidia.Count != 0)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "Delete from publicacaomidia where idpublicacao=@id";
                        cmd.Parameters.AddWithValue("id", publicacao.Id);
                        cmd.ExecuteNonQuery();

                        foreach (var midia in publicacao.UrlsMidia)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO public.publicacaomidia 
                                                (idpublicacao, id, url)
                                          VALUES(@idpublicacao, @id, @url)";
                            cmd.Parameters.AddWithValue("idpublicacao", publicacao.Id);
                            cmd.Parameters.AddWithValue("id", Guid.NewGuid());
                            cmd.Parameters.AddWithValue("url", midia);
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from publicacaomidia where idpublicacao=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    cmd.CommandText = "Delete from publicacao where id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(Publicacao publicacao)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO public.publicacao (id, usuario, descricao, datapublicacao) values(@id, @usuario, @descricao, @datapublicacao)";
                    cmd.Parameters.AddWithValue("id", publicacao.Id);
                    cmd.Parameters.AddWithValue("usuario", publicacao.Usuario);
                    cmd.Parameters.AddWithValue("descricao", publicacao.Descricao);
                    cmd.Parameters.AddWithValue("datapublicacao", publicacao.DataPublicacao);
                    cmd.ExecuteNonQuery();

                    foreach (var midia in publicacao.UrlsMidia)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = @"INSERT INTO public.publicacaomidia 
                                                (idpublicacao, id, url)
                                          VALUES(@idpublicacao, @id, @url)";
                        cmd.Parameters.AddWithValue("idpublicacao", publicacao.Id);
                        cmd.Parameters.AddWithValue("id", Guid.Parse(Path.GetFileName(midia).Replace(Path.GetExtension(midia), string.Empty)));
                        cmd.Parameters.AddWithValue("url", midia);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public Publicacao Procurar(Guid id)
        {
            Publicacao publicacao = new Publicacao();

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Select id, usuario, descricao, datapublicacao from publicacao where id=@id";
                    cmd.Parameters.AddWithValue("id", id);
                    var leitor = cmd.ExecuteReader();
                    while (leitor.Read())
                    {
                        publicacao = new Publicacao();
                        publicacao.Id = Guid.Parse(leitor["id"].ToString());
                        publicacao.Usuario = leitor["usuario"].ToString();
                        publicacao.Descricao = leitor["descricao"].ToString();
                        publicacao.DataPublicacao = DateTime.Parse(leitor["datapublicacao"]?.ToString());
                    }
                    leitor.Close();
                    cmd.CommandText = "select * from publicacaomidia where idpublicacao=@id";
                    leitor = cmd.ExecuteReader();
                    while (leitor.Read())
                    {
                        publicacao.UrlsMidia.Add(leitor["url"].ToString());
                    }
                }
            }

            return publicacao;
        }

        public List<Publicacao> ProcurarTodos(string idUsuario)
        {
            var publicacoes = new List<Publicacao>();

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Select id, descricao, usuario, datapublicacao from publicacao where usuario=@usuario ORDER BY datapublicacao DESC";
                    cmd.Parameters.AddWithValue("usuario", idUsuario);

                    var leitor = cmd.ExecuteReader();
                    while (leitor.Read())
                    {
                        var publicacao = new Publicacao();

                        publicacao.Id = Guid.Parse(leitor["id"].ToString());
                        publicacao.Usuario = leitor["usuario"].ToString();
                        publicacao.Descricao = leitor["descricao"].ToString();
                        publicacao.DataPublicacao = DateTime.Parse(leitor["datapublicacao"]?.ToString());

                        publicacoes.Add(publicacao);
                    }

                    leitor.Close();

                    foreach (var publicacao in publicacoes)
                    {
                        cmd.CommandText = "select * from publicacaomidia where idpublicacao=@id";
                        cmd.Parameters.AddWithValue("id", publicacao.Id);
                        leitor = cmd.ExecuteReader();
                        while (leitor.Read())
                        {
                            publicacao.UrlsMidia.Add(leitor["url"].ToString());
                        }
                        leitor.Close();
                        cmd.Parameters.Clear();
                    }

                    leitor.Close();
                }
            }

            return publicacoes;
        }
    }
}
