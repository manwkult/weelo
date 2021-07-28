namespace Weelo.Application.Boundaries.Property.DeleteProperty
{
    public sealed class DeletePropertyOutput
    {
        public object Data { get; }

        public DeletePropertyOutput(object data)
        {
            Data = data;
        }
    }
}