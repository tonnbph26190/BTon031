using API.Extensions;
using API.ViewModel.CategoryViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.ViewModel.BatteryViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryController : ControllerBase
    {
        private IAllRepositories<Battery> _BatteryRepository;
        public BatteryController(IAllRepositories<Battery> repo)
        {
            _BatteryRepository = repo;
        }
        [HttpGet]
        [Route("get-all-battery")]
        public async Task<IActionResult> GetAllBattery(int? page, int? Size)
        {
            var pageNumber = page ?? 1; // Trang hiện tại (mặc định là 1)
            var pageSize = Size ?? 10; // Số mục trên mỗi trang

            var results = await _BatteryRepository.GetAllAsync();

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
        [Route("get-batterybyid/{id}")]
        public async Task<IActionResult> GetBatteryById(string id)
        {
            var result = await _BatteryRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Battery Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-battery")]
        public async Task<IActionResult> CreateBattery([FromForm] CreateBattery createModel)
        {
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var data = await _BatteryRepository.GetAllAsync();
            var id = "B" + Helper.GenerateRandomString(5);
            do
            {
                id = "B" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Battery cv = new Battery()
            {
                ID = id,
                Name= createModel.Name,
                Parameter=createModel.Parameter,
                Status=1              
            };
            try
            {
                var result = await _BatteryRepository.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPost]
        [Route("update-battery/id")]
        public async Task<IActionResult> UpdateBattery(string id, [FromForm] UpdateBattery updateModel)
        {
            var result = await _BatteryRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Battery do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = updateModel.Name;
                result.Status = updateModel.Status;
                result.Parameter=updateModel.Parameter;
                try
                {
                    await _BatteryRepository.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-battery/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _BatteryRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Battery do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _BatteryRepository.UpdateOneAsyn(result);
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
