namespace Weelo.Application.Boundaries.Property.DeleteProperty
{
    using Weelo.Domain.Models;

    public sealed class DeletePropertyInput
    {
        public long Id { get; }

        public DeletePropertyInput(long id)
        {
            Id = id;
        }
    }
}