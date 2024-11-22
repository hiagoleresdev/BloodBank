using BloodBank.Application.Models;
using BloodBank.Core.Extentions;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.InserirDoador
{
    public class ValidateInserirDoadorBehavior : IPipelineBehavior<InsertDoadorCommand, ResultViewModel>
    {
        private readonly BloodBankDataContext _context;

        public ValidateInserirDoadorBehavior(BloodBankDataContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(InsertDoadorCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            if(!EmailValidation.Validate(request.Email))
                return ResultViewModel.Error("O email informado não é válido!");

            var emailJaExiste = await _context.Doadores.AnyAsync(t=> request.Email.Equals(t.Email));
            if (emailJaExiste)
                return ResultViewModel.Error("O email informado já existe!");

            return await next();
        }
    }
}
