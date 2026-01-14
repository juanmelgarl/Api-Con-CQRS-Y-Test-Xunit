using System;
using System.Collections.Generic;

namespace ApiGestion.Models;

public partial class Foto
{
    public int Idfoto { get; set; }

    public byte[] Imagen { get; set; } = null!;

    public int Idmascota { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateOnly Fecha { get; set; }
}
