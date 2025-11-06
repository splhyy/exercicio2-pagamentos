using System;

namespace PagamentosSystem.Models
{
    public class Pagamento
    {
        private readonly Func<decimal, bool>? _antifraude;
        private readonly Func<decimal, decimal>? _cambio;

        public Pagamento(Func<decimal, bool>? antifraude = null, Func<decimal, decimal>? cambio = null)
        {
            _antifraude = antifraude;
            _cambio = cambio;
        }

        // RITUAL FIXO - Template Method
        public void Processar()
        {
            Validar();
            AutorizarOuCapturar();
            Confirmar();
            var comprovante = EmitirComprovante();
            Console.WriteLine(comprovante);
        }

        // GANCHOS PROTECTED VIRTUAL
        protected virtual void Validar()
        {
            Console.WriteLine("Validando dados básicos do pagamento...");
        }

        protected virtual void AutorizarOuCapturar()
        {
            Console.WriteLine("Autorizando/Capturando pagamento...");
        }

        protected virtual void Confirmar()
        {
            Console.WriteLine("Confirmando pagamento...");
        }

        protected virtual string EmitirComprovante()
        {
            return "Comprovante genérico de pagamento";
        }

        // COMPOSIÇÃO com delegates
        protected bool VerificarAntifraude(decimal valor)
        {
            return _antifraude?.Invoke(valor) ?? true; // Aprova por padrão se não houver política
        }

        protected decimal AplicarCambio(decimal valor)
        {
            return _cambio?.Invoke(valor) ?? valor; // Mantém valor original se não houver câmbio
        }
    }
}