using System.Linq;
using AutoMapper;
using Vegas.Controllers.Resources;
using Vegas.Models;

namespace Vegas.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resources
            CreateMap<Make,MakeResource>();
            CreateMap<Model,ModelResource>();
            CreateMap<Features,FeaturesResource>();
            CreateMap<Vehicle,VehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom( v => new ContactResource { Name = v.ContactName , Email = v.ContactEmail , Phone = v.ContactPhone})).ForMember(vr => vr.Features, opt => opt.MapFrom( v => v.Features.Select(vf => vf.FeatureId)));

            //API Resources to Domain
            //this is how you map objects when they have different nams
            CreateMap<VehicleResource,Vehicle>()
            .ForMember(v => v.ContactName,opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail,opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select( id => new VehicleFeature { FeatureId = id})));
        }
    }
}