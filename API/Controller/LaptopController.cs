using API.Extensions;
using API.ViewModel.BatteryViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.ViewModel.LaptopViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private IAllRepositories<Laptop> _repo;
        private IAllRepositories<Category> _repoCat;
        private IAllRepositories<Producer> _repoPro;
        public LaptopController(IAllRepositories<Laptop> repo, IAllRepositories<Category> repoCat, IAllRepositories<Producer> repoPro)
        {
            _repo = repo;
            _repoCat = repoCat;
            _repoPro = repoPro;
        }
        [HttpGet]
        [Route("Get-All-LapTop")]
        public async Task<IActionResult> GetAllLaptop(int? page, int? Size)
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
        [Route("GetLaptopById/{id}")]
        public async Task<IActionResult> GetLaptopById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Laptop Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create_Laptop")]
        public async Task<IActionResult> CreateBattery([FromForm] CreateLaptop ccv)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var data = await _repo.GetAllAsync();
            var id = "Lt" + Helper.GenerateRandomString(5);
            do
            {
                id = "Lt" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Laptop cv = new Laptop()
            {
                ID = id,
                Name = ccv.Name,
                IdCat = ccv.IdCat,
                IdProducer = ccv.IdProducer,
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
        [Route("Update_Laptop/id")]
        public async Task<IActionResult> UpdateBattery(string id, [FromForm] UpdateLaptop ucv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Laptop do not Exist");
            }
            var Cat = _repoCat.GetByIdAsync(ucv.IdCat);
            var Pro = _repoPro.GetByIdAsync(ucv.IdProducer);          
            if (!ModelState.IsValid)
            {
               return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            else
            {
                if (Pro.Status == 0 || Cat.Status == 0)
                {
                   return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = ucv.Name;
                result.Status = ucv.Status;
                result.IdProducer = ucv.IdProducer;
                result.Status = ucv.Status;
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
        [Route("Delete_Laptop/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "lap do not Exist");
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
