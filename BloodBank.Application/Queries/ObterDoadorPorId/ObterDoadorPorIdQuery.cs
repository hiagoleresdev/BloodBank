
using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetDoadorById
{
    public class ObterDoadorPorIdQuery : IRequest<ResultViewModel<ObterDoadorModel>>
    {
        public ObterDoadorPorIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
