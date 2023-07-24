using Application.DTOs.Product;
using Application.Features.Products.Commands.CreateProduct;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile() 
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
