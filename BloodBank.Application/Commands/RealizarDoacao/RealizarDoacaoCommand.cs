
using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using MediatR;

namespace BloodBank.Application.Commands.RealizarDoacao
{
    public class RealizarDoacaoCommand : IRequest<ResultViewModel>
    {
        public RealizarDoacaoCommand(int doadorId, DateTime dataDoacao, int quantidadeML)
        {
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }

        public  Doacao ToEntity() => new (DoadorId, DataDoacao, QuantidadeML);

    }
}
