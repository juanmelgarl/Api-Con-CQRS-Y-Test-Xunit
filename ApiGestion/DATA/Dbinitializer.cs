using ApiGestion.Models;
using BCrypt.Net;

namespace ApiGestion.DATA
{
    public static class Dbinitializer
    {
        public static void SEEDadmin(IApplicationBuilder app)
        {
            using var scope  = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ClinicaContext>();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            if (context.Usuarios.Any(u => u.Rol == "Admin"))
            {
                return;
            }
            var admin = new Usuarios
            {
                Email = configuration["AdminSeed:Email"]!,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(
               configuration["AdminSeed:Password"]
           ),
                Rol = configuration["AdminSeed:Rol"]!,
                Activo = true,
                FechaCreacion = DateTime.Now,
                 Nombre = "Administrador"
            };
            context.Usuarios.Add(admin);
            context.SaveChanges();
        }
    }
}
