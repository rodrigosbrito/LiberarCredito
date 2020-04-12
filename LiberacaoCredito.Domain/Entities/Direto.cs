using System;
using System.Collections.Generic;
using System.Text;
using LiberacaoCredito.Domain.Enums;

namespace LiberacaoCredito.Domain.Entities
{
    public class Direto : LiberacaoCredito
    {
        public Direto(decimal valorCredito, int parcelas, DateTime primeiroVencimento) : base(valorCredito, parcelas, primeiroVencimento)
        {
            Juros = 2;
            TipoTaxa = ETipoTaxaJuros.Mensal;
        }


    }

    //Credito Direto - Taxa de 2% ao mês

}
