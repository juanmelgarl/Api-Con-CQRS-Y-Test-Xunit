namespace ApiGestion.DTOS.Response
{
    public class Dueñoresponse
    {
        public int IDdueño { get; set; }
        public string? Nombre { get; set; } 

        public int Dni { get; set; }

        public string? Direccion { get; set; } 

        public string?  Email { get; set; } 
        public int Telefono { get; set; }
    }
}
