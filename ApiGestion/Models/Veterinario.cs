using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Veterinario
{
    public int Idveterinario { get; set; }

    public string Nombre { get; set; } = null!;

    public int Telefono { get; set; }

    public string Email { get; set; } = null!;

    public int Nummatricula { get; set; }

    public int Idespecialidad { get; set; }
}
