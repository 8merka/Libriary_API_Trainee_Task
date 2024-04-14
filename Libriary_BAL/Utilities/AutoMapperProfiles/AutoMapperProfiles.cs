using AutoMapper;
using Libriary_BAL.DTOs;
using Libriary_DAL.Entities.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Utilities.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Author, AuthorToUpdateDTO>().ReverseMap();
            CreateMap<Book, BookDTO>()
               .ForMember(dest => dest.AuthorDTO, opt => opt.MapFrom(src => src.Author))
               .ForMember(dest => dest.GenreDTO, opt => opt.MapFrom(src => src.Genre))
               .ReverseMap();
            CreateMap<Book, BookToCreateDTO>().ReverseMap();
            CreateMap<Book, BookToUpdateDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Genre, GenreToUpdateDTO>().ReverseMap();
            CreateMap<Issue, IssueDTO>()
                .ForMember(dest => dest.bookDTO, opt => opt.MapFrom(src => src.Book))
                .ForPath(dest => dest.bookDTO.AuthorDTO, opt => opt.MapFrom(src => src.Book.Author))
                .ForPath(dest => dest.bookDTO.GenreDTO, opt => opt.MapFrom(src => src.Book.Genre))
                .ReverseMap();
            CreateMap<Issue, IssueToCreateDTO>().ReverseMap();
            CreateMap<Issue, IssueToUpdateDTO>().ReverseMap();
            CreateMap<RegisterDTO, User>().ReverseMap();
        }
    }
}
