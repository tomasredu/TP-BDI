﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace testTPIData.Models
{
    public partial class SP_PELICULAS_ENT_FUNCResult
    {
        public int codigo { get; set; }
        public string pelicula { get; set; }
        public int? entradas { get; set; }
        public int? funciones { get; set; }
        [Column("ent_x_func", TypeName = "decimal(24,12)")]
        public decimal? ent_x_func { get; set; }
        [Column("recaudacion", TypeName = "decimal(38,6)")]
        public decimal? recaudacion { get; set; }
    }
}