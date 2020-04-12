using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using LiberacaoCredito.Shared.Commands;

namespace LiberacaoCredito.Domain.Commands
{
    public class LiberacaoCreditoImobiliarioCommand : Notifiable, ICommand
    {
        public string ValorCredito { get; set; }
        public string Parcelas { get; set; }
        public string PrimeiroVencimento { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(ValorCredito))
                AddNotification("LiberacaoCreditoImobiliarioCommand.ValorCredito", "O valor de crédito é obrigatório");

            if (string.IsNullOrEmpty(Parcelas))
                AddNotification("LiberacaoCreditoImobiliarioCommand.Parcelas", "O número de parcelas é obrigatório");

            if (string.IsNullOrEmpty(PrimeiroVencimento))
                AddNotification("LiberacaoCreditoImobiliarioCommand.PrimeiroVencimento", "A data do primeiro vencimento é obrigatório");


        }
    }
}
