using Credito.Dominio;
using Credito.Dominio.Interfaces;
using Credito.Dominio.Services;
using Credito.Dominio.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Credito
{
    public class Program
    {
        static void Main(string[] args)
        {

            var collection = new ServiceCollection();
            collection.AddScoped<NotificacaoContexto>();
            collection.AddScoped<ICreditoServico, CreditoServico>();
            collection.AddScoped<IValidacaoServico, ValidacaoServico>();

            IServiceProvider serviceProvider = collection.BuildServiceProvider();
            var notificacaoContexto = serviceProvider.GetService<NotificacaoContexto>();

            var creditoServico = new CreditoServico();
            TesteCredito1(notificacaoContexto, creditoServico);
            TesteCredito2(notificacaoContexto, creditoServico);
            Console.ReadLine();
        }

        private static void TesteCredito1(NotificacaoContexto notificacaoContexto, CreditoServico creditoServico)
        {
            Credito credito = new Credito
            {
                Valor = 12000.00,
                QuantidadeParcela = 5,
                DataPrimeiroVencimento = new DateTime(2020, 05, 30),
                CreditoTipo = TipoCredito.CreditoDireto
            };

            new ValidacaoServico(notificacaoContexto, credito);
            if (notificacaoContexto.PossuiNotificacao)
            {
                var lista = new List<Notificacao>(notificacaoContexto.Notificacao);
                Console.WriteLine(string.Join("\n",
                    notificacaoContexto.RetornaNotificacaoFormatada(lista)));
               
                credito.CreditoStatus = Status.Recusado;
                creditoServico.CalcularCredito(credito);
            }
            else
            {
                var retornoCredito = creditoServico.CalcularCredito(credito);

                Console.WriteLine("valor juros: " + retornoCredito.ValorJuros);
                Console.WriteLine("valor emprestimo: " + retornoCredito.ValorTotalJuros);
            }
        }

        private static void TesteCredito2(NotificacaoContexto notificacaoContexto, CreditoServico creditoServico)
        {
            Credito credito = new Credito
            {
                Valor = 6000.00,
                QuantidadeParcela = 3,
                DataPrimeiroVencimento = new DateTime(2020, 05, 02),
                CreditoTipo = TipoCredito.CreditoPessoaFisica
            };

            new ValidacaoServico(notificacaoContexto, credito);
            if (notificacaoContexto.PossuiNotificacao)
            {
                var lista = new List<Notificacao>(notificacaoContexto.Notificacao);
                Console.WriteLine(string.Join("\n",
                    notificacaoContexto.RetornaNotificacaoFormatada(lista)));
           
                credito.CreditoStatus = Status.Recusado;
                creditoServico.CalcularCredito(credito);
            }
            else
            {
                var retornoCredito = creditoServico.CalcularCredito(credito);

                Console.WriteLine("valor juros: " + retornoCredito.ValorJuros);
                Console.WriteLine("valor emprestimo: " + retornoCredito.ValorTotalJuros);
            }
        }
    }
}
