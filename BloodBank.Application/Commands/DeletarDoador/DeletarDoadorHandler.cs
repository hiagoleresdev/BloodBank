using BloodBank.Application.Models;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.DeletarDoador
{
    public class DeletarDoadorHandler : IRequestHandler<DeletarDoadorCommand, ResultViewModel>
    {
        private readonly BloodBankDataContext _context;

        public DeletarDoadorHandler(BloodBankDataContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeletarDoadorCommand request, CancellationToken cancellationToken)
        {
            var doador = await _context.Doadores.FirstOrDefaultAsync(t=> t.Id == request.Id);
            if (doador == null)
                return ResultViewModel.Error("Doador não encontrado.");
            _context.Doadores.Remove(doador);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
