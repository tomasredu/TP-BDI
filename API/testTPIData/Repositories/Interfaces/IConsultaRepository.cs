using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTPIData.Models;

namespace testTPIData.Repositories.Interfaces
{
    public interface IConsultaRepository
    {
        Task<List<TOP10Result>> RecuperarTop10();
        Task<List<RecuperarFuncionesNoSubtituladasHoyResult>> RecuperarFuncionesNoSubtituladasHoy();
        Task<List<RecuperarFuncionesSubtituladasHoyResult>> RecuperarFuncionesSubtituladasHoy();
        Task<List<RecuperarCapacidadYEntradasVendidasResult>> RecuperarCapacidadYEntradasVendidasResults(int id);

        Task<List<SP_PELICULAS_ENT_FUNCResult>> RecuperarPeliculasSegunEntradasXFuncion();

        Task<IEnumerable<Consulta8Result>> GetReservasPorAnioAsync(int anio);
        Task<Consulta7Result> ObtenerEstadoReservasPorIdiomaAsync(int idIdioma);

        List<Idioma> GetIdiomas();
    }
}
