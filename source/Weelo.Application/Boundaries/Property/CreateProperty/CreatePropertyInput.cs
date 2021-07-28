namespace Weelo.Application.Boundaries.Property.CreateProperty
{
    using Weelo.Domain.Models;

    public sealed class CreatePropertyInput
    {
        public Property Data { get; }

        public CreatePropertyInput(Property data)
        {
            Data = data;
        }
    }
}