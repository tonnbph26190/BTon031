using API.Extensions;
using API.ViewModel.CustomViewModel;
using API.ViewModel.ViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.ViewModel.PowerViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private IAllRepositories<Power> _PowerRepository;
        public PowerController(IAllRepositories<Power> repo)
        {
            _PowerRepository = repo;
        }
        [HttpGet]
        [Route("get-all-power")]
        public async Task<IActionResult> GetAll(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _PowerRepository.GetAllAsync();

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
        [Route("get-power-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _PowerRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Power Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-power")]
        public async Task<IActionResult> Create(CreatePowerViewModel create)
        {
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var id = "Pw" + Helper.GenerateRandomString(5);
            Power ExistObj = new Power();
            do
            {
                id = "Pw" + Helper.GenerateRandomString(5);
                ExistObj = await _PowerRepository.GetByIdAsync(id);
            } while (ExistObj != null);
            Power NewObj = new Power()
            {
                ID = id,
                Name = create.Name,
                Value = create.Value,
                Quatity= create.Quatity,
                COGS= create.COGS,
                Price= create.Price,
                Status = 1
            };
            try
            {
                var result = await _PowerRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update-power/id")]
        public async Task<IActionResult> Update(string id, UpdatePowerViewModel update)
        {
            var result = await _PowerRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Power do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = update.Name;
                result.Status = update.Status;
                result.Value = update.Value;
                result.COGS=update.COGS; 
                result.Price = update.Price; 
                result.Quatity=update.Quatity;
                try
                {
                    await _PowerRepository.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-power/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _PowerRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Power do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _PowerRepository.UpdateOneAsync(result);
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
