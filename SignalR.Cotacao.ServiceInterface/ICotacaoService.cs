using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Cotacao.ServiceInterface
{
    public interface ICotacaoService
    {
        Task EnviarCotacao(IEnumerable<CotacaoPoco> cotacoes);
    }
}