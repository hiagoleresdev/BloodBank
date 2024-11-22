using BloodBank.Application.Models;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DeletarDoacao
{
    public class DeletarDoacaoHandler : IRequestHandler<DeletarDoacaoCommand, ResultViewModel>
    {
        private readonly BloodBankDataContext _context;

        public DeletarDoacaoHandler(BloodBankDataContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeletarDoacaoCommand request, CancellationToken cancellationToken)
        {
            var doacao = await _context.Doacoes.FirstOrDefaultAsync(t => t.Id == request.Id);

            if (doacao == null)
                return ResultViewModel.Error("Doacao não encontrado.");

            _context.Doacoes.Remove(doacao);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
