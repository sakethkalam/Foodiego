using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Foodiego.DTO;
using Foodiego.Models;

namespace Foodiego.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDto>();
        }
    }
}