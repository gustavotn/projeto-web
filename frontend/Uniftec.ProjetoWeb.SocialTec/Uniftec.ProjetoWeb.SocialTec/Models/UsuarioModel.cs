namespace Uniftec.ProjetoWeb.SocialTec.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string FotoPerfil { get; set; }
        public List<UsuarioModel> Amigos { get; set; }
    }
}
