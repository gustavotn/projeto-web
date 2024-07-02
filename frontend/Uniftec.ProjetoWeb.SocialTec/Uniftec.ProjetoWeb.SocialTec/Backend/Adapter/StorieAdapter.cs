using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Backend.Adapter
{
    public class StorieAdapter
    {
        public static StorieModel ToStorieModel(StorieCadastroModel storieCadastro)
        {
            using (var ms = new MemoryStream())
            {
                storieCadastro.Conteudo.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return new()
                {
                    IdUsuario = storieCadastro.IdUsuario,
                    NumVisualização = storieCadastro.NumVisualização,
                    Situacao = storieCadastro.Situacao,
                    Conteudo = Convert.ToBase64String(fileBytes),
                };
            }
        }
    }
}
