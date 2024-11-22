using BloodBank.Core.Entities;
using BloodBank.Core.Extentions;

namespace BloodBank.Application.Models
{
    public class ObterEstoqueSangueModel
    {
        public ObterEstoqueSangueModel(string tipoSanguineo, bool fatorRH, int quantidadeML)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
            QuantidadeML = quantidadeML;
        }

        public string TipoSanguineo { get; set; }
        public bool FatorRH { get; set; }
        public int QuantidadeML { get; set; }

        public static ObterEstoqueSangueModel ToEntity(EstoqueSangue model) => new(model.TipoSanguineo.GetDescription(), model.FatorRH, model.QuantidadeML);
    }
}
