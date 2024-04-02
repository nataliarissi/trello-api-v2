using Trello.Models.Enums;

namespace Trello.Models.Requests.CardsRequests
{
    public class CardAlteracaoRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public TipoAssunto Assunto { get; set; }
        public EtiquetasCard Etiqueta { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
