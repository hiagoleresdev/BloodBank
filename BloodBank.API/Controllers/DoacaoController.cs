using BloodBank.Application.Commands.DeletarDoacao;
using BloodBank.Application.Commands.DeletarDoador;
using BloodBank.Application.Commands.RealizarDoacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("/api/doacao")]
    public class DoacaoController : ControllerBase
    {
        private IMediator _mediator;
        public DoacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("realizar-doacao")]
        public async Task<IActionResult> RealizarDoacao(RealizarDoacaoCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("deletar-doacao")]
        public async Task<IActionResult> DeleteDoador(DeletarDoacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
