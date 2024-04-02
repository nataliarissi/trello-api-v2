using Trello.Models.Enums;

namespace Trello.Models.Requests.ComentariosRequests
{
    public class ComentarioAlteracaoRequest
    {
        public int Id { get; set; }
        public string CaixaTexto { get; set; }
        public QuantidadeEstrelas Estrelas { get; set; }
    }
}
