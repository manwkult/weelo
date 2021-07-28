namespace Weelo.Application.Exceptions
{
    using Weelo.Domain;

    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message) : base(message) { }
    }
}