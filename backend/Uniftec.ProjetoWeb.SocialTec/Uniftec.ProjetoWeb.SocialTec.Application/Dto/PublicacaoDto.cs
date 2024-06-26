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
        public List<PublicacaoMidiaDto> Midias { get; }

        public PublicacaoDto()
        {
            Midias = new List<PublicacaoMidiaDto>();
        }
    }
}
