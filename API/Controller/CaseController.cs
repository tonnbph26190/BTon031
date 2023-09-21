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
    public class CaseController : ControllerBase
    {
        private IAllRepositories<Case> _CaseRepository;
        public CaseController(IAllRepositories<Case> repo)
        {
            _CaseRepository = repo;
        }
        [HttpGet]
        [Route("get-all-case")]
        public async Task<IActionResult> GetAll(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _CaseRepository.GetAllAsync();

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
        [Route("get-case-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _CaseRepository.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Case Do Not Exit");
            return Ok(result);
        }
        [HttpPost]
        [Route("create-case")]
        public async Task<IActionResult> Create(CreateViewModel createModel)
        {
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var id = "Cae" + Helper.GenerateRandomString(5);
            Case ex = new Case();
            do
            {
                id = "Cae" + Helper.GenerateRandomString(5);
                ex = await _CaseRepository.GetByIdAsync(id);
            } while (ex != null);
            Case NewObj = new Case()
            {
                ID = id,
                Name = createModel.Name,
                Value = createModel.Values,
                Status = 1
            };
            try
            {
                var result = await _CaseRepository.AddOneAsyn(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }
        }
        [HttpPost]
        [Route("update-case/id")]
        public async Task<IActionResult> Update(string id, UpdateViewModel updateModel)
        {
            var result = await _CaseRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Case do not Exist");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    StatusCode(StatusCodes.Status400BadRequest, "Error Request");
                }
                result.Name = updateModel.Name;
                result.Status = updateModel.Status;
                result.Value = updateModel.Values;
                try
                {
                    await _CaseRepository.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }
            }
        }
        [HttpDelete]
        [Route("delete-case/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _CaseRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Case do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _CaseRepository.UpdateOneAsyn(result);
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
