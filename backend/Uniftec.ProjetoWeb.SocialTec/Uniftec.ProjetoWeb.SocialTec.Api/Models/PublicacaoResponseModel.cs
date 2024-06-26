using Microsoft.AspNetCore.Mvc;

namespace Uniftec.ProjetoWeb.SocialTec.Api.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoResponseModel
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<FileContentResult> Midias { get; set; }

        public PublicacaoResponseModel()
        {
            Midias = new List<FileContentResult>();
        }
    }
}
