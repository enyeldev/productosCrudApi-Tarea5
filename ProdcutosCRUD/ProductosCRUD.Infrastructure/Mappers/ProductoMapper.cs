using AutoMapper;
using ProdcutosCRUD.Domain.Entities;
using ProductoCRUD.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosCRUD.Infrastructure.Mappers
{
    public class ProductoMapper : Profile
    {

        public ProductoMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
