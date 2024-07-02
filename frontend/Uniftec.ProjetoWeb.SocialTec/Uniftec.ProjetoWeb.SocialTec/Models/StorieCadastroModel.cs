namespace Uniftec.ProjetoWeb.SocialTec.Models
{
    public class StorieCadastroModel
    {
        public Guid IdUsuario { get; set; }
        public UsuarioStorie Usuario { get; set; }
        public IFormFile Conteudo { get; set; }
        public int NumVisualização { get; set; }
        public int Situacao { get; set; }
    }
}
