namespace Weelo.Application.Boundaries.Owner.GetAllOwners
{
    public sealed class GetAllOwnersOutput
    {
        public object Data { get; }

        public GetAllOwnersOutput(object data)
        {
            Data = data;
        }
    }
}