using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Consulta
{
    public int Idconsultas { get; set; }

    public DateOnly Fecha { get; set; }

    public DateTime Hora { get; set; }

    public string Motivo { get; set; } = null!;

    public decimal Peso { get; set; }

    public int Idveterinario { get; set; }

    public int Idmascota { get; set; }
}
