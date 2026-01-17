namespace ApiGestion.Repository
{
    public interface IauthService
    {
        string GenerarToken(string username, string rol);
        string Login(string email, string password);

    }
}
