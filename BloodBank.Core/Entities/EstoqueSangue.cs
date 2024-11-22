using BloodBank.Core.Enums;

namespace BloodBank.Core.Entities
{
    public class EstoqueSangue : BaseEntity
    {
        public EstoqueSangue(){ }
        public EstoqueSangue(TipoSanguineo tipoSanguineo, bool fatorRH, int quantidadeML)
            :base()
        {
            TipoSanguineo = tipoSanguineo;
            FatorRH = fatorRH;
            QuantidadeML = quantidadeML;
        }

        public int Id { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public bool FatorRH { get; set; }
        public int  QuantidadeML { get; set; }
    }
}
