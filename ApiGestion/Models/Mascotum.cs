using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Mascotum
{
    public int Idmascota { get; set; }

    public decimal Peso { get; set; }

    public string? Raza { get; set; }

    public string Color { get; set; } = null!;

    public string Señas { get; set; } = null!;

    public int Iddueño { get; set; }

    public int? Idraza { get; set; }
}
