using BloodBank.Core.Entities;

namespace BloodBank.Application.Models
{
    public class ConsultarDoacoesModel
    {
        public ConsultarDoacoesModel(int doadorId, DateTime dataDoacao, int quantidadeML)
        {
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }

        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        public Doador Doador { get; set; }

        public static ConsultarDoacoesModel ToEntity(Doacao d) => new(d.DoadorId, d.DataDoacao, d.QuantidadeML);
    }
}
