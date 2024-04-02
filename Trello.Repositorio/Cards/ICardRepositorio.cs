using Trello.Models.Entidades;
using Trello.Models.Requests.CardsRequests;

namespace Trello.Repositorio.Cards
{
    public interface ICardRepositorio
    {
        Card? ObterCardCompletoPorId(int id);
        List<Card> ObterTodosCards();
        bool Cadastrar(CardCadastroRequest cardCadastro);
        bool Alterar(CardAlteracaoRequest cardAlteracao);
        bool Deletar(int id);
        List<Card> ObterTop();
        List<Comentario> ObterComentariosPorIdCard(int idCard);
        List<Comentario> ObterComentarios();
        List<Card> ObterCardPorTitulo(string titulo);
        List<Card> ObterCardPorPalavraChave(string palavra);
    }
}
