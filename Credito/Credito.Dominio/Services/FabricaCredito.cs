using System;
using System.Collections.Generic;
using System.Text;

namespace Credito.Dominio.Services
{
    public class FabricaCredito
    {
        public virtual ICreditoCalculo ObtemCreditoCalculo(TipoCredito tipoCredito)
        {
            ICreditoCalculo _creditoCalculo = null;
            switch (tipoCredito)
            {
                case TipoCredito.CreditoDireto:
                    _creditoCalculo = new CreditoDireto();
                    break;
                case TipoCredito.CreditoConsignado:
                    _creditoCalculo = new CreditoConsignado();
                    break;
                case TipoCredito.CreditoPessoaFisica:
                    _creditoCalculo = new CreditoPessoaFisica();
                    break;
                case TipoCredito.CreditoPessoaJuridica:
                    _creditoCalculo = new CreditoPessoaJuridica();
                    break;

                case TipoCredito.CreditoImobiliario:
                    _creditoCalculo = new CreditoImobiliario();
                    break;
            }
            return _creditoCalculo;
        }

        public Credito Calculo(Credito credito)
        {
            try
            {
                if (credito.CreditoStatus.Equals(Status.Recusado))
                {
                    return credito;
                }
                credito.ValorJuros = (credito.Valor *
                                  Math.Pow((1 + credito.TaxaJuros), credito.QuantidadeParcela) * credito.TaxaJuros)
                               / (Math.Pow((1 + credito.TaxaJuros), credito.QuantidadeParcela) - 1);

                credito.ValorTotalJuros = Math.Round((credito.ValorJuros * credito.QuantidadeParcela), 2);
                credito.CreditoStatus = Status.Aprovado;

                return credito;
            }
            catch
            {
                credito.CreditoStatus = Status.Recusado;
                return credito;
            }


        }
    }

    public interface ICreditoCalculo
    {
        Credito ExecutaCalculo(Credito credito);

    }

    public class CreditoDireto : ICreditoCalculo
    {
        public Credito ExecutaCalculo(Credito credito)
        {
            credito.TaxaJuros = CreditoTipo.CreditoDiretoPorcentagem;
            return new FabricaCredito().Calculo(credito);
        }
    }

    public class CreditoConsignado : ICreditoCalculo
    {
        public Credito ExecutaCalculo(Credito credito)
        {

            credito.TaxaJuros = CreditoTipo.CreditoConsignadoPorcentagem;
            return new FabricaCredito().Calculo(credito);
        }
    }
    public class CreditoPessoaJuridica : ICreditoCalculo
    {
        public Credito ExecutaCalculo(Credito credito)
        {
            credito.TaxaJuros = CreditoTipo.CreditoPessoaJuridicaPorcentagem;
            return new FabricaCredito().Calculo(credito);
        }
    }
    public class CreditoPessoaFisica : ICreditoCalculo
    {
        public Credito ExecutaCalculo(Credito credito)
        {
            credito.TaxaJuros = CreditoTipo.CreditoPessoaFisicaPorcentagem;
            return new FabricaCredito().Calculo(credito);
        }
    }
    public class CreditoImobiliario : ICreditoCalculo
    {
        public Credito ExecutaCalculo(Credito credito)
        {
            credito.TaxaJuros = CreditoTipo.CreditoImobiliarioPorcentagem;
            return new FabricaCredito().Calculo(credito);
        }
    }



}
