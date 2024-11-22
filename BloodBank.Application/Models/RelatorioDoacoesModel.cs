namespace BloodBank.Application.Models
{
    public class RelatorioDoacoesModel
    {
        public RelatorioDoacoesModel(){}
        public RelatorioDoacoesModel(string nomeCompleto, double peso, string genero, string email, string tipoSanguineo, DateTime dataDoacao, int quantidadeML)
        {
            NomeCompleto = nomeCompleto;
            Peso = peso;
            Genero = genero;
            Email = email;
            TipoSanguineo = tipoSanguineo;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

        public string NomeCompleto { get; set; }
        public double Peso {  get; set; }
        public string Genero { get; set; }
        public string Email {  get; set; }
        public string TipoSanguineo { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
    }
}
