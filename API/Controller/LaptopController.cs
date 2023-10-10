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
        private IAllRepositories<Laptop> _LaptopRepository;

        private IAllRepositories<Category> _CategoryRepository;
        private IAllRepositories<Producer> _ProducerRepository;
        public LaptopController(IAllRepositories<Laptop> repo, IAllRepositories<Category> repoCat, IAllRepositories<Producer> repoPro)
        {
            _LaptopRepository = repo;
            _CategoryRepository = repoCat;
            _ProducerRepository = repoPro;
        }
        [HttpGet]
        [Route("get-all-lapTop")]
        public async Task<IActionResult> GetAllLaptop(int page=1, int Size=10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _LaptopRepository.GetAllAsync();

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
        [Route("get-laptop-by-id/{id}")]
        public async Task<IActionResult> GetLaptopById(string id)
        {
            var result = await _LaptopRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Laptop Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create_laptop")]
        public async Task<IActionResult> CreateBattery([FromForm] CreateLaptop Create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var data = await _LaptopRepository.GetAllAsync();
            var id = "Lt" + Helper.GenerateRandomString(5);
            do
            {
                id = "Lt" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Laptop NewObj = new Laptop()
            {
                ID = id,
                Name = Create.Name,
                IdCat = Create.IdCat,
                IdProducer = Create.IdProducer,
                Status = 1
            };
            try
            {
                var result = await _LaptopRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update_laptop/id")]
        public async Task<IActionResult> UpdateBattery(string id, [FromForm] UpdateLaptop ucv)
        {
            var result = await _LaptopRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Laptop do not Exist");
            }
            var Category = _CategoryRepository.GetByIdAsync(ucv.IdCat);
            var Producer = _ProducerRepository.GetByIdAsync(ucv.IdProducer);          
            if (!ModelState.IsValid)
            {
               return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            else
            {
                if (Producer.Status == 0 || Category.Status == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = ucv.Name;
                result.Status = ucv.Status;
                result.IdProducer = ucv.IdProducer;
                result.IdCat = ucv.IdCat;
                try
                {
                    await _LaptopRepository.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }
            }
        }
        [HttpDelete]
        [Route("delete_laptop/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _LaptopRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Laptop do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _LaptopRepository.UpdateOneAsync(result);
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
