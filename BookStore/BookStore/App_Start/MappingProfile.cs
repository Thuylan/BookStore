using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookStore.Dtos;
using BookStore.Models;

namespace BookStore.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<BookDto, Book>();
        }
        
    }
}