using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Core.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Make Mapping
            CreateMap<Make,MakeResource>();
            CreateMap<MakeResource,Make>();
            
            //Model Mapping
            CreateMap<Model, KeyValuePairResource>();

            //Features Mapping
            CreateMap<Features, KeyValuePairResource>();

            //Vehicle Mapping
            CreateMap<Vehicle, SaveVehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle,VehicleResource>()
            .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResource { Id = vf.Feature.Id , Name = vf.Feature.Name})));
            CreateMap<SaveVehicleResource, Vehicle>()
            .ForMember(v => v.Id,opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt.Ignore())
            .AfterMap((vr,v) => {
            // Remove unselected feature
                var removedFeatures =  v.Features.Where(f =>  !vr.Features.Contains(f.FeatureId));
                foreach(var f in removedFeatures)
                    v.Features.Remove(f);

                // Add new features
                 var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature{FeatureId = id});
                foreach (var f in addedFeatures)
                    v.Features.Add(f);
            });

            // Skills Mapping
            // CreateMap<Skills,SkillsResource>().ReverseMap();
            // // Fighter Mapping
            // CreateMap<Fighter,FighterResource>()
            // .ForMember(fr => fr.Skills,opt => opt.MapFrom(f => f.Skills.Select( fv => new SkillsResource {Id = fv.Skills.Id, AttackRange = fv.Skills.AttackRange, Description =fv.Skills.Description, Name = fv.Skills.Name  })));
            

            // CreateMap<SaveFighterResource,Fighter>()
            //     .ForMember(f => f.Id,opt => opt.Ignore())
            //     .ForMember(f => f.Skills,opt => opt.Ignore())
            //     /* Below I am projecting the two variables fr and f which are of type SaveFighterResource and Fighter respectively */
            //     .AfterMap((fr,f)=>{
            //         /* Remove unselected skills */
            //         /* Here I am finding all the related entities and its properties(Skills in this case) */
            //         var removedSkills = f.Skills.Where(x => !fr.Skills.Contains(x.SkillId));
            //         foreach(var s in removedSkills)
            //             f.Skills.Remove(s);

            //         var addedSkills = fr.Skills.Where(id => !f.Skills.Any(fi => fi.SkillId == id)).Select(id => new FighterSkill {SkillId = id});
            //         foreach(var s in addedSkills){
            //             f.Skills.Add(s);
            //         }
            //     });                        
        }
    }
}