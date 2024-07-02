using Microsoft.AspNetCore.Mvc;

namespace Uniftec.ProjetoWeb.SocialTec.Backend.Models
{
    public class PublicacaoExternalModel
    {
        public Guid Id { get; set; }
        public Guid Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<PublicacaoMidiaExternalModel> Midias { get; set; }
    }
}
