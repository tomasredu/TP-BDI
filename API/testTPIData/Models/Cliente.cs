﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace testTPIData.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateTime? FecAfiliacion { get; set; }

    public int? NumeroDoc { get; set; }

    public int? IdTipoDoc { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual TiposDoc IdTipoDocNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}