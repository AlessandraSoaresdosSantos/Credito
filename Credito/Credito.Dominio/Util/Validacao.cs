using System;
using System.Collections.Generic;
using System.Text;

namespace Credito.Dominio.Util
{
    public class Validacao
    {
        public static double ValorMaximoLiberado { get { return Constantes.VALOR_MAXIMO_LIBERADO; } }
        public static double QtdeParcelaMaxima { get { return Constantes.QTDE_PARCELA_MAXIMA; } }
        public static double QtdeParcelaMinima { get { return Constantes.QTDE_PARCELA_MINIMA; } }
        public static double CreditoPessoaJuridicaValorMinimo { get { return Constantes.CREDITO_PESSOA_JURIDICA_VALOR_MINIMO; } }
        public static int QtdeDiasMinimoVencimento { get { return Constantes.QTDE_DIAS_MINIMO_VENCIMENTO; } }
        public static int QtdeDiasMaximoVencimento { get { return Constantes.QTDE_DIAS_MAXIMO_VENCIMENTO; } }

        public static string ValorMaximoEmprestimo { get { return Constantes.VALOR_MAXIMO_EMPRESTIMO; } }
        public static string QuantidadeMaximaParcelas { get { return Constantes.QUANTIDADE_MAXIMA_PARCELAS; } }
        public static string QuantidadeMinimaParcelas { get { return Constantes.QUANTIDADE_MINIMA_PARCELAS; } }
        public static string PessoaJuridicaValorMinimoLiberado { get { return Constantes.PESSOA_JURIDICA_VALOR_MINIMO_LIBERADO; } }
        public static string DataVencimentoMinimo { get { return Constantes.DATA_VENCIMENTO_MINIMO_15_DIAS; } }
        public static string DataVencimentoMaximo { get { return Constantes.DATA_VENCIMENTO_MAXIMO_40_DIAS; } }

    }
}
