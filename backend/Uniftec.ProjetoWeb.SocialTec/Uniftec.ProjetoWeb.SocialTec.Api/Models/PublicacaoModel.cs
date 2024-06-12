namespace Uniftec.ProjetoWeb.SocialTec.Api.Models
{
    public class PublicacaoModel
    {
        public Guid Id { get; set; }
        //public Usuario Usuario { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<string> UrlsMidia { get; }

        public PublicacaoModel()
        {
            UrlsMidia = new List<string>();
        }
    }
}
