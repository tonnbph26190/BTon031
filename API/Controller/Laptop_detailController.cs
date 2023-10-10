using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.Extensions;
using API.ViewModel.CategoryViewModel;
using API.ViewModel.LatopDetailViewModel;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using API.IService;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Laptop_detailController : ControllerBase
    {
        private IAllRepositories<Laptop_Detail> _LapTopDetailRepositoty;
        private ILapTopDetailService _Services;
        public Laptop_detailController(IAllRepositories<Laptop_Detail> repo, ILapTopDetailService Services)
        {
            _LapTopDetailRepositoty = repo;
            _Services = Services;
        }
        [HttpGet]
        [Route("get-all-laptopdetail-page")]
        public async Task<IActionResult> GetAllLaptopDetailPage(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang
            var list = await _Services.GetAllLaptopDetail();
            if (list == null)
                return Ok("Data not available");
            var totalCount = list.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var pagedResults = list.ToPagedList(pageNumber, pageSize);
            var response = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Results = pagedResults
            };
            return Ok(response);
        }
        [HttpGet]
        [Route("get-laptopdetail-by-id/{id}")]
        public async Task<IActionResult> GetLaptopDetailById(string id)
        {
            var list = await _Services.GetAllLaptopDetail();
            var result = list.Where(c => c.ID == id).FirstOrDefault();

            if (result == null || result.Status == 0) return BadRequest("Category Do Not Exit");
            return Ok(result);
        }
        [HttpGet]
        [Route("find-laptopdetail")]
        public async Task<IActionResult> FindCategory(decimal? from, decimal? to, string? search, int? status)
        {

            return Ok(await _Services.FilterProductDetails(search, from, to, status));
        }
        [HttpPost]
        [Route("create-laptopdetail")]
        public async Task<IActionResult> CreateLaptopDetail(CreateLaptopViewModel create)
        {
            if (!ModelState.IsValid || create.COGS > create.Price || create.Quatity <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            if (await _Services.CheckComponentsStatus(create))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var serviceResult = await _Services.CreateLaptopDetail(create);

            if (serviceResult.IsSuccess)
            {
                return Ok(serviceResult.Data);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, serviceResult.ErrorMessage);
            }
        }
        [HttpPut]
        [Route("update-Laptopdetail/id")]
        public async Task<IActionResult> UpdateLaptopDetail(string id, UpdateLaptopDetailViewModel update)
        {
            if (!ModelState.IsValid || update.COGS >= update.Price || update.Quatity <= 0)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            if (await _Services.CheckComponentsStatus(update))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var serviceResult = await _Services.UpdateLaptopDetail(id,update);

            if (serviceResult.IsSuccess)
            {
                return Ok(serviceResult.Data);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, serviceResult.ErrorMessage);
            }
        }
        [HttpDelete]
        [Route("delete-laptop-detail/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _LapTopDetailRepositoty.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Laptop Detail do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _LapTopDetailRepositoty.UpdateOneAsync(result);
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
