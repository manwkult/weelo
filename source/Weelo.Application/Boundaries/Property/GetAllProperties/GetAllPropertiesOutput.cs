namespace Weelo.Application.Boundaries.Property.GetAllProperties
{
    public sealed class GetAllPropertiesOutput
    {
        public object Data { get; }

        public GetAllPropertiesOutput(object data)
        {
            Data = data;
        }
    }
}