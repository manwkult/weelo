namespace Weelo.Application.Boundaries.Property.CreateProperty
{
    public sealed class CreatePropertyOutput
    {
        public object Data { get; }

        public CreatePropertyOutput(object data)
        {
            Data = data;
        }
    }
}