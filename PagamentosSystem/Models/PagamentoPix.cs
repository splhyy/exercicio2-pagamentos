namespace PagamentosSystem.Models
{
    public sealed class PagamentoPix : Pagamento
    {
        public PagamentoPix(Func<decimal, bool>? antifraude = null, Func<decimal, decimal>? cambio = null) 
            : base(antifraude, cambio)
        {
        }

        protected override void Validar()
        {
            base.Validar();
            Console.WriteLine("Validando chave PIX...");
        }

        protected override void AutorizarOuCapturar()
        {
            Console.WriteLine("Gerando QR Code PIX...");
            
            // Simula verificação antifraude
            var valorTransacao = 100.0m;
            if (!VerificarAntifraude(valorTransacao))
            {
                throw new InvalidOperationException("Transação PIX rejeitada pelo antifraude");
            }
        }

        protected override void Confirmar()
        {
            Console.WriteLine("Confirmando recebimento PIX...");
        }

        protected override string EmitirComprovante()
        {
            return "Comprovante PIX instantâneo - ID: PIX987654";
        }
    }
}