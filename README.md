# Liberação de Crédito 
> Solução simples em .NET Core com Console Application que realiza o processamento de liberação de crédito.

## Tecnologias utilizadas
* Visual Studio 2019
* .NET Core 3.1
* C# 8.0
* Console Application
* FluntValidation(André Baltieri)
* MSTest

## Práticas adotadas
* SOLID
* DDD
* CQRS(Apenas Commands, devidos as regras de negócio serem simples, apenas por demonstração)
* Domínios Ricos
* Validações por Notificações
* Orientado a Testes (Testes Unitários da camada Handler)

## Execução
```
Compilar a solução inteira e executar o projeto LiberacaoCredito.Console
```

## Regras de negócio
```
Parâmetros de entrada:
- Valor do crédito
- Tipo de crédito
- Quantidade de parcelas
- Data do primeiro vencimento

As validações das entradas são as seguintes:
- O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00
- A quantidade de parcelas máximas é de 72x e a mínima é de 5x
- Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00
- A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no
máximo, D+40 (Dia atual + 40 dias)

Parâmetros de saída:
- Status do crédito (Aprovado ou recusado, de acordo com as premissas acima)
- Valor total com juros
- Valor do juros

Os juros são calculados da incrementando a porcentagem de juros no valor total do crédito.
```
