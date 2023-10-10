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
        private IAllRepositories<Main> _MainRepository;
        public MainController(IAllRepositories<Main> repo)
        {
            _MainRepository = repo;
        }
        [HttpGet]
        [Route("get-all-main")]
        public async Task<IActionResult> GetAllMain(int page=1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _MainRepository.GetAllAsync();

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
        [Route("get-main-by-id/{id}")]
        public async Task<IActionResult> GetMainById(string id)
        {
            var result = await _MainRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Main Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-main")]
        public async Task<IActionResult> CreateMain([FromForm] CreateMain create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }
            var data = await _MainRepository.GetAllAsync();
            var id = "M" + Helper.GenerateRandomString(5);
            do
            {
                id = "M" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            Main NewObj = new Main()
            {
                ID = id,
                Name = create.Name,
                Parameter = create.Parameter,
                Status = 1,
                Type= create.Type,
            };
            if (NewObj.Type==2)
            {
                NewObj.Price = create.Price;
                NewObj.COGS = create.COGS;
                NewObj.Quatity=create.Quatity;
            }
            try
            {
                var result = await _MainRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("udate-main/id")]
        public async Task<IActionResult> UpdateMain(string id, [FromForm] UpdateMain update)
        {
            var result = await _MainRepository.GetByIdAsync(id);
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
                result.Name = update.Name;
                result.Status = update.Status;
                result.Parameter = update.Parameter;
                result.Type=update.Type;
                if (update.Type==2)
                {
                    result.Price = update.Price;
                    result.COGS = update.COGS;
                    result.Quatity = update.Quatity;    
                }
                try
                {
                    await _MainRepository.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-main/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _MainRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Main Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _MainRepository.UpdateOneAsync(result);
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
