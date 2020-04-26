using System;
using System.Collections.Generic;
using System.Text;

namespace Credito.Dominio.Interfaces
{
    public interface ICreditoServico
    {
        Credito CalcularCredito(Credito credito);
    }  
}
