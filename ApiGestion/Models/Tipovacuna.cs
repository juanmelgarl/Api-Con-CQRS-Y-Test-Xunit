using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Tipovacuna
{
    public int Idtipovacuna { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }
}
