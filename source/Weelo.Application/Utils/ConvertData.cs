namespace Weelo.Application.Utils
{
    using Weelo.Domain.Models;
    
    public static class ConvertData
    {
        public static object getPropertyData(Property property)
        {
            return new {
                Id = property.Id,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                InternalCode = property.InternalCode.Value(),
                Year = property.Year,
                Owner = property.Owner,
                PropertyImages = property.PropertyImages,
                PropertyTraces = property.PropertyTraces
            };
        }
    }
}