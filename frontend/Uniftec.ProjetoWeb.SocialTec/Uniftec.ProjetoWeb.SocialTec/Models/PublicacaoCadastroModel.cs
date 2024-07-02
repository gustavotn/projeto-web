using Microsoft.AspNetCore.Mvc;

namespace Uniftec.ProjetoWeb.SocialTec.Models
{
    public class PublicacaoCadastroModel
    {
        public string Descricao { get; set; }

        public Guid IdUsuario { get; set; }

        public IFormFile Midia { get; set; }
    }
}
