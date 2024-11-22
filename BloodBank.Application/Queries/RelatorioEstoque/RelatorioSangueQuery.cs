using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Queries.RelatorioEstoque
{
    public class RelatorioSangueQuery : IRequest<ResultViewModel<List<ObterEstoqueSangueModel>>>
    {
    }
}
