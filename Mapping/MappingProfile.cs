using AutoMapper;
using vega.Controllers.Resources;
using Vega.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace vega.Mapping
{
    public class MappingProfile:Profile
    {
              public MappingProfile()
        {

            //Domain to Api Resource
            CreateMap<Make,MakeResource>();
            CreateMap<Model,KeyValuePairResource>();
            CreateMap<Feature,KeyValuePairResource>();
            CreateMap<Vehicle,SaveVehicleResource>()
            .ForMember(vr=>vr.Contact,opt =>opt.MapFrom(v=>new ContactResource{Name=v.ContactName,Email=v.ContactEmail,Phone=v.ContactPhone}))
            .ForMember(vr=>vr.Features,opt=>opt.MapFrom(v=>v.features.Select(vf=>vf.FeatureId)));
            CreateMap<Vehicle,VehicleResource>()
            .ForMember(vr =>vr.Make,opt =>opt.MapFrom(v => v.Model.Make))
            .ForMember(vr=>vr.Contact,opt =>opt.MapFrom(v=>new ContactResource{Name=v.ContactName,Email=v.ContactEmail,Phone=v.ContactPhone}))
            .ForMember(vr=>vr.Features,opt=>opt.MapFrom(v=>v.features.Select(vf=>new KeyValuePairResource{Id=vf.Feature.Id,Name=vf.Feature.Name})));

            //Api resource to Domain
            CreateMap<SaveVehicleResource,Vehicle>()
            .ForMember(v=>v.Id,opt=>opt.Ignore())
            .ForMember(v=>v.ContactName,opt=>opt.MapFrom(vr=>vr.Contact.Name))
            .ForMember(v=>v.ContactEmail,opt=>opt.MapFrom(vr=>vr.Contact.Email))
            .ForMember(v=>v.ContactPhone,opt=>opt.MapFrom(vr=>vr.Contact.Phone))
            .ForMember(v=>v.features,opt=>opt.Ignore())
            .AfterMap((vr,v)=>{
            
            //Remove unselected features
            // var removedFeatures=new List<VehicleFeatures>();
            //  foreach (var f in v.features)
            //  {
            //      if (!vr.Features.Contains(f.FeatureId))
            //      {
            //         removedFeatures.Add(f);
            //      }
            //  }
             var removedFeatures=v.features.Where(f=>!vr.Features.Contains(f.FeatureId));

             foreach (var f in removedFeatures)
             {
                 v.features.Remove(f);
             }



             //Add new Features
            //  foreach (var id in vr.Features)
            //  {

            //   if(!v.features.Any(f=>f.FeatureId==id))   
            //   {
            //       v.features.Add(new VehicleFeatures{FeatureId=id});
            //   }
            //  }
       

             var addedFeatures=vr.Features.Where(id=>!v.features.Any(f=>f.FeatureId==id)).Select(id=>new VehicleFeatures{FeatureId=id});
             foreach (var f in addedFeatures)
             {
                 v.features.Add(f);
             }
            });
            
}
    }
}