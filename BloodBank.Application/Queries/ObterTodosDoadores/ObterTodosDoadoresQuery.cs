
using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDoadores
{
    public class ObterTodosDoadoresQuery : IRequest<ResultViewModel<List<ObterDoadorModel>>>
    {
    }
}
