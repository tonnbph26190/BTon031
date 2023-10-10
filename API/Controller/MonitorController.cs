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
    public class MonitorController : ControllerBase
    {
        private IAllRepositories<DATA.Entity.Monitor> _MonitorRepository;

        private IAllRepositories<Category> _CategoryRepository;
        private IAllRepositories<Producer> _ProducerRepository;
        public MonitorController(IAllRepositories<DATA.Entity.Monitor> repo, IAllRepositories<Category> repoCat, IAllRepositories<Producer> repoPro)
        {
            _MonitorRepository = repo;
            _CategoryRepository = repoCat;
            _ProducerRepository = repoPro;
        }
        [HttpGet]
        [Route("get-all-monitor")]
        public async Task<IActionResult> GetAll(int page=1, int Size=10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _MonitorRepository.GetAllAsync();

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
        [Route("get-monitor-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _MonitorRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Monitor Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create_pc")]
        public async Task<IActionResult> Create([FromForm] CreateLaptop create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var data = await _MonitorRepository.GetAllAsync();
            var id = "MR" + Helper.GenerateRandomString(5);
            do
            {
                id = "MR" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            DATA.Entity.Monitor NewObj = new DATA.Entity.Monitor()
            {
                ID = id,
                Name = create.Name,
                CatId = create.IdCat,
                ProducerId = create.IdProducer,
                Status = 1
            };
            try
            {
                var result = await _MonitorRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update_pc/id")]
        public async Task<IActionResult> Update(string id, UpdateLaptop Update)
        {
            var result = await _MonitorRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Monitor do not Exist");
            }
            var Cat = _CategoryRepository.GetByIdAsync(Update.IdCat);
            var Pro = _CategoryRepository.GetByIdAsync(Update.IdProducer);
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
                result.Name = Update.Name;
                result.Status = Update.Status;
                result.ProducerId = Update.IdProducer;
                result.CatId = Update.IdCat;
                try
                {
                    await _MonitorRepository.UpdateOneAsync(result);
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
            var result = await _MonitorRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Monitor do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _MonitorRepository.UpdateOneAsync(result);
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
