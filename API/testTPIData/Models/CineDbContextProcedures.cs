﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using testTPIData.Models;

namespace testTPIData.Models
{
    public partial class CineDbContext
    {
        private ICineDbContextProcedures _procedures;

        public virtual ICineDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new CineDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ICineDbContextProcedures GetProcedures()
        {
            return Procedures;
        }
    }

    public partial class CineDbContextProcedures : ICineDbContextProcedures
    {
        private readonly CineDbContext _context;

        public CineDbContextProcedures(CineDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<INGRESOS_MENSUALES_X_FUNCResult>> INGRESOS_MENSUALES_X_FUNCAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<INGRESOS_MENSUALES_X_FUNCResult>("EXEC @returnValue = [dbo].[INGRESOS_MENSUALES_X_FUNC]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<PELICULAS_ATP_BARATO_Y_CAROResult>> PELICULAS_ATP_BARATO_Y_CAROAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<PELICULAS_ATP_BARATO_Y_CAROResult>("EXEC @returnValue = [dbo].[PELICULAS_ATP_BARATO_Y_CARO]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<RecuperarCapacidadYEntradasVendidasResult>> RecuperarCapacidadYEntradasVendidasAsync(int? id_funcion, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "id_funcion",
                    Value = id_funcion ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<RecuperarCapacidadYEntradasVendidasResult>("EXEC @returnValue = [dbo].[RecuperarCapacidadYEntradasVendidas] @id_funcion = @id_funcion", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<RecuperarFuncionesNoSubtituladasHoyResult>> RecuperarFuncionesNoSubtituladasHoyAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<RecuperarFuncionesNoSubtituladasHoyResult>("EXEC @returnValue = [dbo].[RecuperarFuncionesNoSubtituladasHoy]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<RecuperarFuncionesSubtituladasHoyResult>> RecuperarFuncionesSubtituladasHoyAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<RecuperarFuncionesSubtituladasHoyResult>("EXEC @returnValue = [dbo].[RecuperarFuncionesSubtituladasHoy]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<SP_PELICULAS_ENT_FUNCResult>> SP_PELICULAS_ENT_FUNCAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SP_PELICULAS_ENT_FUNCResult>("EXEC @returnValue = [dbo].[SP_PELICULAS_ENT_FUNC]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<SP_RESUMEN_POSICIONESResult>> SP_RESUMEN_POSICIONESAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SP_RESUMEN_POSICIONESResult>("EXEC @returnValue = [dbo].[SP_RESUMEN_POSICIONES]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<TOP10Result>> TOP10Async(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<TOP10Result>("EXEC @returnValue = [dbo].[TOP10]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
