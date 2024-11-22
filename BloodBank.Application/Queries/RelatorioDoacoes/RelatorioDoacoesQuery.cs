using BloodBank.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.RelatorioDoacoes
{
    public class RelatorioDoacoesQuery : IRequest<ResultViewModel<List<RelatorioDoacoesModel>>>
    {
    }
}
