using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.DTOs;
using AspNetSandbox.Models;
using AutoMapper;

namespace AspNetSandbox.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<Book, ReadBookDto>();
            CreateMap<Book, ReadAllBooksDto>();
        }
    }
}
