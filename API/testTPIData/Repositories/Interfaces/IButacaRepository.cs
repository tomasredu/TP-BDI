using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTPIData.Models;

namespace testTPIData.Repositories.Interfaces
{
    public interface IButacaRepository
    {
        List<Butaca> GetAll();
        bool Create(Butaca butaca);
        Task<List<SP_RESUMEN_POSICIONESResult>> GetResumen();
    }
}
