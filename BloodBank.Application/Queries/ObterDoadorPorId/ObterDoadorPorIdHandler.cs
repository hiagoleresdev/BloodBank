using BloodBank.Application.Models;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.GetDoadorById
{
    public class ObterDoadorPorIdHandler : IRequestHandler<ObterDoadorPorIdQuery, ResultViewModel<ObterDoadorModel>>
    {
        private readonly BloodBankDataContext _context;

        public ObterDoadorPorIdHandler(BloodBankDataContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<ObterDoadorModel>> Handle(ObterDoadorPorIdQuery request, CancellationToken cancellationToken)
        {
            var doador = await _context.Doadores.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (doador == null)
                return ResultViewModel<ObterDoadorModel>.Error("Doador não foi encontrado. ");

            var model = ObterDoadorModel.ToEntity(doador);

            return ResultViewModel<ObterDoadorModel>.Success(model);
        }
    }
}
