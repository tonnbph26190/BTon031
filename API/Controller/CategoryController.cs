using API.Extensions;
using API.ViewModel.CategoryViewModel;
using Data.IRepositories;
using DATA.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IAllRepositories<Category> _CategoryRepository;
        public CategoryController(IAllRepositories<Category> repo)
        {
            _CategoryRepository = repo;
        }
        [HttpGet]
        [Route("get-all-category")]
        public async Task<IActionResult> GetAllCategory(int page=1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _CategoryRepository.GetAllAsync();

            var filteredResults = results.Where(result => result.Status == 1);

            var totalCount = filteredResults.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var pagedResults = filteredResults.ToPagedList(pageNumber, pageSize);

            var response = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Results = pagedResults
            };

            return Ok(response);
        }
        [HttpGet]
        [Route("get-category-by-id/{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var result = await _CategoryRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return BadRequest("Category Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-category")]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategory CreateModel)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error repuest");
            }
            var data = await _CategoryRepository.GetAllAsync();
            var id = "CT" + Helper.GenerateRandomString(5);
            do
            {
                id = "CT" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Category cv = new Category()
            {
                ID = id,
                Status=1,
                Name= CreateModel.Name,
            };
            try
            {
                var result = await _CategoryRepository.AddOneAsync(cv);
                return Ok(cv);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update-category/id")]
        public async Task<IActionResult> UpdateCategory(string id, [FromForm] UpdateCategoryViewModel UpdateModel)
        {
            var result = await _CategoryRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = UpdateModel.Name;
                result.Status = UpdateModel.Status;
                try
                {
                    await _CategoryRepository.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update không thành công");
                }


            }

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _CategoryRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _CategoryRepository.UpdateOneAsync(result);
                    return Ok("Delete Successfully");
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Delete Fail");
                }
            }
        }
    }
}

