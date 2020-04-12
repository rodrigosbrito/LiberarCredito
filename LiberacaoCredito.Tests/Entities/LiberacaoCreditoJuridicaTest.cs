using System;
using System.Collections.Generic;
using System.Text;
using LiberacaoCredito.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiberacaoCredito.Tests.Entities
{
    [TestClass]
    public class LiberacaoCreditoJuridicaTest
    {
        [TestMethod]
        public void DeveRetornarErroQuandoValorCreditoInvalido()
        {
            var credito = new Juridica(14999, 10, DateTime.Now.AddDays(30));
            Assert.IsTrue(credito.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoValorCreditoValido()
        {
            var credito = new Juridica(15000, 10, DateTime.Now.AddDays(30));
            Assert.IsTrue(credito.Valid);
        }
        [TestMethod]
        public void DeveRetornarErroQuandoParcelasInvalido()
        {
            var credito = new Juridica(20000, 73, DateTime.Now.AddDays(30));
            Assert.IsTrue(credito.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoParcelasValido()
        {
            var credito = new Juridica(20000, 5, DateTime.Now.AddDays(30));
            Assert.IsTrue(credito.Valid);
        }
        [TestMethod]
        public void DeveRetornarErroQuandoPrimeiroVencimentoInvalido()
        {
            var credito = new Juridica(200000, 10, DateTime.Now.AddDays(41));
            Assert.IsTrue(credito.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoPrimeiroVencimentoValido()
        {
            var credito = new Juridica(20000, 10, DateTime.Now.AddDays(30));
            Assert.IsTrue(credito.Valid);
        }
    }
}
