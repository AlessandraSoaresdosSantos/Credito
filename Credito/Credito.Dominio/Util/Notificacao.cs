using Credito.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Credito.Dominio
{
    public class Notificacao
    {
         public string Mensagem { get; }
         
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
     }
 }
