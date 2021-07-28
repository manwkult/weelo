namespace Weelo.Application.Boundaries.Login
{
    using Weelo.Domain.Models;

    public sealed class LoginOutput
    {
        public User Data { get; }

        public LoginOutput(User data)
        {
            Data = data;
        }
    }
}