using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Infraestructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.RealizarDoacao
{
    public class RealizarDoacaoHandler : IRequestHandler<RealizarDoacaoCommand, ResultViewModel>
    {
        private readonly BloodBankDataContext _context;

        public RealizarDoacaoHandler(BloodBankDataContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(RealizarDoacaoCommand request, CancellationToken cancellationToken)
        {
            var model = request.ToEntity();
            var result = await _context.Doacoes.AddAsync(model);

            AtualizarEstoqueSangue(request);

            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
        
        public void AtualizarEstoqueSangue(RealizarDoacaoCommand r)
        {
            var doador = _context.Doadores.SingleOrDefault(t=> t.Id == r.DoadorId);
            var estoque = new EstoqueSangue(doador.TipoSanguineo, doador.FatorRH, r.QuantidadeML);

            _context.EstoquesSangues.Add(estoque);
        }
    }
}
