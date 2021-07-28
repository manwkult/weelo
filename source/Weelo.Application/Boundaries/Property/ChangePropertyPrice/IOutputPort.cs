namespace Weelo.Application.Boundaries.Property.ChangePropertyPrice
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(ChangePropertyPriceOutput output, string message);
    }
}