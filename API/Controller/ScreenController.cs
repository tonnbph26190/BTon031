using API.Extensions;
using API.ViewModel.RamViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.ViewModel.Screen;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        private IAllRepositories<Screen> _repo;
        public ScreenController(IAllRepositories<Screen> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("get-all-screen")]
        public async Task<IActionResult> GetAllScreen(int page=1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _repo.GetAllAsync();

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
        [Route("get-screen-by-id/{id}")]
        public async Task<IActionResult> GetScreenById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Screen Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-screen")]
        public async Task<IActionResult> CreateScreen([FromForm] CreatScreen create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }
            var data = await _repo.GetAllAsync();
            var id = "Sc" + Helper.GenerateRandomString(5);
            do
            {
                id = "Sc" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Screen NewObj = new Screen()
            {
                ID = id,
                Name = create.Name,
                Size=create.Size,
                Rate= create.Rate,
                Status = 1
            };
            try
            {
                var result = await _repo.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update-screen/id")]
        public async Task<IActionResult> Update(string id, [FromForm] UpdateScreen update)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Screen do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = update.Name;
                result.Status = update.Status;
                result.Rate= update.Rate;
                result.Size= update.Size;
                try
                {
                    await _repo.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-screen/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Screen do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _repo.UpdateOneAsync(result);
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
