using Uniftec.ProjetoWeb.SocialTec.Backend.Models;
using Uniftec.ProjetoWeb.SocialTec.Models;

namespace Uniftec.ProjetoWeb.SocialTec.Backend.Adapter
{
    public class UsuarioAdapter
    {
        public static UsuarioModel ExternalModelToModel(UsuarioExternalModel usuaExt)
        {
            var usuario = new UsuarioModel();

            usuario.Id = usuaExt.Id;
            usuario.Nome = usuaExt.Nome;
            usuario.Email = usuaExt.Email;
            usuario.Sobrenome = usuaExt.Sobrenome;
            usuario.FotoPerfil = usuaExt.FotoPerfil;

            usuario.Amigos = ArrayExternalModelToArrayModel(usuaExt.Amigos);

            return usuario;
        }

        public static List<UsuarioModel> ArrayExternalModelToArrayModel(List<UsuarioExternalModel> usuariosExt)
        {
            var usuarios = new List<UsuarioModel>();

            foreach (var usuarioExt in usuariosExt)
            {
                usuarios.Add(ExternalModelToModel(usuarioExt));
            }

            return usuarios;
        }
    }
}
