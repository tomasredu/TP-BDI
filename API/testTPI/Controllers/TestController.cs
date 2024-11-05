using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NuGet.Protocol.Core.Types;
using testTPIData.Models;
using testTPIData.Repositories.Implementations;
using testTPIData.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testTPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IButacaRepository _repoButaca;
        private readonly IPeliculaRepository _repoPeli;
        private readonly IFuncionRepository _repoFunc;
        private readonly IConsultaRepository _consultaRepository;

        public TestController( 
            IButacaRepository repoButaca, 
            IPeliculaRepository repoPeli, 
            IFuncionRepository repoFunc,
            IConsultaRepository repoConsulta
            )
        {
            _repoButaca = repoButaca;
            _repoPeli = repoPeli;
            _repoFunc = repoFunc;
            _consultaRepository = repoConsulta;
        }

        [HttpGet("todas")]
        public IEnumerable<Butaca> Get()
        {
            return _repoButaca.GetAll();
        }

        // GET api/<TestController>/5
        [HttpGet("resumen")]
        async public Task<List<SP_RESUMEN_POSICIONESResult>> GetAnalisis()
        {
            return await _repoButaca.GetResumen();
        }

        [HttpGet("funnciones")]
        public List<Funcione> GetFunciones()
        {
            return _repoFunc.GetFunciones();
        }


        [HttpGet("butacas")]
        public Dictionary<DateTime,int> GenerarButacas()
        {
            List<Pelicula> pelis = _repoPeli.GetAll();
            Dictionary<DateTime, int> pelisPorDia = new Dictionary<DateTime, int>();

            DateTime fecha = new DateTime(2023, 1, 1);

            while(fecha <= new DateTime(2024,12,30))
            {
                pelisPorDia.Add(fecha, _repoPeli.GetByFecha(fecha).Count());
                fecha = fecha.AddDays(1);
            }
            return pelisPorDia;

        }

        [HttpGet("generarFunciones")]
        public List<Funcione> GenerarFunciones()
        {
            List<Funcione> lst = new List<Funcione>();
            int vueltas = 0;
            DateTime fecha = new DateTime(2024, 7, 1);
            Decimal precioBase = 4500;
            Random r1 = new Random();
            while (fecha <= new DateTime(2024, 11, 30))
            {
                List<Pelicula> pelisEnFecha = _repoPeli.GetByFecha(fecha);

                if (pelisEnFecha.Count() > 0)
                {
                    
                    for (int i = 1; i <= 4; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            
                            int horas = 16;
                            switch (k)
                            {
                                case 1:
                                    horas = 19;
                                    break;
                                case 2:
                                    horas = 22;
                                    break;
                                default:
                                    break;
                            }

                            int indicePelicula = vueltas % pelisEnFecha.Count;
                            lst.Add(randomFunction(vueltas + 1, r1, fecha.AddHours(horas), precioBase,
                                                   pelisEnFecha[indicePelicula].IdPelicula, i));
                            vueltas++;
                        }
                    }
                    
                }
                fecha = fecha.AddDays(1);

            }
            return lst;

        }

        [HttpPost("generarFunciones")]
        public void PostearFunciones()
        {
            List<Funcione> lst = new List<Funcione>();
            int vueltas = 0;
            DateTime fecha = new DateTime(2024, 1, 1);
            Decimal precioBase = 4500;
            Random r1 = new Random();
            while (fecha <= new DateTime(2024, 12, 30))
            {
                List<Pelicula> pelisEnFecha = _repoPeli.GetByFecha(fecha);

                if (pelisEnFecha.Count() > 0)
                {

                    for (int i = 1; i <= 4; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {

                            int horas = 16;
                            switch (k)
                            {
                                case 1:
                                    horas = 19;
                                    break;
                                case 2:
                                    horas = 22;
                                    break;
                                default:
                                    break;
                            }

                            int indicePelicula = vueltas % pelisEnFecha.Count;
                            lst.Add(randomFunction(vueltas + 1, r1, fecha.AddHours(horas), precioBase,
                                                   pelisEnFecha[indicePelicula].IdPelicula, i));
                            vueltas++;
                        }
                    }

                }
                fecha = fecha.AddDays(1);

            }

            foreach (var item in lst)
            {
                try
                {
                    _repoFunc.Create(item);
                }
                catch (Exception ex)
                {

                }
            }
        }

        [HttpPost("generarButacas")]
        public void ButacasFunciones()
        {
            string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
            Random random = new Random();
            for(int i = 0; i < 4; i++)
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        Butaca b = new Butaca();
                        b.IdTipoButaca = 1;
                        b.IdSala = i + 1;
                        b.Fila = chars[col];
                        b.Columna = row + 1;
                        if(row == 0  && (col == 5 || col == 6))
                        {
                            b.IdTipoButaca = random.Next(2, 4);
                        }
                        try
                        {
                            _repoButaca.Create(b);
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                }
            }
        }

        private Funcione randomFunction(int idFuncion,Random r, DateTime fecha, Decimal precioBase, int idPelicula, int idSala)
        {
            Funcione f = new Funcione();
            //f.IdFuncion = idFuncion;
            f.IdPelicula = idPelicula;
            f.IdIdioma = r.Next(1, 5);
            f.IdSala = idSala;
            f.Horario = fecha;
            f.Subtitulada = f.IdIdioma == 1 ? false : true;
            f.PrecioActual = precioBase + ((precioBase / 10) * Math.Truncate((decimal)(fecha - new DateTime(2023, 1, 1)).Days / 100) );
            f.FechaAlta = fecha.AddDays(-14);

            return f;
        }


        [HttpGet("top-bottom")]
        public async Task<IActionResult> GetTop10()
        {
            try
            {
                return Ok(await _consultaRepository.RecuperarTop10());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("today-non-subtitled")]
        public async Task<IActionResult> GetTodayNonSubtitledFunctions()
        {
            try
            {
                return Ok(await _consultaRepository.RecuperarFuncionesNoSubtituladasHoy());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("today-subtitled")]
        public async Task<IActionResult> GetTodaySubtitledFunctions()
        {
            try
            {
                return Ok(await _consultaRepository.RecuperarFuncionesSubtituladasHoy());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("has-availability")]
        public async Task<IActionResult> GetAvailability(int id)
        {
            try
            {
                return Ok(await _consultaRepository.RecuperarCapacidadYEntradasVendidasResults(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("/Idiomas")]
        public IActionResult GetIdiomas()
        {
            try
            {
                return Ok(_consultaRepository.GetIdiomas());
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }

        [HttpGet("cantidad-reservas/{anio}")]
        public async Task<IActionResult> ObtenerEstadoReservas(int anio)
        {
            try
            {
                IEnumerable<Consulta8Result> resultados = await _consultaRepository.GetReservasPorAnioAsync(anio);

                return Ok(resultados);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        [HttpGet("reservas-idiomas")]
        public async Task<IActionResult> ObtenerEstadoReservasPorIdioma(int idIdioma)
        {
            try
            {
                var resultado = await _consultaRepository.ObtenerEstadoReservasPorIdiomaAsync(idIdioma);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al filtrar entradas: {ex.Message}");
            }
        }

        [HttpGet("entradas_funcion")]
        public async Task<IActionResult> ObtenerPeliculasSegunEntradasXFuncion()
        {
            try
            {
                var lst = await _consultaRepository.RecuperarPeliculasSegunEntradasXFuncion();
                return Ok(lst);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
                throw;
            }
        }


    }
}
