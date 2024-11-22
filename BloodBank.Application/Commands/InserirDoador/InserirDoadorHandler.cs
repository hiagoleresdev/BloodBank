using Azure;
using Azure.Core;
using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using System.Net.Http;
using System.Text.Json;
using System.Threading;

namespace BloodBank.Application.Commands.InserirDoador
{
    public class InserirDoadorHandler : IRequestHandler<InsertDoadorCommand, ResultViewModel>
    {
        private readonly BloodBankDataContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public InserirDoadorHandler(BloodBankDataContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;

        }

        public async Task<ResultViewModel> Handle(InsertDoadorCommand request, CancellationToken cancellationToken)
        {
            var endereco = await AdicionarEndereco(request, cancellationToken);
            if (endereco == null)
                return ResultViewModel.Error("Endereço não encontrado!");

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync(cancellationToken);

            var doador = new Doador(request.NomeCompleto, request.Email, request.DataNascimento, request.Genero, request.Peso, request.TipoSanguineo, request.FatorRH, endereco.Id);

            await _context.Doadores.AddAsync(doador);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }

        public async Task<Endereco> AdicionarEndereco(InsertDoadorCommand request, CancellationToken cancellationToken)
        {
            var numeroCep = request.CEP;
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{numeroCep}/json/", cancellationToken);

            var responseContent = await response.Content.ReadAsStringAsync();
            var endereco = JsonSerializer.Deserialize<Endereco>(responseContent);

            return endereco;
        }
    }
}
