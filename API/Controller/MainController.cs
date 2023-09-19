using API.Extensions;
using API.ViewModel.BatteryViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.ViewModel.MainViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IAllRepositories<Main> _repo;
        public MainController(IAllRepositories<Main> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All-Main")]
        public async Task<IActionResult> GetAllMain(int? page, int? Size)
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
        [Route("GetMainById/{id}")]
        public async Task<IActionResult> GetMainById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Main Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create_Main")]
        public async Task<IActionResult> CreateMain([FromForm] CreateMain ccv)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }
            var data = await _repo.GetAllAsync();
            var id = "M" + Helper.GenerateRandomString(5);
            do
            {
                id = "M" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Main cv = new Main()
            {
                ID = id,
                Name = ccv.Name,
                Parameter = ccv.Parameter,
                Status = 1
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
        [Route("Update_Main/id")]
        public async Task<IActionResult> UpdateMain(string id, [FromForm] UpdateMain ucv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Main do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = ucv.Name;
                result.Status = ucv.Status;
                result.Parameter = ucv.Parameter;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpGet]
        [Route("Delete_Main/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Battery do not Exist");
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
