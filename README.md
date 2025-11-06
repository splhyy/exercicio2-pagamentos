\# Exercício 2 - Sistema de Pagamentos (Cartão, PIX, Boleto)



\## 📋 Sobre o Projeto

Implementação do exercício de Herança e Composição em C#, demonstrando:

\- \*\*Herança controlada\*\* com ritual fixo (Validar → Autorizar/Capturar → Confirmar → Emitir Comprovante)

\- \*\*LSP (Princípio de Substituição de Liskov)\*\* - cliente agnóstico aos meios de pagamento

\- \*\*Composição com delegates\*\* para políticas plugáveis (antifraude, câmbio)



\## 🏗️ Arquitetura



\### Herança para Especialização

\- `Pagamento` (base) - Orquestra ritual fixo com ganchos protected virtual

\- `PagamentoCartao` (sealed) - Especializa autorização com operadora

\- `PagamentoPix` (sealed) - Especializa geração de QR Code

\- `PagamentoBoleto` (sealed) - Especializa geração de boleto



\### Composição para Políticas

\- `Antifraude: decimal → bool` - Estratégias de verificação de fraude

\- `Cambio: decimal → decimal` - Estratégias de conversão de moeda



\## 🚀 Como Executar



\### Compilar e executar o projeto:

```

cd PagamentosSystem

dotnet run
````
Executar os testes:
````
cd PagamentosSystem

dotnet test
````
🧪 Testes Implementados

Teste LSP: Processamento funciona com todos os tipos sem downcast



Teste Composição Antifraude: Política de limite rejeita valores altos



Teste Composição Câmbio: Conversão de moeda aplicada corretamente



Teste Múltiplas Políticas: Combinação de antifraude e câmbio funciona



Desenvolvido por: Shara Palharini Lima

(https://github.com/splhyy)

