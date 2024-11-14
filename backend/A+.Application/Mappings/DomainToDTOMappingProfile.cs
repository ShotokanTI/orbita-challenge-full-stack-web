using Application.DTos;
using AutoMapper;
using Desafio_A__Educacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
                CreateMap<Student,StudentDTO>().ReverseMap();
        }
    }
}
