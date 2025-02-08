using System;
using System.Collections.Generic;

namespace AppAngular.Server.Models;

public partial class Usuario
{
    public decimal Idusuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Email { get; set; }

    public string? Contrasena { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
