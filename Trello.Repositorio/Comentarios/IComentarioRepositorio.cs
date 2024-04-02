using Trello.Models.Requests.ComentariosRequests;

namespace Trello.Repositorio.Comentarios
{
    public interface IComentarioRepositorio
    {
        bool Cadastrar(ComentarioCadastroRequest comentarioCadastro);
        bool Alterar(ComentarioAlteracaoRequest comentarioAlteracao);
        bool Deletar(int id);
    }
}
