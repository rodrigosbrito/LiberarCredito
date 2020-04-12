using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using LiberacaoCredito.Domain.Commands;
using LiberacaoCredito.Domain.Entities;
using LiberacaoCredito.Shared.Commands;
using LiberacaoCredito.Shared.Handlers;

namespace LiberacaoCredito.Domain.Handlers
{
    public class LiberacaoCreditoHandler : 
        Notifiable, 
        IHandler<LiberacaoCreditoDiretoCommand>,
        IHandler<LiberacaoCreditoConsignadoCommand>,
        IHandler<LiberacaoCreditoFisicaCommand>,
        IHandler<LiberacaoCreditoJuridicaCommand>,
        IHandler<LiberacaoCreditoImobiliarioCommand>
    {
        public LiberacaoCreditoHandler()
        {

        }

        public ICommandResult Handle(LiberacaoCreditoDiretoCommand command) 
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível a Liberação de Crédito Direto", null);
            }

            //Validacoes
            if (!decimal.TryParse(command.ValorCredito, out decimal valorCredito))
                AddNotification("LiberacaoCreditoFisicaCommand.ValorCredito", "O valor de crédito é inválido");
            if (!int.TryParse(command.Parcelas, out int parcelas))
                AddNotification("LiberacaoCreditoFisicaCommand.Parcelas", "O número de parcelas é inválido");
            if (!DateTime.TryParse(command.PrimeiroVencimento, out DateTime primeiroVencimento))
                AddNotification("LiberacaoCreditoFisicaCommand.PrimeiroVencimento", "A data do primeiro vencimento é inválida");

            if (Invalid)
                return new CommandResult(false, "Não foi possível a Liberação de Crédito Direto", null);

            //Gerar a Entidade de Liberacao de Credito
            var direto = new Direto(valorCredito, parcelas, primeiroVencimento);

            //Aprovar ou Reprovar
            direto.Aprovar();

            //Calcular Juros
            direto.CalcularJuros();

            if (direto.Invalid)
                return new CommandResult(false, "Não foi possível calcular o Juros de Crédito Direto", null);

            return new CommandResult(true, $"Status do crédito: {direto.StatusString} | Valor total com juros: {direto.ValorTotalComJurosString} | Valor do juros: {direto.ValorJurosString} ", direto);
        }

        public ICommandResult Handle(LiberacaoCreditoConsignadoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível a Liberação de Crédito Consignado", null);
            }

            //Validacoes
            if (!decimal.TryParse(command.ValorCredito, out decimal valorCredito))
                AddNotification("LiberacaoCreditoFisicaCommand.ValorCredito", "O valor de crédito é inválido");
            if (!int.TryParse(command.Parcelas, out int parcelas))
                AddNotification("LiberacaoCreditoFisicaCommand.Parcelas", "O número de parcelas é inválido");
            if (!DateTime.TryParse(command.PrimeiroVencimento, out DateTime primeiroVencimento))
                AddNotification("LiberacaoCreditoFisicaCommand.PrimeiroVencimento", "A data do primeiro vencimento é inválida");

            if (Invalid)
                return new CommandResult(false, "Não foi possível a Liberação de Crédito Consignado", null);

            //Gerar a Entidade de Liberacao de Credito
            var consignado = new Consignado(valorCredito, parcelas, primeiroVencimento);

            //Aprovar ou Reprovar
            consignado.Aprovar();

            //Calcular Juros
            consignado.CalcularJuros();

            if (consignado.Invalid)
                return new CommandResult(false, "Não foi possível calcular o Juros de Crédito Consignado", null);

            return new CommandResult(true, $"Status do crédito: {consignado.StatusString} | Valor total com juros: {consignado.ValorTotalComJurosString} | Valor do juros: {consignado.ValorJurosString} ", consignado);
        }

        public ICommandResult Handle(LiberacaoCreditoFisicaCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível a Liberação de Crédito de Pessoa Física", null);
            }

            //Validacoes
            if (!decimal.TryParse(command.ValorCredito, out decimal valorCredito))
                AddNotification("LiberacaoCreditoFisicaCommand.ValorCredito", "O valor de crédito é inválido");
            if (!int.TryParse(command.Parcelas, out int parcelas))
                AddNotification("LiberacaoCreditoFisicaCommand.Parcelas", "O número de parcelas é inválido");
            if (!DateTime.TryParse(command.PrimeiroVencimento, out DateTime primeiroVencimento))
                AddNotification("LiberacaoCreditoFisicaCommand.PrimeiroVencimento", "A data do primeiro vencimento é inválida");

            if (Invalid)
                return new CommandResult(false, "Não foi possível a Liberação de Crédito Física", null);

            //Gerar a Entidade de Liberacao de Credito
            var fisica = new Fisica(valorCredito, parcelas, primeiroVencimento);

            //Aprovar ou Reprovar
            fisica.Aprovar();

            //Calcular Juros
            fisica.CalcularJuros();

            if (fisica.Invalid)
                return new CommandResult(false, "Não foi possível calcular o Juros de Crédito Física", null);

            return new CommandResult(true, $"Status do crédito: {fisica.StatusString} | Valor total com juros: {fisica.ValorTotalComJurosString} | Valor do juros: {fisica.ValorJurosString} ", fisica);
        }

        public ICommandResult Handle(LiberacaoCreditoJuridicaCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível a Liberação de Crédito de Pessoa Jurídica", null);
            }

            //Validacoes
            if (!decimal.TryParse(command.ValorCredito, out decimal valorCredito))
                AddNotification("LiberacaoCreditoFisicaCommand.ValorCredito", "O valor de crédito é inválido");
            if (!int.TryParse(command.Parcelas, out int parcelas))
                AddNotification("LiberacaoCreditoFisicaCommand.Parcelas", "O número de parcelas é inválido");
            if (!DateTime.TryParse(command.PrimeiroVencimento, out DateTime primeiroVencimento))
                AddNotification("LiberacaoCreditoFisicaCommand.PrimeiroVencimento", "A data do primeiro vencimento é inválida");

            if (Invalid)
                return new CommandResult(false, "Não foi possível a Liberação de Crédito de Pessoa Jurídica", null);

            //Gerar a Entidade de Liberacao de Credito
            var juridica = new Juridica(valorCredito, parcelas, primeiroVencimento);

            //Aprovar ou Reprovar
            juridica.Aprovar();

            //Calcular Juros
            juridica.CalcularJuros();

            if (juridica.Invalid)
                return new CommandResult(false, "Não foi possível calcular o Juros de Crédito de Pessoa Jurídica", null);

            return new CommandResult(true, $"Status do crédito: {juridica.StatusString} | Valor total com juros: {juridica.ValorTotalComJurosString} | Valor do juros: {juridica.ValorJurosString} ", juridica);
        }

        public ICommandResult Handle(LiberacaoCreditoImobiliarioCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível a Liberação de Crédito Imobiliário", null);
            }

            //Validacoes
            if (!decimal.TryParse(command.ValorCredito, out decimal valorCredito))
                AddNotification("LiberacaoCreditoFisicaCommand.ValorCredito", "O valor de crédito é inválido");
            if (!int.TryParse(command.Parcelas, out int parcelas))
                AddNotification("LiberacaoCreditoFisicaCommand.Parcelas", "O número de parcelas é inválido");
            if (!DateTime.TryParse(command.PrimeiroVencimento, out DateTime primeiroVencimento))
                AddNotification("LiberacaoCreditoFisicaCommand.PrimeiroVencimento", "A data do primeiro vencimento é inválida");

            if (Invalid)
                return new CommandResult(false, "Não foi possível a Liberação de Crédito Imobiliário", null);

            //Gerar a Entidade de Liberacao de Credito
            var imobiliario = new Imobiliario(valorCredito, parcelas, primeiroVencimento);

            //Aprovar ou Reprovar
            imobiliario.Aprovar();

            //Calcular Juros
            imobiliario.CalcularJuros();

            if (imobiliario.Invalid)
                return new CommandResult(false, "Não foi possível calcular o Juros de Crédito Imobiliário", null);

            return new CommandResult(true, $"Status do crédito: {imobiliario.StatusString} | Valor total com juros: {imobiliario.ValorTotalComJurosString} | Valor do juros: {imobiliario.ValorJurosString} ", imobiliario);
        }
    }
}
