namespace Uniftec.ProjetoWeb.SocialTec.Models
{
    public class StorieModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public UsuarioStorie Usuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public int NumVisualização {  get; set; }
        public int Situacao { get; set; }
    }
}
