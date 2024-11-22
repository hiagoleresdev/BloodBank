using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.DeletarDoacao
{
    public class DeletarDoacaoCommand : IRequest<ResultViewModel>
    {
        public DeletarDoacaoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
