using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ReBuyDtos;
using ReBuyModels;

namespace ReBuyApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<UsersModel, UserDto>();
            CreateMap<ProductModel, ProductLikesDto>();

        }
    }
}
