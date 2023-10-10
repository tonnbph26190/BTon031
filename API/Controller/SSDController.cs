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
    public class SSDController : ControllerBase
    {
        private IAllRepositories<SSD> _repo;
        public SSDController(IAllRepositories<SSD> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("get-all-ssd")]
        public async Task<IActionResult> GetAllSSD(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _repo.GetAllAsync();

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
        [Route("get-ssd-by-id/{id}")]
        public async Task<IActionResult> GetSSDById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Ram Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-ssd")]
        public async Task<IActionResult> CreateSSD([FromForm] CreateRam create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }

            var data = await _repo.GetAllAsync();
            var id = "S" + Helper.GenerateRandomString(5);
            bool isIdUnique = data.Any(c => c.ID == id);

            while (isIdUnique)
            {
                id = "S" + Helper.GenerateRandomString(5);
                isIdUnique = data.Any(c => c.ID == id);
            }
            var NewObj = new SSD()
            {
                ID = id,
                Name = create.Name,
                Parameter = create.Parameter,
                Status = 1,
                Type = create.Type,
            };
            if (create.Type == 2)
            {
                NewObj.Price = create.Price;
                NewObj.COGS = create.COGS;
                NewObj.Quatity = create.Quatity;
            }

            try
            {
                var result = await _repo.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }
        }
        [HttpPut]
        [Route("update-ssd/id")]
        public async Task<IActionResult> UpdateSSD(string id, [FromForm] UpdateRam Update)
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

                result.Name = Update.Name;
                result.Status = Update.Status;
                result.Parameter = Update.Parameter;
                result.Type = Update.Type;
                if (Update.Type == 2)
                {
                    result.COGS = Update.COGS;
                    result.Quatity = Update.Quatity;
                    result.Price = Update.Price;
                }
                try
                {
                    await _repo.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-ssd/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "SSD do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _repo.UpdateOneAsync(result);
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
