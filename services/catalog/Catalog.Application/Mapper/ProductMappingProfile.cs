using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductBrand,BrandResponseDto>().ReverseMap();
            CreateMap<Product,ProductResponseDto>().ReverseMap();
        }
    }
}
