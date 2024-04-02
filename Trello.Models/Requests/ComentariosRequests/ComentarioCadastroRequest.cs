using Trello.Models.Enums;

namespace Trello.Models.Requests.ComentariosRequests
{
    public class ComentarioCadastroRequest
    {
        public int IdCard { get; set; }
        public string CaixaTexto { get; set; }
        public int IdUsuario { get; set; }
        public QuantidadeEstrelas Estrelas { get; set; }
    }
}
