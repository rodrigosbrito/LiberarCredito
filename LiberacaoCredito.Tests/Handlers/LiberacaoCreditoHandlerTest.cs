using System;
using System.Collections.Generic;
using System.Text;
using LiberacaoCredito.Domain.Commands;
using LiberacaoCredito.Domain.Entities;
using LiberacaoCredito.Domain.Enums;
using LiberacaoCredito.Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LiberacaoCredito.Tests.Handlers
{
    [TestClass]
    public class LiberacaoCreditoHandlerTest
    {
        [TestMethod]
        public void DeveRetornarErroQuandoLiberarCreditoDiretoComDadosVazios() 
        {
            var handler = new LiberacaoCreditoHandler();
            var command = new LiberacaoCreditoDiretoCommand();
            command.ValorCredito = "";
            command.Parcelas = "";
            command.PrimeiroVencimento = "";

            var result = handler.Handle(command);
            Assert.AreEqual(true, command.Invalid);
        }
        [TestMethod]
        public void DeveRetornarErroQuandoLiberarCreditoDiretoComDadosInvalidos()
        {
            var handler = new LiberacaoCreditoHandler();
            var command = new LiberacaoCreditoDiretoCommand();
            command.ValorCredito = "safasf";
            command.Parcelas = "1234";
            command.PrimeiroVencimento = "erro";

            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(false, result.Success);
        }
        [TestMethod]
        public void NaoAprovarCreditoDiretoAcimaDe1milhao()
        {
            var handler = new LiberacaoCreditoHandler();
            var command = new LiberacaoCreditoDiretoCommand();
            command.ValorCredito = "1.000.001,00";
            command.Parcelas = "10";
            command.PrimeiroVencimento = DateTime.Now.AddDays(30).ToString();

            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(true, ((Direto)result.Data).Status.Equals(EStatusLiberacaoCredito.Recusado));
        }
        [TestMethod]
        public void NaoAprovarCreditoDireto4Parcelas()
        {
            var handler = new LiberacaoCreditoHandler();
            var command = new LiberacaoCreditoDiretoCommand();
            command.ValorCredito = "1.000.000,00";
            command.Parcelas = "4";
            command.PrimeiroVencimento = DateTime.Now.AddDays(30).ToString();

            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(true, ((Direto)result.Data).Status.Equals(EStatusLiberacaoCredito.Recusado));
        }
        [TestMethod]
        public void NaoAprovarCreditoDiretoForaDeVencimento()
        {
            var handler = new LiberacaoCreditoHandler();
            var command = new LiberacaoCreditoDiretoCommand();
            command.ValorCredito = "1.000.000,00";
            command.Parcelas = "5";
            command.PrimeiroVencimento = DateTime.Now.AddDays(41).ToString();

            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(true, ((Direto)result.Data).Status.Equals(EStatusLiberacaoCredito.Recusado));
        }
        [TestMethod]
        public void NaoAprovarCreditoJuridicoValorMinimo()
        {
            var handler = new LiberacaoCreditoHandler();
            var command = new LiberacaoCreditoJuridicaCommand();
            command.ValorCredito = "14.999,00";
            command.Parcelas = "5";
            command.PrimeiroVencimento = DateTime.Now.AddDays(30).ToString();

            var result = (CommandResult)handler.Handle(command);
            Assert.AreEqual(true, ((Juridica)result.Data).Status.Equals(EStatusLiberacaoCredito.Recusado));
        }
        //[TestMethod]
        //public void DeveRetornarErroQuandoLiberarCreditoDiretoVencimentoInvalido()
        //{
        //    var handler = new LiberacaoCreditoHandler();
        //    var command = new LiberacaoCreditoDiretoCommand();
        //    command.ValorCredito = "950.000,00";
        //    command.Parcelas = "4";
        //    command.PrimeiroVencimento = DateTime.Now.AddDays(30).ToString();

        //    var result = handler.Handle(command);
        //    Assert.AreEqual(true, command.Invalid);
        //}
        //[TestMethod]
        //public void DeveRetornarSucessoQuandoLiberarCreditoDireto()
        //{
        //    var handler = new LiberacaoCreditoHandler();
        //    var command = new LiberacaoCreditoDiretoCommand();
        //    command.ValorCredito = "10000";
        //    command.Parcelas = "10";
        //    command.PrimeiroVencimento = DateTime.Now.AddDays(30).ToString();

        //    var result = handler.Handle(command);
        //    Assert.AreEqual(true, command.Valid);
        //}


    }
}
