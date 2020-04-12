using System;
using System.Collections.Generic;
using System.Text;
using LiberacaoCredito.Domain.Enums;

namespace LiberacaoCredito.Domain.Entities
{
    public class Imobiliario : LiberacaoCredito
    {
        public Imobiliario(decimal valorCredito, int parcelas, DateTime primeiroVencimento) : base(valorCredito, parcelas, primeiroVencimento)
        {
            Juros = 9;
            TipoTaxa = ETipoTaxaJuros.Anual;
        }
        //Credito Imobiliário - Taxa de 9% ao ano   
    }
}
