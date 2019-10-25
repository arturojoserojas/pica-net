
using webapp.Models;

public class LoginService : ILoginService{
    private bool autenticado;
    bool ILoginService.autenticacion(LoginModel model)
    {
        autenticado = model.Email == "arojasg@gmail.com" && model.Password == "123456";
        return autenticado;
    }
}