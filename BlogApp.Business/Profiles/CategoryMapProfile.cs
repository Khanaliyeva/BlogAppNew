using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
    public class CategoryMapProfile:Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryDetailDto, Category>();
            CreateMap<CategoryDetailDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<CategoryListItemDto, Category>();
            CreateMap<CategoryListItemDto, Category>().ReverseMap();

        }
    }
}
