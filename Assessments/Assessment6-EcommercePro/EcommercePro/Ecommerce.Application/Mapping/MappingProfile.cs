using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;

namespace Ecommerce.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>();

            CreateMap<Product, ProductRequestDTO>().ReverseMap();
            CreateMap<Product, ProductResponseDTO>();

            CreateMap<OrderItem, OrderItemRequestDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemResponseDTO>();

            CreateMap<Order, OrderRequestDTO>().ReverseMap();
            CreateMap<Order, OrderResponseDTO>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
