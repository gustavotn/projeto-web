namespace Uniftec.ProjetoWeb.SocialTec.Backend.Models
{
    public class UsuarioExternalModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string FotoPerfil { get; set; }
        public List<UsuarioExternalModel> Amigos { get; set; }
    }
}
