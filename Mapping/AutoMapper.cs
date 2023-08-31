using AutoMapper;
using praticeAPI.Models.Domain;
using praticeAPI.Models.DTO;

namespace praticeAPI.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap();
            CreateMap<Difficulty,DifficutlyDTO>().ReverseMap();

            CreateMap<AddRegionPost,Region>().ReverseMap();
            CreateMap<AddWalkPost,Walk>().ReverseMap();

            CreateMap<UpdateRegionPost, Region>().ReverseMap();
            CreateMap<UpdateWalkPost, Walk>().ReverseMap();




        }
    }
}
