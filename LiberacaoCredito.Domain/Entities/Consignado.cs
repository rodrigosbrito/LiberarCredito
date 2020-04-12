using System;
using System.Collections.Generic;
using System.Text;
using LiberacaoCredito.Domain.Enums;

namespace LiberacaoCredito.Domain.Entities
{
    public class Consignado : LiberacaoCredito
    {
        public Consignado(decimal valorCredito, int parcelas, DateTime primeiroVencimento) : base(valorCredito, parcelas, primeiroVencimento)
        {
            Juros = 1;
            TipoTaxa = ETipoTaxaJuros.Mensal;
        }
    }
    //Credito Consignado - Taxa de 1% ao mês
    
}
