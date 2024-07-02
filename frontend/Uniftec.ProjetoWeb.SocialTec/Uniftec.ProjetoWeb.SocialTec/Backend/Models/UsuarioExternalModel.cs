namespace Uniftec.ProjetoWeb.SocialTec.Backend.Models
{
    public class UsuarioExternalModel
    {
        //"id": "cc0cff45-c028-4b2e-b0c1-e3250132c7f9",
        //"email": "eder@eder.comu",
        //"nome": "eder",
        //"sobrenome": "string",
        //"senha": "eder",
        //"dataComemorativa": "2024-06-25T00:00:00",
        //"sexo": 0,
        //"bio": "string",
        //"fotoPerfil": "",
        //"cidade": "La longe",
        //"uf": 1,
        //"telefone": "string",
        //"documento": "string",
        //"tipo": 1,
        //"amigos": []
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string FotoPerfil { get; set; }
        public List<UsuarioExternalModel> Amigos { get; set; }
    }
}
