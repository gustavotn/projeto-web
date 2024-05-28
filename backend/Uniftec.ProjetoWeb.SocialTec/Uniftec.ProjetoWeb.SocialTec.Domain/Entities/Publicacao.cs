using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniftec.ProjetoWeb.SocialTec.Domain.Entities
{
    public class Publicacao
    {
        public Guid Id { get; set; }
        //public Usuario Usuario { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<String> UrlMidia { get; }

        public Publicacao()
        {
            this.Id = Guid.NewGuid();
            this.Usuario = string.Empty;
            this.Descricao = string.Empty;
            this.DataPublicacao = DateTime.Now;
            this.UrlMidia = new List<String>();
        }
        public void AdicionaMidia(String Url)
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new Exception("A URL não foi informada.");
            }
            this.UrlMidia.Add(Url);
        }
    }
}
