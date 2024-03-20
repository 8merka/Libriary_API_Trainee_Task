using AutoMapper;
using Libriary_BAL.DTOs;
using Libriary_DAL.Entities.Models;
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
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookToUpdateDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Genre, GenreToUpdateDTO>().ReverseMap();
            CreateMap<Issue, IssueDTO>().ReverseMap();
            CreateMap<Issue, IssueToUpdateDTO>().ReverseMap();
        }
    }
}
