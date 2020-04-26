using Credito.Dominio.Interfaces;
using Credito.Dominio.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Credito.Dominio.Services
{
    public class ValidacaoServico : IValidacaoServico
    {
        private readonly NotificacaoContexto _notificacaoContexto;

        public ValidacaoServico(NotificacaoContexto notificacaoContexto, Credito credito)
        {
            _notificacaoContexto = notificacaoContexto;
            ValorMaximoLiberado(credito.Valor);
            ParcelaMaxima(credito.QuantidadeParcela);
            ParcelaMinima(credito.QuantidadeParcela);
            PessoaJuridicaValorMinimoLiberado(credito);
            DataPrimeiroVencimentoMinimo(credito.DataPrimeiroVencimento);
            DataPrimeiroVencimentoMaximo(credito.DataPrimeiroVencimento);
        }


        private void ValorMaximoLiberado(double valor)
        {
            if (valor > Validacao.ValorMaximoLiberado)
            {
                _notificacaoContexto.AdicionarNotificacao(Validacao.ValorMaximoEmprestimo);
            }
        }

        private void ParcelaMaxima(int parcela)
        {
            if (parcela > Validacao.QtdeParcelaMaxima)
            {
                _notificacaoContexto.AdicionarNotificacao(Validacao.QuantidadeMaximaParcelas);

            }
        }

        private void ParcelaMinima(int parcela)
        {
            if (parcela < Validacao.QtdeParcelaMinima)
            {
                _notificacaoContexto.AdicionarNotificacao(Validacao.QuantidadeMinimaParcelas);

            }
        }

        private void PessoaJuridicaValorMinimoLiberado(Credito credito)
        {
            if (credito.CreditoTipo == TipoCredito.CreditoPessoaJuridica) {
                if (credito.Valor < Validacao.CreditoPessoaJuridicaValorMinimo)
                {
                    _notificacaoContexto.AdicionarNotificacao(Validacao.PessoaJuridicaValorMinimoLiberado);

                }
            }
        }

        private void DataPrimeiroVencimentoMinimo(DateTime dataVencimento)
        {
            int qtdeDiasMinimo = Validacao.QtdeDiasMinimoVencimento;
          
            DateTime dataMinimo = DateTime.Now.AddDays(qtdeDiasMinimo);
           
            if (dataVencimento.CompareTo(dataMinimo) < 0)
            {
                _notificacaoContexto.AdicionarNotificacao(Validacao.DataVencimentoMinimo);

            }
              
        }

        private void DataPrimeiroVencimentoMaximo(DateTime dataVencimento)
        {
              int qtdeDiasMaximo = Validacao.QtdeDiasMaximoVencimento;

              DateTime dataMaximo = DateTime.Now.AddDays(qtdeDiasMaximo);

            if (dataVencimento.CompareTo(dataMaximo) > 0)
            {
                _notificacaoContexto.AdicionarNotificacao(Validacao.DataVencimentoMaximo);

            }                                         
        }
    }
}
