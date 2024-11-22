using BloodBank.Application.Models;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.AtualizarDoador
{
    public class AtualizarDoadorCommand : IRequest<ResultViewModel>
    {
        public int IdDoador { get; set; } 
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public bool FatorRH { get; set; }
        public string Cep {  get; set; }
    }
}
