namespace Weelo.Application.Boundaries.Property.GetAllProperties
{
    public interface IOutputPort : IErrorHandler
    {
        void NotFound(string message);
        void Default(GetAllPropertiesOutput output, string message);
    }
}