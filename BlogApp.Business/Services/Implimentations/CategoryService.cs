using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implimentations
{
    public class CategoryService : ICategoryservice
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo,  IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<ICollection<CategoryListItemDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return _mapper.Map<ICollection<CategoryListItemDto>>(categories);
           
        }

        public async Task<CategoryDetailDto> GetByIdAsync(int id)
        {
            await CheckEntity(id);
            return _mapper.Map<CategoryDetailDto>(await _repo.FindById(id));

        }

        public async Task<bool> CreateAsync(CategoryCreateDto categoryDto)
        {
            if (categoryDto == null) throw new CategoryNullException();
            Category category = new Category()
            {
                Name = categoryDto.Name,
                LogoUrl = "asasasa",
                IsDeleted = false,
            };
            await _repo.CreateAsync(category);
            int result =await _repo.SavaChangesAsync();
            if(result>0) { return true; }
            return false;
        }



        public async Task<bool> CheckEntity(int id)
        {
            if (id <= 0) throw new NegativeIdException();
            if (!await _repo.IExisted(id)) throw new CategoryNotFoundException();
            return true;
        }


        public async Task<bool> Update(CategoryUpdateDto categoryDto)
        {
            await CheckEntity(categoryDto.Id);
            Category category=await _repo.FindById(categoryDto.Id);
            _mapper.Map(categoryDto, category);
            var result=await _repo.SavaChangesAsync();
            if(result>0) { return true; };
            return false;
        }


        public async Task Delete(int id)
        {
            await CheckEntity(id);
            await _repo.Remove(id);
            await _repo.SavaChangesAsync();
        }
    }
}
