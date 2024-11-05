using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTPIData.Models;
using testTPIData.Repositories.Interfaces;

namespace testTPIData.Repositories.Implementations
{
    public class ButacaRepository : IButacaRepository
    {
        private readonly CineDbContext _context;
        public ButacaRepository( CineDbContext context)
        {
            _context = context;
        }

        public bool Create( Butaca butaca)
        {
            _context.Butacas.Add(butaca);
            return _context.SaveChanges() > 0;
        }

        public List<Butaca> GetAll()
        {
            return _context.Butacas.ToList();
        }

        async public Task<List<SP_RESUMEN_POSICIONESResult>> GetResumen()
        {
            var procedures = new CineDbContextProcedures(_context);
            var result = await procedures.SP_RESUMEN_POSICIONESAsync();

            return result;

        }
    }
}
