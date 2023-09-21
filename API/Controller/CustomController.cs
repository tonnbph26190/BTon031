using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using API.ViewModel.BatteryViewModel;
using PagedList;
using API.ViewModel.CustomViewModel;
using API.ViewModel.ViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private IAllRepositories<Custom> _CustomRepository;
        public CustomController(IAllRepositories<Custom> repo)
        {
            _CustomRepository = repo;
        }
        [HttpGet]
        [Route("get-all-custom")]
        public async Task<IActionResult> GetAll(int page=1, int Size=10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _CustomRepository.GetAllAsync();

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
        [Route("get-custom-byid/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _CustomRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Custom Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-custom")]
        public async Task<IActionResult> Create(CreateViewModel CreateModel)
        {
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var id = "Cus" + Helper.GenerateRandomString(5);
            Custom ex= new Custom();
            do
            {
                id = "Cus" + Helper.GenerateRandomString(5);
                ex= await _CustomRepository.GetByIdAsync(id);
            } while (ex!=null);
            Custom cv = new Custom()
            {
                ID = id,
                Name = CreateModel.Name,
                Value = CreateModel.Values,
                Status = 1
            };
            try
            {
                var result = await _CustomRepository.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPost]
        [Route("update-custom/id")]
        public async Task<IActionResult> Update(string id, UpdateViewModel UpdateModel)
        {
            var result = await _CustomRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Custom do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = UpdateModel.Name;
                result.Status = UpdateModel.Status;
                result.Value = UpdateModel.Values;
                try
                {
                    await _CustomRepository.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }


            }

        }
        [HttpDelete]
        [Route("delete-custom/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _CustomRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Custom do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _CustomRepository .UpdateOneAsyn(result);
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
