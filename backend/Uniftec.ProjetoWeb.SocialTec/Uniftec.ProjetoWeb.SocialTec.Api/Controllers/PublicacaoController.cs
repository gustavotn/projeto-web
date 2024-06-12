using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Uniftec.ProjetoWeb.SocialTec.Api.Adapter;
using Uniftec.ProjetoWeb.SocialTec.Api.Models;
using Uniftec.ProjetoWeb.SocialTec.Application.Application;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Uniftec.ProjetoWeb.SocialTec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PublicacaoModel> Get()
        {
            List<PublicacaoModel> publicacoesModel = new List<PublicacaoModel>();
            PublicacaoApplication app = new PublicacaoApplication();
            var publicacoes = app.ProcurarTodos();
            foreach(var publicacao in publicacoes)
            {
                publicacoesModel.Add(PublicacaoMapping.ToModel(publicacao));
            }
            return publicacoesModel.ToArray();
        }
        [HttpGet("{id:Guid}")]
        public PublicacaoModel Get(Guid id) 
        {
            PublicacaoApplication app = new PublicacaoApplication();
            var publicacao = app.Procurar(id);
            return PublicacaoMapping.ToModel(publicacao);
        }
        [HttpPost]
        public Guid Post(PublicacaoModel publicacao)
        {
            PublicacaoApplication app = new PublicacaoApplication();
            return app.Inserir(PublicacaoMapping.ToDto(publicacao));
        }
        [HttpPut]
        public Guid Put(PublicacaoModel publicacao)
        {
            PublicacaoApplication app = new PublicacaoApplication();
            return app.Alterar(PublicacaoMapping.ToDto(publicacao));
        }
        [HttpDelete]
        public void Delete(Guid id)
        {
            PublicacaoApplication app = new PublicacaoApplication();
            app.Excluir(id);
        }
    }
}
