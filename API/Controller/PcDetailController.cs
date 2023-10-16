using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.ViewModel.LatopDetailViewModel;
using API.ViewModel.PcViewModel;
using System.Threading.Tasks.Dataflow;
using PagedList;
using Microsoft.AspNetCore.Mvc.RazorPages;
using API.Extensions;
using API.IService;
using API.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AutoMapper;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcDetailController : ControllerBase
    {
        private IAllRepositories<PcDetail> _PcDetailRepository;
        private IPcDetailService _Service;
        public PcDetailController(IAllRepositories<PcDetail> PcDetailRepository, IPcDetailService Service)
        {
            _PcDetailRepository = PcDetailRepository;
            _Service = Service;
        }
        [HttpGet]
        [Route("get-all-pc-detail-page")]
        public async Task<IActionResult> GetAllPage(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang
            var list = await _Service.GetAll();
            if (list.Count() == 0)
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
        [Route("get-pc-detail-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var list = await _Service.GetAll();
            var result = list.Where(c => c.ID == id).FirstOrDefault();

            if (result == null || result.Status == 0) return Ok("LapTopDetail Do Not Exit");
            return Ok(result);
        }
        [HttpGet]
        [Route("find-pc-detail")]
        public async Task<IActionResult> Find(decimal? from, decimal? to, string? search, int? status)
        {
           return Ok( await _Service.GetFilteredProductDetails(search,from,to,status));    
        }
        [HttpPost]
        [Route("create-pc-detail")]
        public async Task<IActionResult> Create(CreatePcDetail create)
        {
            if (!ModelState.IsValid || create.Quatity <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            if (!await _Service.IsUpdateRequestValid(create))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            var serviceResult = await _Service.CreatePcDetail(create);

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
        [Route("update-pc-detail/id")]
        public async Task<IActionResult> Update(string id, UpdatePcDetail update)
        {
            if (!ModelState.IsValid|update.Quatity<=0)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            if (await _Service.IsUpdateRequestValid(update))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            var serviceResult = await _Service.UpdatePcDetail(id,update);

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
            var result = await _PcDetailRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Pc Detail do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _PcDetailRepository.UpdateOneAsync(result);
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
