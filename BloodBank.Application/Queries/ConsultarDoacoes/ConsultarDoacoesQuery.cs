using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.ConsultarDoacoes
{
    public class ConsultarDoacoesQuery : IRequest<ResultViewModel<List<ConsultarDoacoesModel>>>
    {
        public ConsultarDoacoesQuery(int doadorId)
        {
            DoadorId = doadorId;
        }
        public int DoadorId { get; set; }
    }
}
