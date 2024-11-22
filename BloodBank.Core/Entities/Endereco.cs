using System.Text.Json.Serialization;

namespace BloodBank.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco() {}

        public Endereco(string logradouro, string cidade, string estado, string cEP, Doador doador)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            Doador = doador;
        }

        public int Id { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("localidade")]
        public string Cidade { get; set; }

        [JsonPropertyName("uf")]
        public string Estado { get; set; }

        [JsonPropertyName("cep")]
        public string CEP { get; set; }
        public Doador Doador { get; set; }
    }
}
