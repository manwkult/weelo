namespace Weelo.Application.Boundaries.Property.UpdateProperty
{
    public sealed class UpdatePropertyOutput
    {
        public object Data { get; }

        public UpdatePropertyOutput(object data)
        {
            Data = data;
        }
    }
}