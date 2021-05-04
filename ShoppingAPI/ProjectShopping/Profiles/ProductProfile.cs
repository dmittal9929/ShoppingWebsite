using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductsDTO>();
            CreateMap<Models.ProductCreatingDTO, Entities.Product>();
            CreateMap<Models.TagProductionDTO, Entities.Tags>();
            CreateMap<Models.StockProductionDTO, Entities.Stock>();
            CreateMap<Models.UserCreationDTO, Entities.User>();
            CreateMap<Models.OrderCreationDTO, Entities.Order>();
            CreateMap<Models.CartCreationDTO, Entities.Cart>();
            CreateMap<Entities.Order, Models.OrderReturnDTO>();
            CreateMap<Entities.Cart, Models.CartCreationDTO>();
            CreateMap<Models.ProductUpdateDTO, Entities.Product>();
            CreateMap<Entities.Stock, Models.StockProductionDTO>();
        }
        
    }
}
