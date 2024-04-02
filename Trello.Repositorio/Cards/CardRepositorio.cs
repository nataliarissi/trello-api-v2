using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Trello.Models.Entidades;
using Trello.Models.Requests.CardsRequests;

namespace Trello.Repositorio.Cards
{
    public class CardRepositorio : ICardRepositorio
    {
        private string _connectionString { get; set; }

        public CardRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Trello");
        }

        public Card? ObterCardCompletoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Card>(QueriesCardsRepositorio.cardPorId, new { id });
            }
        }

        public List<Card> ObterTodosCards()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Card>(QueriesCardsRepositorio.obterCards).ToList();
            }
        }

        public bool Cadastrar(CardCadastroRequest cardCadastro)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(QueriesCardsRepositorio.cadastrarCard,
                new
                {
                    cardCadastro.Titulo,
                    cardCadastro.Conteudo,
                    cardCadastro.Assunto,
                    cardCadastro.Etiqueta,
                    cardCadastro.DataEntrega
                });
                return resultado > 0;
            }
        }

        public bool Alterar(CardAlteracaoRequest cardAlteracao)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(QueriesCardsRepositorio.alterarCard,
                new
                {
                    cardAlteracao.Id,
                    cardAlteracao.Titulo,
                    cardAlteracao.Conteudo,
                    cardAlteracao.Assunto,
                    cardAlteracao.Etiqueta,
                    cardAlteracao.DataEntrega
                });
                return resultado > 0;
            }
        }

        public bool Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(QueriesCardsRepositorio.deletarCard, new { id });
                return resultado > 0;
            }
        }

        public List<Card> ObterTop()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Card>(QueriesCardsRepositorio.topCards).ToList();
            }
        }

        public List<Comentario> ObterComentariosPorIdCard(int idCard)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Comentario>(QueriesCardsRepositorio.obterComentariosPorId,
                new
                {
                    idCard
                });
                return resultado.ToList();
            }
        }

        public List<Comentario> ObterComentarios()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Comentario>(QueriesCardsRepositorio.obterComentarios);
                return resultado.ToList();
            }
        }

        public List<Card> ObterCardPorTitulo(string titulo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Card>(QueriesCardsRepositorio.obterCardsPorTitulo, new { titulo });
                return resultado.ToList();
            }
        }

        public List<Card> ObterCardPorPalavraChave(string palavra)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Query<Card>(QueriesCardsRepositorio.obterCardPorPalavraChave, new { palavra });
                return resultado.ToList();
            }
        }
    }
}
