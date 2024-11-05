using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTPIData.Models;
using testTPIData.Repositories.Interfaces;

namespace testTPIData.Repositories.Implementations
{
    public class FuncionRepository : IFuncionRepository
    {
        public readonly CineDbContext _context;

        public FuncionRepository( CineDbContext context)
        {
            _context = context;
        }
        public bool Create(Funcione funcion)
        {
            _context.Add(funcion);
            return _context.SaveChanges() > 0;
        }
        public List<Funcione> GetFunciones()
        {
            return _context.Funciones.Where(f => f.Horario > DateTime.Now && DateTime.Now > f.FechaAlta).ToList();
        }
    }
}
