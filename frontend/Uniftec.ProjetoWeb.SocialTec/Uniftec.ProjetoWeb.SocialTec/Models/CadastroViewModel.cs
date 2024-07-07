using System.ComponentModel.DataAnnotations;

namespace Uniftec.ProjetoWeb.SocialTec.Models
{
    public class CadastroViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataComemorativa { get; set; }

        [Required]
        public int Sexo { get; set; }

        public string Bio { get; set; }

        public string? FotoPerfil { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public int Uf { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Documento { get; set; }

        [Required]
        public int Tipo { get; set; }

        public List<CadastroViewModel>? Amigos { get; set; }

    }
}
