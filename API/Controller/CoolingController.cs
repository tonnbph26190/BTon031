using API.Extensions;
using API.ViewModel.CustomViewModel;
using API.ViewModel.ViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.ViewModel.CoolingViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoolingController : ControllerBase
    {
        private IAllRepositories<Cooling> _CoolingRepository;
        public CoolingController(IAllRepositories<Cooling> repo)
        {
            _CoolingRepository = repo;
        }
        [HttpGet]
        [Route("get-all-cooling")]
        public async Task<IActionResult> GetAll(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _CoolingRepository.GetAllAsync();

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
        [Route("get-cooling-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _CoolingRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return BadRequest("Cooling Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-cooling")]
        public async Task<IActionResult> Create(CreateCoolingViewModel CreateModel)
        {
            if (!ModelState.IsValid)
            {
               return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var id = "Col" + Helper.GenerateRandomString(5);
            Cooling ex = new Cooling();
            do
            {
                id = "Col" + Helper.GenerateRandomString(5);
                ex = await _CoolingRepository.GetByIdAsync(id);
            } while (ex != null);
            Cooling NewObj = new Cooling()
            {
                ID = id,
                Name = CreateModel.Name,
                Value = CreateModel.Value,
                Price= CreateModel.Price,
                COGS=CreateModel.COGS,
                Quatity=CreateModel.Quatity,
                Status = 1
            };
            try
            {
                var result = await _CoolingRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update-cooling/id")]
        public async Task<IActionResult> Update(string id, UpdateCoolingViewModel UpdateModel)
        {
            var result = await _CoolingRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Cooling do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = UpdateModel.Name;
                result.Status = UpdateModel.Status;
                result.Value = UpdateModel.Value    ;
                result.COGS=UpdateModel.COGS;
                result.Quatity=UpdateModel.Quatity;
                result.Price= UpdateModel.Price;
                try
                {
                    await _CoolingRepository.UpdateOneAsync(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-cooling/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _CoolingRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Cooling do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _CoolingRepository.UpdateOneAsync(result);
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
