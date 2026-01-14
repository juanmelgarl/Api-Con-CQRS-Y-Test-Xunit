using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Raza
{
    public int Idraza { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Taamaño { get; set; }
}
