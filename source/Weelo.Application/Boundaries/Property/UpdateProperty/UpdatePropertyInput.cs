namespace Weelo.Application.Boundaries.Property.UpdateProperty
{
    using Weelo.Domain.Models;

    public sealed class UpdatePropertyInput
    {
        public Property Data { get; }

        public UpdatePropertyInput(Property data)
        {
            Data = data;
        }
    }
}