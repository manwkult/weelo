namespace Weelo.Application.Boundaries.Login
{
    using Weelo.Domain.Models;

    public sealed class LoginInput
    {
        public User Data { get; }

        public LoginInput(User data)
        {
            Data = data;
        }
    }
}