namespace PagamentosSystem.Services
{
    public static class PoliticasService
    {
        // Delegates para Antifraude
        public static bool AntifraudeAprovaTudo(decimal valor) => true;
        public static bool AntifraudeLimite100(decimal valor) => valor <= 100.0m;
        public static bool AntifraudeLimite500(decimal valor) => valor <= 500.0m;
        
        // Delegates para Câmbio
        public static decimal CambioRealParaDolar(decimal valor) => valor / 5.0m;
        public static decimal CambioRealParaEuro(decimal valor) => valor / 5.5m;
        public static decimal CambioSemTaxa(decimal valor) => valor;
    }
}