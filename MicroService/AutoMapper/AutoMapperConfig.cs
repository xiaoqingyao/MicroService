using AutoMapper;
using MicroService.Models.Db;
using MicroService.Models.DTO;
using MicroService.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserEntity, UserViewModel>();
            CreateMap<UserDTO, UserEntity>();
        }
    }
}
