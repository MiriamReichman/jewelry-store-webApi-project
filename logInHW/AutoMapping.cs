using AutoMapper;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOEntity;
using DL;

namespace logInHW
{
    class AutoMapping: Profile
    {
        public AutoMapping()
        { 
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
          
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
       
            //CreateMap<GameCategorie, ProductCategorieDTO > ().ReverseMap();
            //CreateMap<Game, ProductDTO>().ReverseMap();


            CreateMap<ProductCategorie, ProductCategorieDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();


        }
    }
}
