using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.IService;
using PagedList;
using API.ViewModel.MonitorViewModel;
using API.Extensions;
using System.DirectoryServices.Protocols;
using AutoMapper;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorDetailController : ControllerBase
    {
        private IAllRepositories<MonitorDetail> _MonitorDetailRepository;
        private IMonitorDetailService _Service;
        public MonitorDetailController(IAllRepositories<MonitorDetail> monitorDetailRepository, IMonitorDetailService Service)
        {
            _MonitorDetailRepository = monitorDetailRepository;
            _Service = Service;
        }

        [HttpGet]
        [Route("get-all-monitor-detail-page")]
        public async Task<IActionResult> GetAllPage(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang
            var list = await _Service.GetAll();
            if (list.Count() == 0)
                return BadRequest("Data not available");
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
        [Route("get-monitor-detail-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var list = await _Service.GetAll();
            var result = list.Where(c => c.ID == id).FirstOrDefault();

            if (result == null || result.Status == 0) return BadRequest("Category Do Not Exit");
            return Ok(result);
        }

        [HttpGet]
        [Route("find-monitor-detail")]
        public async Task<IActionResult> Find(decimal? from, decimal? to, string? search, int? status)
        {
            return Ok(await _Service.SearchProductDetails(search, from, to, status));
        }

        [HttpDelete]
        [Route("delete-laptop-detail/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _MonitorDetailRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _MonitorDetailRepository.UpdateOneAsync(result);
                    return Ok("Delete Successfully");
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Delete Fail");
                }
            }
        }

        [HttpPost]
        [Route("create-monitor-detail")]
        public async Task<IActionResult> Create(CreateMonitorViewModel create)
        {
            if (!ModelState.IsValid || create.COGS > create.Price || create.Quatity <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }


            if (await _Service.ValidateMonitorPanelResolutionAsync(create))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var serviceResult = await _Service.CreateMonitorDetail(create);

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
        [Route("update-monitor-detail/id")]
        public async Task<IActionResult> Update(string id, UpdateMonitorViewModel update)
        {
            if (!ModelState.IsValid || update.COGS > update.Price || update.Quatity <= 0)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            if (await _Service.ValidateMonitorPanelResolutionAsync(update))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var serviceResult = await _Service.UpdateMonitorDetail(id,update);

            if (serviceResult.IsSuccess)
            {
                return Ok(serviceResult.Data);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, serviceResult.ErrorMessage);
            }
        }

    }
}
