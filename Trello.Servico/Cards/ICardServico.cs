using Trello.Models.Entidades;
using Trello.Models.Requests.CardsRequests;
using Trello.Models.RetornoGerais;

namespace Trello.Servico.Cards
{
    public interface ICardServico
    {
        ObterCardsRetorno ObterTodosCardsComComentario();

        Retorno<Card?> ObterCardCompletoPorId(int id);
        Retorno<List<Card>> ObterTodosCards();
        Retorno<bool> Cadastrar(CardCadastroRequest cardCadastro);
        Retorno<bool> Alterar(CardAlteracaoRequest cardAlteracao);
        Retorno<bool> Deletar(int id);
        Retorno<List<Card>> ObterTop();
        Retorno<List<Card>> ObterCardPorTitulo(string titulo);
        Retorno<List<Card>> ObterCardPorPalavraChave(string palavra);
    }
}
