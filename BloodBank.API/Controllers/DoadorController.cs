using BloodBank.Application.Commands.AtualizarDoador;
using BloodBank.Application.Commands.DeletarDoador;
using BloodBank.Application.Commands.InserirDoador;
using BloodBank.Application.Commands.RealizarDoacao;
using BloodBank.Application.Queries.GetAllDoadores;
using BloodBank.Application.Queries.GetDoadorById;
using BloodBank.Application.Queries.RelatorioDoacoes;
using BloodBank.Application.Queries.RelatorioEstoque;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/doador")]
    public class DoadorController : ControllerBase
    {
        private IMediator _mediator;
        public DoadorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}/obter-por-id")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var result = await _mediator.Send(new ObterDoadorPorIdQuery(id));

            return Ok(result);
        }

        [HttpGet("obter-todos")]
        public async Task<IActionResult> ObterTodosDoadores()
        {
            var result = await _mediator.Send(new ObterTodosDoadoresQuery());

            return Ok(result);
        }
        [HttpPost("inserir-doador")]
        public async Task<IActionResult> InserirDoador(InsertDoadorCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPut("{id}/atualizar-doador")]
        public async Task<IActionResult> AtualizarDoador(int id, AtualizarDoadorCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpDelete("deletar-doador")]
        public async Task<IActionResult> DeleteDoador(DeletarDoadorCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
