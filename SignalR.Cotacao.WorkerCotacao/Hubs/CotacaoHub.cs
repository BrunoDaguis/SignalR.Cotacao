using Microsoft.AspNetCore.SignalR;
using SignalR.Cotacao.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Cotacao.WorkerCotacao.Hubs
{
    public class CotacaoHub : Hub<ICotacaoService>
    {
        public async Task EnviarCotacao(IEnumerable<CotacaoPoco> cotacoes)
        {
            await Clients.All.EnviarCotacao(cotacoes);
        }
    }
}
