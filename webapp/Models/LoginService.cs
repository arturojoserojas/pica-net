
using webapp.Models;

public class LoginService : ILoginService{

    bool ILoginService.autenticacion(LoginModel model)
    {
        return model.Email == "arojasg@gmail.com" && model.Password == "123456";
    }
}