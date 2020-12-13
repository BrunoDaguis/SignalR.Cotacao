using System;

namespace SignalR.Cotacao.WorkerCotacao.Extensions
{
    public static class RandomExtension
    {
        public static double NextDouble(this Random rng, double start, double end)
        {
            return (rng.NextDouble() * Math.Abs(end - start)) + start;
        }
    }
}