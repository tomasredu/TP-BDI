using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTPIData.Models;


namespace testTPIData.Repositories.Interfaces
{
    public interface IFuncionRepository
    {
        bool Create(Funcione funcion);
        List<Funcione> GetFunciones();
    }
}
