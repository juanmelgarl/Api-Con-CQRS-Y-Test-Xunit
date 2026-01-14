using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Tratamiento
{
    public string Idtratamiento { get; set; } = null!;

    public int Idconsultas { get; set; }

    public int Duracoin { get; set; }

    public string Dosis { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public string? Idmedicamento { get; set; }
}
