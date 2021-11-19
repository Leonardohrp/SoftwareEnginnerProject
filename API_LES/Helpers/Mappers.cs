using API_LES.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LES.Helpers
{
    public class MappersProfile : Profile
    {
        public void MappingProfile()
        {
            CreateMap<Models.User.User, UserDto>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName)
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName)
                ).ForMember(
                    dest => dest.email,
                    opt => opt.MapFrom(src => src.email)
                ).ForMember(
                    dest => dest.login,
                    opt => opt.MapFrom(src => $"{src.FirstName}_{src.LastName}")
                );

            CreateMap<UserDto, Models.User.User>();
        }

        //Mapper Professor
        //CreateMap<Professor, ProfessorDto>()
        //        .ForMember(
        //            dest => dest.Nome,
        //            opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
        //        );

        //    CreateMap<ProfessorDto, Professor>();


    }
}
