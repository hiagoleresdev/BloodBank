using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.RelatorioEstoque
{
    public class RelatorioSangueHandler : IRequestHandler<RelatorioSangueQuery, ResultViewModel<List<ObterEstoqueSangueModel>>>
    {
        private readonly BloodBankDataContext _context;

        public RelatorioSangueHandler(BloodBankDataContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<ObterEstoqueSangueModel>>> Handle(RelatorioSangueQuery request, CancellationToken cancellationToken)
        {
            var estoque = await _context.EstoquesSangues
                .GroupBy(e => new { e.TipoSanguineo, e.FatorRH })
                .Select(g => new EstoqueSangue
                {
                    TipoSanguineo = g.Key.TipoSanguineo,
                    FatorRH = g.Key.FatorRH,
                    QuantidadeML = g.Sum(e => e.QuantidadeML)
                })
                .OrderBy(e => e.TipoSanguineo)
                .ThenBy(e => e.FatorRH)
                .ToListAsync();
            var estoqueModel = estoque.Select(ObterEstoqueSangueModel.ToEntity).ToList();

            if (estoque is null)
                return ResultViewModel<List<ObterEstoqueSangueModel>>.Error("O estoque está vazio. ");

            return ResultViewModel<List<ObterEstoqueSangueModel>>.Success(estoqueModel);
        }
    }
}
