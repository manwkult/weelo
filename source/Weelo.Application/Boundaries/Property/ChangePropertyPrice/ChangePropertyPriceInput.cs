namespace Weelo.Application.Boundaries.Property.ChangePropertyPrice
{
    using Weelo.Domain.Models;

    public sealed class ChangePropertyPriceInput
    {
        public PropertyPrice Data { get; }

        public ChangePropertyPriceInput(PropertyPrice data)
        {
            Data = data;
        }
    }
}