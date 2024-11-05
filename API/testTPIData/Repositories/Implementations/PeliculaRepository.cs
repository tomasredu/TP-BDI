using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTPIData.Models;
using testTPIData.Repositories.Interfaces;

namespace testTPIData.Repositories.Implementations
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly CineDbContext _context;
        public PeliculaRepository( CineDbContext context)
        {
            _context = context;
        }
        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.ToList();
        }

        public List<Pelicula> GetByFecha(DateTime fecha)
        {
            return _context.Peliculas.Where(p => fecha >= p.FechaEstreno && fecha <= p.FechaBaja).ToList();
        }

        

    }
}
