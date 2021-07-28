namespace Weelo.Application.Boundaries.PropertyImage.AddPropertyImage
{
    using Weelo.Domain.Models;

    public sealed class AddPropertyImageInput
    {
        public PropertyImage Data { get; }

        public AddPropertyImageInput(PropertyImage data)
        {
            Data = data;
        }
    }
}