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
            config.CreateMap< Data.Entities.DocumentCategory, DocumentCategory>();
            config.CreateMap<DocumentCategory, Data.Entities.DocumentCategory>();

            config.CreateMap<Document, Data.Entities.DocumentDetail>()
                .ForMember(destination => destination.Description, source => source.MapFrom(s => s.Description));
            ;
            config.CreateMap<Data.Entities.DocumentDetail, Document>();
            
            //Driving School
            config.CreateMap<Data.Entities.DrivingSchool, DrivingSchool>();
            config.CreateMap<DrivingSchool, Data.Entities.DrivingSchool>();

        }
    }
}
