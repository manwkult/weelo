namespace Weelo.Application.Boundaries.Property.UpdateProperty
{
    public interface IOutputPort : IErrorHandler
    {
        void Default(UpdatePropertyOutput output, string message);
    }
}