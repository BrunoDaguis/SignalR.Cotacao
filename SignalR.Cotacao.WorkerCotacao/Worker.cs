using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignalR.Cotacao.ServiceInterface;
using SignalR.Cotacao.WorkerCotacao.Extensions;
using SignalR.Cotacao.WorkerCotacao.Hubs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR.Cotacao.WorkerCotacao
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHubContext<CotacaoHub, ICotacaoService> _cotacaoHub;

        public Worker(ILogger<Worker> logger, IHubContext<CotacaoHub, ICotacaoService> cotacaoHub)
        {
            _logger = logger;
            _cotacaoHub = cotacaoHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cotacoes = new List<CotacaoPoco>
                {
                    new CotacaoPoco("MGLU3", new Random().NextDouble(1, 5)),
                    new CotacaoPoco("OIBR3", new Random().NextDouble(1, 5)),
                    new CotacaoPoco("WEGE3", new Random().NextDouble(1, 5)),
                    new CotacaoPoco("LREN3", new Random().NextDouble(1, 5)),
                    new CotacaoPoco("CNTO3", new Random().NextDouble(1, 5))
                };

                foreach (var cotacao in cotacoes)
                {
                    _logger.LogInformation($"{cotacao.Papel} -> {cotacao.Valor}");
                }



                await _cotacaoHub.Clients.All.EnviarCotacao(cotacoes);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}