using BlogApp.Business.DTOs.Category;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryservice
    {
        Task<ICollection<CategoryListItemDto>> GetAllAsync();
        Task<CategoryDetailDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CategoryCreateDto categoryDto);
        Task<bool> Update(CategoryUpdateDto categoryDto);
        Task Delete(int id);
    }
}
