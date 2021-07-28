namespace Weelo.Application.Boundaries.Owner.CreateOwner
{
    public sealed class CreateOwnerOutput
    {
        public object Data { get; }

        public CreateOwnerOutput(object data)
        {
            Data = data;
        }
    }
}