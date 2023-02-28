using API.Data.DTO;
using API.Data.Models;
using AutoMapper;

namespace API.Data.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Person, PersonDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<OrderDTO, OrderDTO>().ReverseMap();
    }
}