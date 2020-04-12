using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using LiberacaoCredito.Domain.Enums;
using LiberacaoCredito.Shared.Entities;

namespace LiberacaoCredito.Domain.Entities
{
    public abstract class LiberacaoCredito : Entity
    {
        public LiberacaoCredito(decimal valorCredito, int parcelas, DateTime primeiroVencimento)
        {
            ValorCredito = valorCredito;
            Parcelas = parcelas;
            PrimeiroVencimento = primeiroVencimento;

        }

        public decimal ValorCredito { get; private set; }
        public int Parcelas { get; private set; }
        public DateTime PrimeiroVencimento { get; private set; }

        public EStatusLiberacaoCredito Status { get; set; }

        protected decimal Juros { get; set; }
        public ETipoTaxaJuros TipoTaxa { get; set; }
        protected decimal ValorTotalComJuros { get; set; }
        protected decimal ValorJuros { get; set; }

        public string StatusString
        {
            get
            {
                return Status.Equals(EStatusLiberacaoCredito.Aprovado) ? "Aprovado" : "Recusado";
            }
        }
        public string ValorTotalComJurosString
        {
            get
            {
                return "R$ " + ValorTotalComJuros.ToString("N2");
            }
        }
        public string ValorJurosString
        {
            get
            {
                return "R$ " + ValorJuros.ToString("N2");
            }
        }

        public virtual void Aprovar()
        {
            //O valor máximo a ser liberado é de R$ 1.000.000,00
            if (ValorCredito > 1000000)
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

        public virtual void CalcularJuros()
        {
            if (TipoTaxa.Equals(ETipoTaxaJuros.Mensal))
            {
                ValorJuros = (ValorCredito * Juros) / 100;
                ValorTotalComJuros = (ValorJuros * Parcelas) + ValorCredito;
            }
            else
            {
                Juros = Juros / 12;
                ValorJuros = (ValorCredito * Juros) / 100;
                ValorTotalComJuros = (ValorJuros * Parcelas) + ValorCredito;
            }
        }

    }
}
