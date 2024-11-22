using BloodBank.Core.Enums;

namespace BloodBank.Core.Entities
{
    public class Doador : BaseEntity
    {
        public Doador(string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, TipoSanguineo tipoSanguineo, bool fatorRH, int enderecoId=0)
            :base()
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
            Doacoes = [];
            EnderecoId = enderecoId;    
        }

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public bool FatorRH {  get; set; }  
        public List<Doacao> Doacoes { get; set; }
        public Endereco Endereco { get; set; }  
        public int EnderecoId { get; set; }

        public void Update(string nomeCompleto, string email, DateTime dataNasc, string genero, double peso, TipoSanguineo tipoSanguineo, bool fatorRh, int enderecoId)
        {
           NomeCompleto = nomeCompleto;
           Email = email;
           DataNascimento = dataNasc;
           Genero = genero;
           Peso = peso;
           TipoSanguineo = tipoSanguineo;
           FatorRH = fatorRh;
           EnderecoId = enderecoId;
        }
    }
}
