using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trello.Models.Requests.ComentariosRequests;
using Trello.Models.RetornoGerais;
using Trello.Servico.Comentarios;

namespace Trello.V2.API.Controllers
{
    [Route("/comentarios")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioServico _comentarioServico;

        public ComentarioController(IComentarioServico comentarioServico)
        {
            _comentarioServico = comentarioServico;
        }

        [HttpPost("/cadastrar")]
        public Retorno<bool> Cadastrar([FromBody] ComentarioCadastroRequest comentarioCadastro)
        {
            return _comentarioServico.Cadastrar(comentarioCadastro);
        }

        [HttpPut("/atualizar")]
        public Retorno<bool> AlterarComentario([FromBody] ComentarioAlteracaoRequest comentarioAlteracao)
        {
            return _comentarioServico.Alterar(comentarioAlteracao);
        }

        [HttpDelete("/deletar")]
        public Retorno<bool> Deletar(int id)
        {
            return _comentarioServico.Deletar(id);
        }
    }
}
