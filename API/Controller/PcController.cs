using API.Extensions;
using API.ViewModel.LaptopViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcController : ControllerBase
    {
        private IAllRepositories<PC> _PcRepository;

        private IAllRepositories<Category> _CategoryRepository;
        private IAllRepositories<Producer> _ProducerRepository;
        public PcController(IAllRepositories<PC> repo, IAllRepositories<Category> repoCat, IAllRepositories<Producer> repoPro)
        {
            _PcRepository = repo;
            _CategoryRepository = repoCat;
           _ProducerRepository = repoPro;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll(int page=1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _PcRepository.GetAllAsync();

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
        [Route("get-pc-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _PcRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Laptop Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create_pc")]
        public async Task<IActionResult> Create([FromForm] CreateLaptop CreateModel)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var data = await _PcRepository.GetAllAsync();
            var id = "Pc" + Helper.GenerateRandomString(5);
            do
            {
                id = "Pc" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            PC cv = new PC()
            {
                ID = id,
                Name = CreateModel.Name,
                CatId = CreateModel.IdCat,
                ProducerId = CreateModel.IdProducer,
                Status = 1,
            };
            try
            {
                var result = await _PcRepository.AddOneAsync(cv);
                return Ok(cv);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update_pc/id")]
        public async Task<IActionResult> Update(string id, UpdateLaptop UpdateModel)
        {
            var result = await _PcRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Laptop do not Exist");
            }
            var Cat = _CategoryRepository.GetByIdAsync(UpdateModel.IdCat);
            var Pro = _ProducerRepository.GetByIdAsync(UpdateModel.IdProducer);
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
                result.Name = UpdateModel.Name;
                result.Status = UpdateModel.Status;
                result.ProducerId = UpdateModel.IdProducer;
                result.CatId = UpdateModel.IdCat;
                try
                {
                    await _PcRepository.UpdateOneAsync(result);
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
            var result = await _PcRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Laptop do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _PcRepository.UpdateOneAsync(result);
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
