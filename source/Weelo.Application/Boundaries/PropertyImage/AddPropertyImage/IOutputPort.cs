namespace Weelo.Application.Boundaries.PropertyImage.AddPropertyImage
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(AddPropertyImageOutput output, string message);
    }
}