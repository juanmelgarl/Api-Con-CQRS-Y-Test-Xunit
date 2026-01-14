using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Especie
{
    public int IdEspecie { get; set; }

    public bool Perro { get; set; }

    public bool Gato { get; set; }

    public bool Loro { get; set; }

    public int Idmascota { get; set; }
}
