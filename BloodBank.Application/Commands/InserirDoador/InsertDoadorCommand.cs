using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.InserirDoador
{
    public class InsertDoadorCommand : IRequest<ResultViewModel>
    {
        public InsertDoadorCommand() { }
        public InsertDoadorCommand(string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, TipoSanguineo tipoSanguineo, bool fatorRH)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
        }

        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }

        public double Peso { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public bool FatorRH { get; set; }
        public string CEP { get; set; }        
    }
}
