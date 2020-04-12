using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using LiberacaoCredito.Domain.Enums;

namespace LiberacaoCredito.Domain.Entities
{
    public class Juridica  : LiberacaoCredito
    {
        public Juridica(decimal valorCredito, int parcelas, DateTime primeiroVencimento) : base(valorCredito, parcelas, primeiroVencimento)
        {
            Juros = 5;
            TipoTaxa = ETipoTaxaJuros.Mensal;
        }
        public override void Aprovar()
        {
            //O valor máximo a ser liberado é de R$ 1.000.000,00
            if (ValorCredito > 1000000 || ValorCredito < 15000)
            {
                Status = EStatusLiberacaoCredito.Recusado;
            }
            else if (Parcelas > 72 || Parcelas < 5) //A quantidade de parcelas máximas é de 72x e a mínima é de 5x
            {
                Status = EStatusLiberacaoCredito.Recusado;
            }
            //A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, D + 40(Dia atual + 40 dias)
            else if (PrimeiroVencimento < DateTime.Now.AddDays(15) ||
            PrimeiroVencimento > DateTime.Now.AddDays(40))
            {
                Status = EStatusLiberacaoCredito.Recusado;
            }
            else
            {
                Status = EStatusLiberacaoCredito.Aprovado;
            }

        }
    }
    
}
