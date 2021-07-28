namespace Weelo.Infrastructure.EntityFrameworkDataAccess.Mapper
{
    using AutoMapper;
    using Weelo.Domain.Models;
    using Weelo.Domain.ValueObjects;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity;
    using Weelo.Infrastructure.EntityFrameworkDataAccess.Entity.Cache;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerEntity>();
            CreateMap<OwnerEntity, Owner>();
            CreateMap<Property, PropertyEntity>();
            CreateMap<PropertyEntity, Property>();
            CreateMap<PropertyImage, PropertyImageEntity>();
            CreateMap<PropertyImageEntity, PropertyImage>();
            CreateMap<PropertyTrace, PropertyTraceEntity>();
            CreateMap<PropertyTraceEntity, PropertyTrace>();

            CreateMap<OwnerCache, OwnerEntity>();
            CreateMap<OwnerEntity, OwnerCache>();
            CreateMap<PropertyCache, PropertyEntity>().ForMember(x => x.InternalCode, options => options.MapFrom(p => new ValidInternalCode(p.InternalCode)));
            CreateMap<PropertyEntity, PropertyCache>().ForMember(x => x.InternalCode, options => options.MapFrom(p => p.InternalCode.Value()));
            CreateMap<PropertyImageCache, PropertyImageEntity>();
            CreateMap<PropertyImageEntity, PropertyImageCache>();
            CreateMap<PropertyTraceCache, PropertyTraceEntity>();
            CreateMap<PropertyTraceEntity, PropertyTraceCache>();
        }
    }
}