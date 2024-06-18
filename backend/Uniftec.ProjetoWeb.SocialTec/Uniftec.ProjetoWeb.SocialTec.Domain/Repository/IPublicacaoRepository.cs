using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniftec.ProjetoWeb.SocialTec.Domain.Entities;

namespace Uniftec.ProjetoWeb.SocialTec.Domain.Repository
{
    public interface IPublicacaoRepository
    {
        void Inserir(Publicacao publicacao);
        void Alterar(Publicacao publicacao);

        void Excluir(Guid id);
        Publicacao Procurar(Guid id);
        List<Publicacao> ProcurarTodos(string idUsuario);
    }
}
