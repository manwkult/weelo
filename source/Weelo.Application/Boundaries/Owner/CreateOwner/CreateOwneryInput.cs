namespace Weelo.Application.Boundaries.Owner.CreateOwner
{
    using Weelo.Domain.Models;

    public sealed class CreateOwnerInput
    {
        public Owner Data { get; }

        public CreateOwnerInput(Owner data)
        {
            Data = data;
        }
    }
}