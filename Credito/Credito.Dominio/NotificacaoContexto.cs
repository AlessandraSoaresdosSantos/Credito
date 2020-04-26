using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Credito.Dominio
{
   public class NotificacaoContexto
	{
		private readonly List<Notificacao> _notificacao;
		public IReadOnlyCollection<Notificacao> Notificacao => _notificacao;
		public bool PossuiNotificacao => _notificacao.Any();

		public NotificacaoContexto()
		{
			_notificacao = new List<Notificacao>();
		}

		public void AdicionarNotificacao(string mensagem)
		{
			_notificacao.Add(new Notificacao(mensagem));
		}
		public   IEnumerable<string> RetornaNotificacaoFormatada(List<Notificacao> notificacaos)
		{
			return from Notificacao notificacao in notificacaos
				   select RetornaNotificacao(new Notificacao(notificacao.Mensagem ));
		}

		private static string RetornaNotificacao(Notificacao notificacao)
		{
			return string.Format("{0} \n", notificacao.Mensagem);
		}

	}
}
