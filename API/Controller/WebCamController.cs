using API.Extensions;
using API.ViewModel.RamViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebCamController : ControllerBase
    {
        private IAllRepositories<Webcam> _repo;
        public WebCamController(IAllRepositories<Webcam> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All-WebCam")]
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
        [Route("GetCamById/{id}")]
        public async Task<IActionResult> GetRamById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Ram Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create_Cam")]
        public async Task<IActionResult> CreateCam([FromForm] CreateRam ccv)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }
            var data = await _repo.GetAllAsync();
            var id = "CA" + Helper.GenerateRandomString(5);
            do
            {
                id = "CA" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Webcam cv = new Webcam()
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
        [Route("Update_Cam/id")]
        public async Task<IActionResult> UpdateCam(string id, [FromForm] UpdateRam ucv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ram do not Exist");
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
        [Route("Delete_Cam/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ram do not Exist");
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
