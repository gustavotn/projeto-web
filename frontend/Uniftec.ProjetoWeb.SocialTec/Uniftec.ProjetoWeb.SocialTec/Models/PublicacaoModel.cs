using Uniftec.ProjetoWeb.SocialTec.Backend.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Models
{
    public class PublicacaoModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Descricao { get; set; }
        public UsuarioModel Usuario { get; set;}
        public DateTime DataPublicacao { get; set; }
        public List<PublicacaoMidiaExternalModel> Midias { get; set; }
    }
}
