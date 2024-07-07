using Uniftec.ProjetoWeb.SocialTec.Backend.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Models
{
    public class HomeModel
    {
        public List<PublicacaoModel> Publicacoes { get; set; }
        public List<AnuncioModel> Anuncios { get; set; }
        public List<StorieModel> Stories { get; set; }
        public List<UsuarioModel> UsuariosSeguir { get; set; }
        public string IdUsuario {  get; set; }
        public string TipoUsuario { get; set; }
        public string FotoPerfilUsuario { get; set; }
    }
}
