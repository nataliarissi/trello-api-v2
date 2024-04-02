using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trello.Models.Entidades;
using Trello.Models.Requests.CardsRequests;
using Trello.Models.RetornoGerais;
using Trello.Servico.Cards;

namespace Trello.V2.API.Controllers
{
    [Route("/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardServico _servico;

        public CardsController(ICardServico servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Route("/{id}")]
        public Retorno<Card?> ObterCardCompletoPorId(int id)
        {
            return _servico.ObterCardCompletoPorId(id);
        }

        [HttpGet("/obterTodosCards")]
        public Retorno<List<Card>> ObterTodosCards()
        {
            return _servico.ObterTodosCards();
        }

        [HttpPost("/cadastrar")]
        public Retorno<bool> CadastrarCard([FromBody] CardCadastroRequest cardCadastro)
        {
            return _servico.Cadastrar(cardCadastro);
        }

        [HttpPut("/alterar")]
        public Retorno<bool> AlterarDadosCard([FromBody] CardAlteracaoRequest cardAlteracao)
        {
            return _servico.Alterar(cardAlteracao);
        }

        [HttpDelete("/deletar")]
        public Retorno<bool> Deletar(int id)
        {
            return _servico.Deletar(id);
        }

        [HttpGet("/top")]
        public Retorno<List<Card>> ObterTop()
        {
            return _servico.ObterTop();
        }

        [HttpGet("/obterCards")]
        public ObterCardsRetorno ObterCards()
        {
            return _servico.ObterTodosCardsComComentario();
        }

        [HttpGet("/obterCardPorTitulo")]
        public Retorno<List<Card>> ObterCardPorTitulo(string titulo)
        {
            return _servico.ObterCardPorTitulo(titulo);
        }

        [HttpGet("/obterCardPorPalavraChave")]
        public Retorno<List<Card>> ObterCardPorPalavraChave(string palavra)
        {
            return _servico.ObterCardPorPalavraChave(palavra);
        }
    }
}
//[HttpGet("obterPalavraChave")]
//public List<string> ObterPalavraChave()
//{
//    return _repositorio.;
//}