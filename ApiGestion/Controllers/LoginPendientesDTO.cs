namespace ApiGestion.Controllers
{
    public class LoginPendientesDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
