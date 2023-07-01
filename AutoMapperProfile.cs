using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpn.Dtos.Character;

namespace dotnet_rpn
{
    public class AutoMapperFrofile: Profile
    {
        public AutoMapperFrofile()
        {
            CreateMap<Character, GetCharaterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharaterDto, Character>();
        }
    }
}