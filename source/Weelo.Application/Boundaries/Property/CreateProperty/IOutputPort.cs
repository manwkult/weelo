namespace Weelo.Application.Boundaries.Property.CreateProperty
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(CreatePropertyOutput output, string message);
    }
}