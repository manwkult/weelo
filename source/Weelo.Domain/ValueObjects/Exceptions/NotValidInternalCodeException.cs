namespace Weelo.Domain.ValueObjects.Exceptions
{
    public sealed class NotValidInternalCodeException : DomainException
    {
        internal NotValidInternalCodeException(string message) : base(message) { }
    }
}