using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Medicamento
{
    public int Idmedicamento { get; set; }

    public string? Nombre { get; set; }

    public string? Droga { get; set; }

    public string? Presentacion { get; set; }
}
