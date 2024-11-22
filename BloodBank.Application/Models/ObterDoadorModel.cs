using BloodBank.Core.Entities;
using BloodBank.Core.Enums;

namespace BloodBank.Application.Models
{
    public class ObterDoadorModel
    {
        public ObterDoadorModel(string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, TipoSanguineo tipoSanguineo, bool fatorRH)
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

        public ObterDoadorModel FromEntity(Doador d) => new(d.NomeCompleto, d.Email, d.DataNascimento, d.Genero, d.Peso, d.TipoSanguineo, d.FatorRH);
        public static ObterDoadorModel ToEntity(Doador d) => new(d.NomeCompleto, d.Email, d.DataNascimento, d.Genero, d.Peso, d.TipoSanguineo, d.FatorRH);
    }
}
