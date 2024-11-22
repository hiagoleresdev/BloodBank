using BloodBank.Application.Queries.RelatorioDoacoes;
using BloodBank.Application.Queries.RelatorioEstoque;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [ApiController]
    [Route("api/relatorio")]
    public class RelatorioController : ControllerBase
    {
        private IMediator _mediator;
        public RelatorioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("relatorio-estoque")]
        public async Task<IActionResult> RelatorioEstoque()
        {
            var result = await _mediator.Send(new RelatorioSangueQuery());
            return Ok(result);
        }

        [HttpGet("relatorio-doacoes")]
        public async Task<IActionResult> RelatorioDoacoes()
        {
            var result = await _mediator.Send(new RelatorioDoacoesQuery());
            return Ok(result);
        }
    }
}
