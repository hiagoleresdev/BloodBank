using BloodBank.Application.Models;
using BloodBank.Core.Extentions;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.RelatorioDoacoes
{
    public class RelatorioDoacoesHandler : IRequestHandler<RelatorioDoacoesQuery, ResultViewModel<List<RelatorioDoacoesModel>>>
    {
        private readonly BloodBankDataContext _context;

        public RelatorioDoacoesHandler(BloodBankDataContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<RelatorioDoacoesModel>>> Handle(RelatorioDoacoesQuery request, CancellationToken cancellationToken)
        {
            var doacoes = await _context.Doacoes.Where(t => t.DataDoacao >= DateTime.Now.AddDays(-30)).ToListAsync();
      
            var result = await _context.Doacoes
                .Where(d => d.DataDoacao >= DateTime.Now.AddDays(-30))
                .Include(d => d.Doador) 
                .Select(d => new RelatorioDoacoesModel
                {
                    NomeCompleto = d.Doador.NomeCompleto,
                    Peso = d.Doador.Peso,
                    Genero = d.Doador.Genero,
                    Email = d.Doador.Email,
                    TipoSanguineo = d.Doador.TipoSanguineo.GetDescription(),
                    DataDoacao = d.DataDoacao,
                    QuantidadeML = d.QuantidadeML
                })
                .ToListAsync(cancellationToken);

            return ResultViewModel<List<RelatorioDoacoesModel>>.Success(result);
        }
    }
}
