using API.Extensions;
using API.ViewModel.MainViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.ViewModel.RamViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private IAllRepositories<Ram> _RamRepository;
        public RamController(IAllRepositories<Ram> repo)
        {
            _RamRepository = repo;
        }
        [HttpGet]
        [Route("get-all-ram")]
        public async Task<IActionResult> GetAllRam(int page=1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _RamRepository.GetAllAsync();

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
        [Route("get-ram-by-id/{id}")]
        public async Task<IActionResult> GetRamById(string id)
        {
            var result = await _RamRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Ram Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-ram")]
        public async Task<IActionResult> CreateRam([FromForm] CreateRam Create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }
            var data = await _RamRepository.GetAllAsync();
            var id = "R" + Helper.GenerateRandomString(5);
            do
            {
                id = "R" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Ram NewObj = new Ram()
            {
                ID = id,
                Name = Create.Name,
                Parameter = Create.Parameter,
                Status = 1,
                Type= Create.Type,
            };
            if (Create.Type==2)
            {
                NewObj.Quatity = Create.Quatity;
                NewObj.Price= Create.Price;
                NewObj.COGS = Create.COGS;
            }
            try
            {
                var result = await _RamRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update-ram/id")]
        public async Task<IActionResult> UpdateRam(string id, [FromForm] UpdateRam UpdateObj)
        {
            var result = await _RamRepository.GetByIdAsync(id);
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
                result.Name = UpdateObj.Name;
                result.Status = UpdateObj.Status;
                result.Parameter = UpdateObj.Parameter;
                result.Type= UpdateObj.Type;
                if (UpdateObj.Type==2)
                {
                    result.COGS = UpdateObj.COGS;
                    result.Price = UpdateObj.Price;
                    result.Quatity = UpdateObj.Quatity;
                }
                try
                {
                    await _RamRepository.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-ram/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _RamRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ram do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _RamRepository.UpdateOneAsync(result);
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
