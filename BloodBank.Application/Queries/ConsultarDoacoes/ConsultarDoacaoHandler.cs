using BloodBank.Application.Models;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.ConsultarDoacoes
{
    public class ConsultarDoacaoHandler : IRequestHandler<ConsultarDoacoesQuery, ResultViewModel<List<ConsultarDoacoesModel>>>
    {
        private readonly BloodBankDataContext _context;

        public ConsultarDoacaoHandler(BloodBankDataContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<ConsultarDoacoesModel>>> Handle(ConsultarDoacoesQuery request, CancellationToken cancellationToken)
        {
            var doacoes = await _context.Doacoes.Where(t => t.DoadorId == request.DoadorId).ToListAsync();
            var model = doacoes.Select(ConsultarDoacoesModel.ToEntity).ToList();

            return ResultViewModel<List<ConsultarDoacoesModel>>.Success(model);
        }
    }
}
