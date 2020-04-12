using System;
using System.Collections.Generic;
using System.Text;
using LiberacaoCredito.Domain.Enums;

namespace LiberacaoCredito.Domain.Entities
{
    public class Fisica : LiberacaoCredito
    {
        public Fisica(decimal valorCredito, int parcelas, DateTime primeiroVencimento) : base(valorCredito, parcelas, primeiroVencimento)
        {
            Juros = 3;
            TipoTaxa = ETipoTaxaJuros.Mensal;
        }
    }
    //Credito Pessoa Física - Taxa de 3% ao mês
    
}
