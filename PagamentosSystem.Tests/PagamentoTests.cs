using Xunit;
using PagamentosSystem.Models;
using PagamentosSystem.Services;

namespace PagamentosSystem.Tests
{
    public class PagamentoTests
    {
        [Fact]
        public void TesteLSP_ProcessamentoFuncionaComTodosTiposSemDowncast()
        {
            // Arrange
            Pagamento[] pagamentos = {
                new PagamentoCartao(),
                new PagamentoPix(),
                new PagamentoBoleto()
            };
            
            // Act & Assert - Não deve lançar exceção nem requerer downcast
            foreach (var pagamento in pagamentos)
            {
                var exception = Record.Exception(() => pagamento.Processar());
                Assert.Null(exception);
            }
        }
        
        [Fact]
        public void TesteComposição_AntifraudeLimiteRejeitaValorAlto()
        {
            // Arrange
            var pagamento = new PagamentoCartao(PoliticasService.AntifraudeLimite100);
            
            // Act & Assert - Deve processar sem erro para valores dentro do limite
            var exception = Record.Exception(() => pagamento.Processar());
            Assert.Null(exception);
        }
        
        [Fact] 
        public void TesteComposição_CambioAlteraValor()
        {
            // Arrange
            var pagamento = new PagamentoPix(
                cambio: PoliticasService.CambioRealParaDolar
            );
            
            // Act & Assert - Deve processar com câmbio aplicado
            var exception = Record.Exception(() => pagamento.Processar());
            Assert.Null(exception);
        }

        [Fact]
        public void TesteComposição_MultiplasPoliticasCombinadas()
        {
            // Arrange
            var pagamento = new PagamentoPix(
                antifraude: PoliticasService.AntifraudeLimite500,
                cambio: PoliticasService.CambioRealParaEuro
            );
            
            // Act & Assert - Deve processar com ambas políticas
            var exception = Record.Exception(() => pagamento.Processar());
            Assert.Null(exception);
        }
    }
}