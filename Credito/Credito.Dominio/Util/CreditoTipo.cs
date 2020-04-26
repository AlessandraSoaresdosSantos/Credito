using Credito.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credito.Dominio
{
    public class CreditoTipo
    {
        public static double CreditoDiretoPorcentagem { get { return Constantes.CREDITO_DIRETO; } }
        public static double CreditoConsignadoPorcentagem { get { return Constantes.CREDITO_CONSIGNADO; } }  
        public static double CreditoPessoaJuridicaPorcentagem { get { return Constantes.CREDITO_PESSOA_JURIDICA; } }  
        public static double CreditoPessoaFisicaPorcentagem { get { return Constantes.CREDITO_PESSOA_FISICA; } }  
        public static double CreditoImobiliarioPorcentagem { get { return Constantes.CREDITO_IMOBILIARIO; } }
                
    }

}
