namespace SignalR.Cotacao.ServiceInterface
{
    public class CotacaoPoco
    {
        public CotacaoPoco(string papel, double valor)
        {
            Papel = papel;
            Valor = valor;
        }

        public string Papel { get; set; }
        public double Valor { get; set; }
    }
}
