using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Apliacion
{
    public int Idaplicacionvacuna { get; set; }

    public int Idvacuna { get; set; }

    public int Idmascotas { get; set; }

    public int Idtipovacuna { get; set; }

    public int Idveterinario { get; set; }

    public DateOnly Fecha { get; set; }
}
