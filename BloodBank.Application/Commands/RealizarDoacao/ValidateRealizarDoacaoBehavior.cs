using BloodBank.Application.Models;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.RealizarDoacao
{
    public class ValidateRealizarDoacaoBehavior
        : IPipelineBehavior<RealizarDoacaoCommand, ResultViewModel>
    {
        private readonly BloodBankDataContext _context;

        public ValidateRealizarDoacaoBehavior(BloodBankDataContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(RealizarDoacaoCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var doador = await _context.Doadores.FirstOrDefaultAsync(t => t.Id == request.DoadorId);
            
            if (doador == null)
                return ResultViewModel.Error("O doador não existe.");

            if(request.QuantidadeML < 420 || request.QuantidadeML > 470)
                return ResultViewModel.Error("A quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml");

            var ultimaDoacao = await _context.Doacoes.Where(t => t.DoadorId == doador.Id).OrderByDescending(t => t.DataDoacao).FirstOrDefaultAsync();
            if(ultimaDoacao != null)
            {
                if (doador.Genero.Equals("feminino", StringComparison.OrdinalIgnoreCase) && ((DateTime.Now - ultimaDoacao.DataDoacao).TotalDays < 90))
                    return ResultViewModel.Error("O tempo mínimo entre uma doação e outra é de 90 dias.");

                if (doador.Genero.Equals("masculino", StringComparison.OrdinalIgnoreCase) && ((DateTime.Now - ultimaDoacao.DataDoacao).TotalDays < 60))
                    return ResultViewModel.Error("O tempo mínimo entre uma doação e outra é de 60 dias.");
            }
           
            if (DateTime.Now.Year - doador.DataNascimento.Year < 18)
                return ResultViewModel.Error("Somente maiores de 18 podem doar.");

            if(doador.Peso < 50)
                return ResultViewModel.Error("O peso mínimo para doar é 50kg.");

            return await next();
        }

    }
}
