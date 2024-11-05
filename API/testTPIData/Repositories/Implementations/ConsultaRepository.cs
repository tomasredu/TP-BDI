using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTPIData.Models;
using testTPIData.Repositories.Interfaces;

namespace testTPIData.Repositories.Implementations 
{
    public class ConsultaRepository : IConsultaRepository
    {
        private CineDbContext _context;
        public ConsultaRepository(CineDbContext context)
        {
            _context = context;
        }

        public List<Idioma> GetIdiomas()
        {
            return _context.Idiomas.ToList();
        }


        public async Task<List<RecuperarFuncionesSubtituladasHoyResult>> RecuperarFuncionesSubtituladasHoy()
        {
            return await _context.Procedures.RecuperarFuncionesSubtituladasHoyAsync();
        }

        public async Task<List<RecuperarFuncionesNoSubtituladasHoyResult>> RecuperarFuncionesNoSubtituladasHoy()
        {
            return await _context.Procedures.RecuperarFuncionesNoSubtituladasHoyAsync();
        }
        public async Task<List<RecuperarCapacidadYEntradasVendidasResult>> RecuperarCapacidadYEntradasVendidasResults(int id)
        {
            return await _context.Procedures.RecuperarCapacidadYEntradasVendidasAsync(id);
        }

        public async Task<List<TOP10Result>> RecuperarTop10()
        {
            return await _context.Procedures.TOP10Async();
        }

        //CONSULTA 7
        public async Task<Consulta7Result> ObtenerEstadoReservasPorIdiomaAsync(int idIdioma)
        {
            var resultados = await _context.Entradas
            .Where(e => e.IdReservaNavigation.EstadoPago == true &&
                    e.IdReservaNavigation.FechaPago < e.IdFuncionNavigation.Horario &&
                    e.IdFuncionNavigation.IdIdioma == idIdioma)
            .Select(e => new
            {
                Precio = e.Precio,
                Descuento = _context.Promociones
                .Where(p => p.IdPromocion == e.IdPromocion)
                .Select(p => p.Descuento)
                .FirstOrDefault()
            })
            .ToListAsync();

            var totalButacasOcupadas = resultados.Count();
            var ingresosTotales = (decimal)resultados.Sum(x => x.Precio * (x.Descuento ?? 1));

            return new Consulta7Result
            {
                TotalButacasOcupadas = totalButacasOcupadas,
                IngresosTotales = ingresosTotales
            };
        }



        //CONSULTA 8
        public async Task<IEnumerable<Consulta8Result>> GetReservasPorAnioAsync(int anio)
        {
            var fechaActual = DateTime.Now;

            // Consultar confirmados
            var confirmados = await _context.Reservas
                .Where(r => r.EstadoPago == true &&
                            r.FechaEmision.Value.Year == anio &&
                            r.FechaEmision < fechaActual)
                .Select(r => r.IdCliente)
                .Distinct()
                .CountAsync();

            // Consultar no confirmados
            var noConfirmados = await _context.Reservas
                .Where(r => r.EstadoPago == false &&
                            r.FechaEmision.Value.Year == anio &&
                            r.FechaEmision < fechaActual)
                .Select(r => r.IdCliente)
                .Distinct()
                .CountAsync();

            var resultados = new List<Consulta8Result>
            {
                new Consulta8Result { EstadoReserva = "Confirmados", CantidadClientes = confirmados },
                new Consulta8Result { EstadoReserva = "No confirmados", CantidadClientes = noConfirmados }
            };

            return resultados;
        }

        public async Task<List<SP_PELICULAS_ENT_FUNCResult>> RecuperarPeliculasSegunEntradasXFuncion()
        {
            return await _context.Procedures.SP_PELICULAS_ENT_FUNCAsync();
        }
    }
}
