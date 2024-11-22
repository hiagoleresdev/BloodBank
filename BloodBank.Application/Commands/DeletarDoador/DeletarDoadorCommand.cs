using BloodBank.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.DeletarDoador
{
    public class DeletarDoadorCommand : IRequest<ResultViewModel>
    {
        public DeletarDoadorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
