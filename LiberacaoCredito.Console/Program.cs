using System;
using LiberacaoCredito.Domain.Commands;
using LiberacaoCredito.Domain.Handlers;

namespace LiberacaoCredito.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Digite o valor do crédito:");
            string valorCredito = System.Console.ReadLine();

            System.Console.Write("Digite o tipo de crédito (1 - Direto | 2 - Consignado | 3 - Pessoa Jurídica | 4 - Pessoa Física | 5 - Imobiliário):");
            string tipoCredito = System.Console.ReadLine();

            System.Console.Write("Digite a quantidade de parcelas:");
            string parcelas = System.Console.ReadLine();

            System.Console.Write("Digite a data do primeiro vencimento:");
            string primeiroVencimento = System.Console.ReadLine();

            var handler = new LiberacaoCreditoHandler();
            if (tipoCredito.Contains("1"))
            {
                var command = new LiberacaoCreditoDiretoCommand();
                command.ValorCredito = valorCredito;
                command.Parcelas = parcelas;
                command.PrimeiroVencimento = primeiroVencimento;
                var result = (CommandResult)handler.Handle(command);
                System.Console.Write(result.Message);

            }
            else if (tipoCredito.Contains("2"))
            {
                var command = new LiberacaoCreditoConsignadoCommand();
                command.ValorCredito = valorCredito;
                command.Parcelas = parcelas;
                command.PrimeiroVencimento = primeiroVencimento;
                var result = (CommandResult)handler.Handle(command);
                System.Console.Write(result.Message);
            }
            else if (tipoCredito.Contains("3"))
            {
                var command = new LiberacaoCreditoJuridicaCommand();
                command.ValorCredito = valorCredito;
                command.Parcelas = parcelas;
                command.PrimeiroVencimento = primeiroVencimento;
                var result = (CommandResult)handler.Handle(command);
                System.Console.Write(result.Message);
            }
            else if (tipoCredito.Contains("4"))
            {
                var command = new LiberacaoCreditoFisicaCommand();
                command.ValorCredito = valorCredito;
                command.Parcelas = parcelas;
                command.PrimeiroVencimento = primeiroVencimento;
                var result = (CommandResult)handler.Handle(command);
                System.Console.Write(result.Message);
            }
            else if (tipoCredito.Contains("5"))
            {
                var command = new LiberacaoCreditoImobiliarioCommand();
                command.ValorCredito = valorCredito;
                command.Parcelas = parcelas;
                command.PrimeiroVencimento = primeiroVencimento;
                var result = (CommandResult)handler.Handle(command);
                System.Console.Write(result.Message);
            }

        }
    }
}
