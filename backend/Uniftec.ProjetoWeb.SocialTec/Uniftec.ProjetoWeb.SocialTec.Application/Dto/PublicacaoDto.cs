using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniftec.ProjetoWeb.SocialTec.Application.Dto
{
    public class PublicacaoDto
    {
        public Guid Id { get; set; }
        //public Usuario Usuario { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<string> UrlsMidia { get; }

        public PublicacaoDto()
        {
            UrlsMidia = new List<string>();
        }
    }
}
