namespace Weelo.Application.UseCases.Login
{
    using System.Threading.Tasks;
    using Weelo.Application.Boundaries.Login;
    using Weelo.Domain;
    using Weelo.Domain.Models;
    
    public class LoginUseCase : IUseCase
    {
        private readonly IOutputPort _outputHandler;

        public LoginUseCase(IOutputPort outputPort) {
            _outputHandler = outputPort;
        }

        public async Task Execute(LoginInput input)
        {
            await Task.Run(() => {
                if (input.Data.Username.Equals(Constants.USERNAME) && input.Data.Password.Equals(Constants.PASSWORD))
                {
                    var data = new User()
                    {
                        Username = input.Data.Username,
                        Name = "Administrador",
                        Email = "admin@weelo.com"
                    };                

                    LoginOutput output = new LoginOutput(data);
                    _outputHandler.Default(output, Constants.LOGIN_USER_LOGGED);
                }
                else
                {
                    _outputHandler.NotFound(Constants.LOGIN_USER_NOT_FOUND);
                }
            });            
        }
    }
}