using API.Extensions;
using API.ViewModel.CustomViewModel;
using API.ViewModel.ViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolutionController : ControllerBase
    {
        private IAllRepositories<Resolution> _repo;
        public ResolutionController(IAllRepositories<Resolution> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("get-all-resolution")]
        public async Task<IActionResult> GetAll(int page = 1, int Size = 10)
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
        [Route("get-resolution-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Power Do Not Exit");
            return Ok(result);
        }

        [HttpPost]
        [Route("create-resolution")]
        public async Task<IActionResult> Create(CreateViewModel create)
        {
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var id = "Res" + Helper.GenerateRandomString(5);
            Resolution ex = new Resolution();
            do
            {
                id = "Res" + Helper.GenerateRandomString(5);
                ex = await _repo.GetByIdAsync(id);
            } while (ex != null);
            Resolution NewObj = new Resolution()
            {
                ID = id,
                Name = create.Name,
                Value = create.Values,
                Status = 1
            };
            try
            {
                var result = await _repo.AddOneAsyn(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPost]
        [Route("update-power/id")]
        public async Task<IActionResult> Update(string id, UpdateViewModel update)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Resolution do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = update.Name;
                result.Status = update.Status;
                result.Value = update.Values;
                try
                {
                    await _repo.UpdateOneAsyn(result);
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
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Resolution do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _repo.UpdateOneAsyn(result);
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
