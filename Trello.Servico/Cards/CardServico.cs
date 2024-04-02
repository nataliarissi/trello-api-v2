using Trello.Models.Entidades;
using Trello.Models.Enums;
using Trello.Models.Requests.CardsRequests;
using Trello.Models.RetornoGerais;
using Trello.Repositorio.Cards;

namespace Trello.Servico.Cards
{
    public class CardServico : ICardServico
    {
        private readonly ICardRepositorio _repositorio;
        public CardServico(ICardRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ObterCardsRetorno ObterTodosCardsComComentario()
        {
            var retornoCards = new ObterCardsRetorno();

            var cards = _repositorio.ObterTodosCards();

            retornoCards.Streamer = cards.FirstOrDefault(x => x.Categoria == "Streamer");
            retornoCards.Anime = cards.FirstOrDefault(x => x.Categoria == "Anime");
            retornoCards.Tecnologia = cards.FirstOrDefault(x => x.Categoria == "Tecnologia");
            retornoCards.Jogo = cards.FirstOrDefault(x => x.Categoria == "Jogo");
            retornoCards.Estudo = cards.FirstOrDefault(x => x.Categoria == "Estudo");

            var comentarios = _repositorio.ObterComentarios();

            var comentariosStreamer = comentarios.Where(x => x.IdCard == retornoCards.Streamer.Id).ToList();
            var comentariosAnime = comentarios.Where(x => x.IdCard == retornoCards.Anime.Id).ToList();
            var comentariosJogo = comentarios.Where(x => x.IdCard == retornoCards.Jogo.Id).ToList();
            var comentariosTecnologia = comentarios.Where(x => x.IdCard == retornoCards.Tecnologia.Id).ToList();
            var comentariosEstudo = comentarios.Where(x => x.IdCard == retornoCards.Estudo.Id).ToList();

            foreach (var comentario in comentariosStreamer)
            {
                retornoCards.Streamer.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosAnime)
            {
                retornoCards.Anime.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosJogo)
            {
                retornoCards.Jogo.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosTecnologia)
            {
                retornoCards.Tecnologia.Comentarios.Add(comentario);
            }

            foreach (var comentario in comentariosEstudo)
            {
                retornoCards.Estudo.Comentarios.Add(comentario);
            }

            return retornoCards;
        }

        public Retorno<Card?> ObterCardCompletoPorId(int id)
        {
            try
            {
                Card? cardCompleto = _repositorio.ObterCardCompletoPorId(id);
                if (cardCompleto == null)
                {
                    return new Retorno<Card?>("Não foi possível encontrar o card solicitado");
                }
                var listaComentarios = _repositorio.ObterComentariosPorIdCard(id);

                foreach (var comentario in listaComentarios)
                {
                    cardCompleto.Comentarios.Add(comentario);
                }

                return new Retorno<Card?>(cardCompleto);
            }
            catch (Exception ex)
            {
                return new Retorno<Card>("Erro ao obter card completo" + ex.Message);
            }
        }

        public Retorno<List<Card?>> ObterTodosCards()
        {
            try
            {
                List<Card> listaCards = _repositorio.ObterTodosCards();

                if (listaCards == null)
                    return new Retorno<List<Card?>>("Erro ao obter todos os cards");

                return new Retorno<List<Card?>>(listaCards);
            }
            catch (Exception ex)
            {
                return new Retorno<List<Card?>>("Erro ao obter a lista dos cards" + ex.Message);
            }
        }

        public Retorno<bool> Cadastrar6u87i(CardCadastroRequest cardCadastro)
        {
            try
            {
                if (cardCadastro.Titulo.Contains("Amor") && cardCadastro.Etiqueta != EtiquetasCard.Vermelho)
                {
                    return new Retorno<bool>("Erro de escrita");
                }
                if (cardCadastro.DataEntrega <= DateTime.Now)
                {
                    return new Retorno<bool>("Erro de data");
                }

                var resultado = _repositorio.Cadastrar(cardCadastro);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao cadastrar o card");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<bool> Alterar(CardAlteracaoRequest cardAlteracao)
        {
            try
            {
                var resultado = _repositorio.Alterar(cardAlteracao);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao alterar o card");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<bool> Deletar(int id)
        {
            try
            {
                var resultado = _repositorio.Deletar(id);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao deletar o card");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<List<Card>> ObterTop()
        {
            try
            {
                List<Card> listaTopCards = _repositorio.ObterTop();

                if (listaTopCards == null)
                    return new Retorno<List<Card>>("");

                return new Retorno<List<Card>>(listaTopCards);
            }
            catch (Exception ex)
            {
                return new Retorno<List<Card>>("Erro" + ex.Message);
            }
        }

        public Retorno<List<Card?>> ObterCardPorTitulo(string titulo)
        {
            try
            {
                var resultado = _repositorio.ObterCardPorTitulo(titulo);

                if (resultado == null)
                    return new Retorno<List<Card?>>("Card não encontrado");

                return new Retorno<List<Card?>>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<List<Card>>("Erro" + ex.Message);
            }
        }

        public Retorno<List<Card>> ObterCardPorPalavraChave(string palavra)
        {
            try
            {
                var resultado = _repositorio.ObterCardPorPalavraChave(palavra);

                if (resultado == null)
                    return new Retorno<List<Card>>("Erro ao obter a palavra chave");

                return new Retorno<List<Card>>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<List<Card>>("Erro" + ex.Message);
            }
        }
    }
}
