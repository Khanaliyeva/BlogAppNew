using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryservice _service;

        public CategoryController(ICategoryservice service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GelAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);

        }



        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto categoryDto)
        {
            bool result = await _service.CreateAsync(categoryDto);
            if (result) { return StatusCode(StatusCodes.Status200OK); }
            return StatusCode(StatusCodes.Status409Conflict);
        }



        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateDto categoryDto)
        {

            try
            {
                if (await _service.Update(categoryDto)) return StatusCode(StatusCodes.Status200OK);
                return BadRequest();
            }
            catch (NegativeIdException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (CategoryNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
             catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
