using Trello.Models.Requests.ComentariosRequests;
using Trello.Models.RetornoGerais;
using Trello.Repositorio.Comentarios;

namespace Trello.Servico.Comentarios
{
    public class ComentarioServico : IComentarioServico
    {
        private readonly IComentarioRepositorio _repositorio;
        public ComentarioServico(IComentarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Retorno<bool> Cadastrar(ComentarioCadastroRequest comentarioCadastro)
        {
            try
            {
                var resultado = _repositorio.Cadastrar(comentarioCadastro);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao cadastrar comentário no card");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }

        public Retorno<bool> Alterar(ComentarioAlteracaoRequest comentarioAlteracao)
        {
            try
            {
                var resultado = _repositorio.Alterar(comentarioAlteracao);

                if (resultado == null)
                    return new Retorno<bool>("Erro ao alterar comentário");

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
                    return new Retorno<bool>("Erro ao deletar comentário");

                return new Retorno<bool>(resultado);
            }
            catch (Exception ex)
            {
                return new Retorno<bool>("Erro" + ex.Message);
            }
        }
    }
}
