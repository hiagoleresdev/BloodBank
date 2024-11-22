using BloodBank.Application.Commands.InserirDoador;
using BloodBank.Application.Models;
using BloodBank.Core.Entities;
using BloodBank.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BloodBank.Application.Commands.AtualizarDoador
{
    public class AtualizarDoadorHandler : IRequestHandler<AtualizarDoadorCommand, ResultViewModel>
    {
        private readonly BloodBankDataContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public AtualizarDoadorHandler(BloodBankDataContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResultViewModel> Handle(AtualizarDoadorCommand request, CancellationToken cancellationToken)
        {
            var doador = await _context.Doadores.FirstOrDefaultAsync(t => t.Id == request.IdDoador, cancellationToken);
            if (doador == null)
                return ResultViewModel.Error("Doador não encontrado.");

            var endereco = await AlterarEndereco(doador, request, cancellationToken);
            if (endereco == null)
                return ResultViewModel.Error("Endereço não encontrado ou CEP inválido.");

            if (endereco.Id != doador.EnderecoId)
            {
                await _context.Enderecos.AddAsync(endereco, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            doador.Update(
                request.NomeCompleto,
                request.Email,
                request.DataNascimento,
                request.Genero,
                request.Peso,
                request.TipoSanguineo,
                request.FatorRH,
                endereco.Id
            );

            _context.Doadores.Update(doador);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }

        private async Task<Endereco?> AlterarEndereco(Doador doador, AtualizarDoadorCommand request, CancellationToken cancellationToken)
        {
            var enderecoAtual = await _context.Enderecos.FirstOrDefaultAsync(t => t.Id == doador.EnderecoId, cancellationToken);

            if (enderecoAtual != null && enderecoAtual.CEP.Replace("-", "") == request.Cep)
                return enderecoAtual;

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{request.Cep}/json/", cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null; 

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            var novoEndereco = JsonSerializer.Deserialize<Endereco>(responseContent);

            if (novoEndereco == null || string.IsNullOrEmpty(novoEndereco.CEP))
                return null;

            return novoEndereco;
        }
    }
}
