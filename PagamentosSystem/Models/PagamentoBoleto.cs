namespace PagamentosSystem.Models
{
    public sealed class PagamentoBoleto : Pagamento
    {
        public PagamentoBoleto(Func<decimal, bool>? antifraude = null, Func<decimal, decimal>? cambio = null) 
            : base(antifraude, cambio)
        {
        }

        protected override void Validar()
        {
            base.Validar();
            Console.WriteLine("Validando dados para geração de boleto...");
        }

        protected override void AutorizarOuCapturar()
        {
            Console.WriteLine("Gerando linha digitável e instruções do boleto...");
        }

        protected override void Confirmar()
        {
            Console.WriteLine("Aguardando compensação bancária...");
            Console.WriteLine("Boleto compensado com sucesso!");
        }

        protected override string EmitirComprovante()
        {
            return "Boleto bancário - Linha digitável: 34191.09008 01013.009028 91020.150008 8 85960026000";
        }
    }
}