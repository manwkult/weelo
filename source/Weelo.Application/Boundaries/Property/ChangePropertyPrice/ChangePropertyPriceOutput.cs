namespace Weelo.Application.Boundaries.Property.ChangePropertyPrice
{
    public sealed class ChangePropertyPriceOutput
    {
        public bool Data { get; }

        public ChangePropertyPriceOutput(bool data)
        {
            Data = data;
        }
    }
}