﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;
using When2Watch.DAL.Database.Entities;

namespace When2Watch.BLL.Mappers
{
    public class FriendMappingProfile : Profile
    {
        public FriendMappingProfile()
        {
            CreateMap<FriendEntity, FriendDTO>();
            CreateMap<FriendDTO, FriendEntity>();
        }
    }
}
