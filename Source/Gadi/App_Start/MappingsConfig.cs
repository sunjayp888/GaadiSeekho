//using AutoMapper;

using AutoMapper;
using Gadi.Business.Models;

namespace Gadi
{
    public class MappingsConfig
    {
        public static IMapper Initialize()
        {
            var mapperConfiguration = new MapperConfiguration(Configure);

            return mapperConfiguration.CreateMapper();
        }

        private static void Configure(IMapperConfigurationExpression config)
        {
            //config.CreateMap<Entity.DocumentCategory, DocumentCategory>();
            //config.CreateMap<DocumentCategory, Entity.DocumentCategory>();

            //config.CreateMap<Document, Entity.DocumentDetail>()
            //    .ForMember(destination => destination.Description, source => source.MapFrom(s => s.Description));
            //;
            //config.CreateMap<Entity.DocumentDetail, Document>();
            
            //Driving School
            config.CreateMap<Data.Entities.DrivingSchool, DrivingSchool>();
            config.CreateMap<DrivingSchool, Data.Entities.DrivingSchool>();

        }
    }
}
