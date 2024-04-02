using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Trello.Models.Requests.ComentariosRequests;

namespace Trello.Repositorio.Comentarios
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private string _connectionString { get; set; }

        public ComentarioRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Trello");
        }

        public bool Cadastrar(ComentarioCadastroRequest comentarioCadastro)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(QueriesComentariosRepositorio.cadastrarComentario,
                new
                {
                    comentarioCadastro.IdCard,
                    comentarioCadastro.CaixaTexto,
                    comentarioCadastro.IdUsuario,
                    QUANTIDADEESTRELAS = comentarioCadastro.Estrelas
                });
                return resultado > 0;
            }
        }

        public bool Alterar(ComentarioAlteracaoRequest comentarioAlteracao)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(QueriesComentariosRepositorio.alterarComentario,
                new
                {
                    comentarioAlteracao.Id,
                    comentarioAlteracao.CaixaTexto,
                    QUANTIDADEESTRELAS = comentarioAlteracao.Estrelas,
                });
                return resultado > 0;
            }
        }

        public bool Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var resultado = connection.Execute(QueriesComentariosRepositorio.deletarCard, new { id });
                return resultado > 0;
            }
        }
    }
}
