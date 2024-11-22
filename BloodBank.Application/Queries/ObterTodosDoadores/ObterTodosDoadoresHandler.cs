using BloodBank.Application.Models;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Queries.GetAllDoadores
{
    public class ObterTodosDoadoresHandler : IRequestHandler<ObterTodosDoadoresQuery, ResultViewModel<List<ObterDoadorModel>>>
    {
        private readonly BloodBankDataContext _context;

        public ObterTodosDoadoresHandler(BloodBankDataContext context)
        {
            _context = context;
        }
        
        public async Task<ResultViewModel<List<ObterDoadorModel>>> Handle(ObterTodosDoadoresQuery request, CancellationToken cancellationToken)
        {
            var doadores = await _context.Doadores.ToListAsync();
            var model = doadores.Select(ObterDoadorModel.ToEntity).ToList();

            return ResultViewModel<List<ObterDoadorModel>>.Success(model);
        }
    }
}
