namespace Uniftec.ProjetoWeb.SocialTec.Api.Models
{
    public class PublicacaoRequestModel
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<IFormFile> Midias { get; set; }

        public PublicacaoRequestModel()
        {
            Midias = new List<IFormFile>();
        }
    }
}
