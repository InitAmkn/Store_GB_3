using AutoMapper;
using Store_GB_3.Models;
using Store_GB_3.Models.Dto;

namespace Store_GB_3.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryDto>(MemberList.Destination).ReverseMap();
            CreateMap<Storage, StorageDto>(MemberList.Destination).ReverseMap();
        }
    }
}
