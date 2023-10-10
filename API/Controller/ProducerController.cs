using API.Extensions;
using API.ViewModel.CategoryViewModel;
using API.ViewModel.ProducerViewModel;
using Data.IRepositories;
using DATA.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private IAllRepositories<Producer> _ProducerRepository;
        public ProducerController(IAllRepositories<Producer> repo)
        {
            _ProducerRepository = repo;
        }
        [HttpGet]
        [Route("get-all-producer")]
        public async Task<IActionResult> GetAllProducer(int page=1, int Size= 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _ProducerRepository.GetAllAsync();

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
        [Route("get-producer-by-id/{id}")]
        public async Task<IActionResult> GetProducerById(string id)
        {
            var result = await _ProducerRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Producer Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-producer")]
        public async Task<IActionResult> CreateProducer([FromForm] CreateProducer create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }
            var data = await _ProducerRepository.GetAllAsync();
            var id = "P" + Helper.GenerateRandomString(5);
            do
            {
                id = "P" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Producer NewObj = new Producer()
            {
                ID = id,
                Status = 1,
                Name= create.Name,
            };
            try
            {
                var result = await _ProducerRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }
        }
        [HttpPut]
        [Route("update-producer/id")]
        public async Task<IActionResult> UpdateProducer(string id, [FromForm] UpdateCategoryViewModel Update)
        {
            var result = await _ProducerRepository.GetByIdAsync(id);
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
                result.Name = Update.Name;
                result.Status = Update.Status;
                try
                {
                    await _ProducerRepository.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update không thành công");
                }
            }

        }
        [HttpDelete]
        [Route("delete-producer/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _ProducerRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Producer do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _ProducerRepository.UpdateOneAsync(result);
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
