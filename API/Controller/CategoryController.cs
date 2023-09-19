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
        private IAllRepositories<Category> _repo;
        public CategoryController(IAllRepositories<Category> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All-Category")]
        public async Task<IActionResult> GetAllCategory(int? page, int? Size)
        {
            var pageNumber = page ?? 1; // Trang hiện tại (mặc định là 1)
            var pageSize = Size ?? 10; // Số mục trên mỗi trang

            var results = await _repo.GetAllAsync();
            if (results == null) return Ok("Data not available");

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
        [Route("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Category Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create_Category")]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategory ccv)
        {
            var data = await _repo.GetAllAsync();
            var id = "CT" + Helper.GenerateRandomString(5);
            do
            {
                id = "CT" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Category cv = new Category()
            {
                ID = id,
                Status=1,
                Name= ccv.Name,
            };
            try
            {
                var result = await _repo.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPost]
        [Route("Update_Category/id")]
        public async Task<IActionResult> UpdateCategory(string id, [FromForm] UpdateCategoryViewModel ucv)
        {
            var result = await _repo.GetByIdAsync(id);
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
                result.Name = ucv.Name;
                result.Status = ucv.Status;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update không thành công");
                }


            }

        }
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            else
            {
                try
                {
                    await _repo.DeleteOneAsyn(result);
                    return Ok("Delete Successfully");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Delete Fail");
                }


            }
        }   
    }
}

