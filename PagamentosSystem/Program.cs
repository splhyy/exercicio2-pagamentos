using PagamentosSystem.Models;
using PagamentosSystem.Services;

namespace PagamentosSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EXERCÍCIO 2 - SISTEMA DE PAGAMENTOS ===\n");
            
            // DEMONSTRAÇÃO LSP - Cliente agnóstico
            Console.WriteLine("1. TESTE LSP (Substituição):");
            ProcessarQualquerPagamento(new PagamentoCartao());
            ProcessarQualquerPagamento(new PagamentoPix());
            ProcessarQualquerPagamento(new PagamentoBoleto());
            
            // DEMONSTRAÇÃO COMPOSIÇÃO
            Console.WriteLine("\n2. TESTE COMPOSIÇÃO (Troca de Peças):");
            
            // Composição 1: Cartão com antifraude limite 100
            var pagamento1 = new PagamentoCartao(PoliticasService.AntifraudeLimite100);
            ProcessarQualquerPagamento(pagamento1);
            
            // Composição 2: PIX com câmbio para dólar
            var pagamento2 = new PagamentoPix(
                antifraude: PoliticasService.AntifraudeAprovaTudo,
                cambio: PoliticasService.CambioRealParaDolar
            );
            ProcessarQualquerPagamento(pagamento2);
            
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
        
        // MÉTODO QUE DEMONSTRA LSP - funciona com qualquer Pagamento
        static void ProcessarQualquerPagamento(Pagamento pagamento)
        {
            Console.WriteLine($"\nProcessando {pagamento.GetType().Name}:");
            pagamento.Processar();
        }
    }
}