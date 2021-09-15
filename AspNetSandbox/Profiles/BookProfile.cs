using AspNetSandbox.DTOs;
using AspNetSandbox.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
        }
    }
}
