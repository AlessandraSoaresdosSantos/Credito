using Credito.Dominio;
using Credito.Dominio.Util;
using System;

namespace Credito
{
    public class Credito
    {

        public double Valor { get; set; }
        public int QuantidadeParcela { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
        public TipoCredito CreditoTipo { get; set; }
        public double ValorTotalJuros { get; set; }
        public double ValorJuros { get; set; }
        public double TaxaJuros { get; set; }
        public Status CreditoStatus { get; set; }
    }


    public enum Status
    {
        Aprovado,
        Recusado
    }

    public enum TipoCredito {
        CreditoDireto,
        CreditoConsignado,
        CreditoPessoaJuridica,
        CreditoPessoaFisica,
        CreditoImobiliario
    }
}
