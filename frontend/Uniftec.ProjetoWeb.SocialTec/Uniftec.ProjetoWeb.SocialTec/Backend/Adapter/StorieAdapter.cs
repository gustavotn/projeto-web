using Uniftec.ProjetoWeb.SocialTec.Backend.Models;
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
        public static StorieModel ExternalModelToModel(StorieExternalModel storieExt)
        {
            var storie = new StorieModel();

            storie.Id = storieExt.Id;
            storie.Usuario = new UsuarioStorie()
            {
                Id = storieExt.Usuario.Id,
                Nome = storieExt.Usuario.Nome,
            };
            storie.NumVisualização = storieExt.NumVisualização;
            storie.DataEnvio = storieExt.DataEnvio;
            storie.Situacao = storieExt.Situacao;
            storie.Conteudo = storieExt.Conteudo;

            return storie;
        }
        public static List<StorieModel> ArrayExternalModelToArrayModel(List<StorieExternalModel> storieExt)
        {
            var stories = new List<StorieModel>();

            foreach (var storie in storieExt)
            {
                stories.Add(ExternalModelToModel(storie));
            }

            return stories;
        }
    }
}
