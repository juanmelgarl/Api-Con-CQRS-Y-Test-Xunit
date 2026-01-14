namespace ApiGestion.DTOS.Request
{
    public class CreateDTO
    {
        public string Nombre { get; set; } = null!;

        public int Dni { get; set; }

        public string Direccion { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Telefono { get; set; }
    }
}
