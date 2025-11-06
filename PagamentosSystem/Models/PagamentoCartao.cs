namespace PagamentosSystem.Models
{
    public sealed class PagamentoCartao : Pagamento
    {
        public PagamentoCartao(Func<decimal, bool>? antifraude = null, Func<decimal, decimal>? cambio = null) 
            : base(antifraude, cambio)
        {
        }

        protected override void Validar()
        {
            base.Validar();
            Console.WriteLine("Validando dados do cartão...");
        }

        protected override void AutorizarOuCapturar()
        {
            Console.WriteLine("Autorizando transação com operadora de cartão...");
            
            // Simula verificação antifraude
            var valorTransacao = 100.0m;
            if (!VerificarAntifraude(valorTransacao))
            {
                throw new InvalidOperationException("Transação rejeitada pelo antifraude");
            }
        }

        protected override void Confirmar()
        {
            Console.WriteLine("Capturando valor autorizado...");
        }

        protected override string EmitirComprovante()
        {
            return "Comprovante eletrônico - Código de autorização: AUTH123456";
        }
    }
}