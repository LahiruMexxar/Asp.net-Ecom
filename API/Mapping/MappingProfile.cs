using AutoMapper;
using DAL.DTO.CartItem;
using DAL.DTO.OrderBrief;
using DAL.DTO.OrderDetail;
using DAL.DTO.Product;
using DAL.Models;

namespace PayrollSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>().ReverseMap();
            CreateMap<OrderBrief, OrderBriefDTO>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails))
                .ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
