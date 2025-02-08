using System;
using System.Collections.Generic;

namespace AppAngular.Server.Models;

public partial class Transaccion
{
    public decimal Idtransaction { get; set; }

    public decimal? Idusuario { get; set; }

    public decimal? Monto { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
