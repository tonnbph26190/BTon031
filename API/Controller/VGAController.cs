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
    public class VGAController : ControllerBase
    {
        private IAllRepositories<VGA> _repo;
        public VGAController(IAllRepositories<VGA> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("get-all-vga")]
        public async Task<IActionResult> GetAllVGA(int page=1, int Size = 10)
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
        [Route("get-vga-by-id/{id}")]
        public async Task<IActionResult> GetVGAById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Ram Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-vga")]
        public async Task<IActionResult> CreateVGA([FromForm] CreateRam create)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Create Fail");
            }
            var data = await _repo.GetAllAsync();
            var id = "VG" + Helper.GenerateRandomString(5);
            do
            {
                id = "VG" + Helper.GenerateRandomString(5);
            } while (data.Any(c => c.ID == id));
            VGA NewObj = new VGA()
            {
                ID = id,
                Name = create.Name,
                Parameter = create.Parameter,
                Status = 1,
                Type= create.Type,
                
            };
            if (create.Type==2)
            {
                NewObj.COGS = create.COGS;
                NewObj.Price= create.Price;
                NewObj.Quatity= create.Quatity;
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
        [Route("update_vga/id")]
        public async Task<IActionResult> UpdateRam(string id, [FromForm] UpdateRam update)
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

                result.Name = update.Name;
                result.Status = update.Status;
                result.Parameter = update.Parameter;
                result.Type = update.Type;

                if (update.Type == 2)
                {
                    result.COGS = update.COGS;
                    result.Price = update.Price;
                    result.Quatity = update.Quatity;
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
        [Route("delete_vga/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "VGA do not Exist");
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
