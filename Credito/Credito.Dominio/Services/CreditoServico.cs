using Credito.Dominio.Interfaces;
using Credito.Dominio.Util;
using System.Threading.Tasks;

namespace Credito.Dominio.Services
{
    public class CreditoServico : ICreditoServico
    {
        ICreditoCalculo _creditoCalculo = null;
        public CreditoServico()
        {

        }
        public Credito CalcularCredito(Credito credito)
        {
            try
            {
                FabricaCredito fabricaCredito = new FabricaCredito();
                this._creditoCalculo = fabricaCredito.ObtemCreditoCalculo(credito.CreditoTipo);

                return this._creditoCalculo.ExecutaCalculo(credito);
            }
            catch
            {
                return new Credito();
            }
        }

    }
}
