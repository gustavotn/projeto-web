using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniftec.ProjetoWeb.SocialTec.Application.Dto
{
    public class PublicacaoMidiaDto
    {
        public PublicacaoMidiaDto() { }
        public PublicacaoMidiaDto(byte[] midia, string extensao)
        {
            this.Midia = midia;
            this.Extensao = extensao;
        }
        public byte[] Midia { get; set; }
        public string Extensao { get; set; }
    }
}
