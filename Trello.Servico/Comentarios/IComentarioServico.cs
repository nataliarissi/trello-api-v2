using Trello.Models.Requests.ComentariosRequests;
using Trello.Models.RetornoGerais;

namespace Trello.Servico.Comentarios
{
    public interface IComentarioServico
    {
        Retorno<bool> Cadastrar(ComentarioCadastroRequest comentarioCadastro);
        Retorno<bool> Alterar(ComentarioAlteracaoRequest comentarioAlteracao);
        Retorno<bool> Deletar(int id);
    }
}
