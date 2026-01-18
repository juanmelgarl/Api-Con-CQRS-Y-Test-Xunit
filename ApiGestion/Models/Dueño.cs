using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiGestion.Models;

public partial class Dueño
{
    [Key]
    public int Iddueño { get; set; }

    public string Nombre { get; set; } = null!;

    public int Dni { get; set; }

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Telefono { get; set; }
}
