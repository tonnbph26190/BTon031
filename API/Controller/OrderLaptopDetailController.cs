using API.IService;
using API.ViewModel.OrderDetail;
using API.ViewModel.OrderDetailLaptopDetailViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLaptopDetailController : ControllerBase
    {
        IOrderDetailLaptopDetailService _Service;
        public OrderLaptopDetailController(IOrderDetailLaptopDetailService service)
        {
            _Service = service;
        }
        [HttpGet]
        [Route("get-all-order-detail-laptop-detail")]
        public async Task<IActionResult> GetAllBattery(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _Service.GetAll();

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

        [HttpPost]
        [Route("create-Order-detail-laptop-detail")]
        public async Task<IActionResult> Create(CreateOrdDetailLaptopDetail create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state invalid");
            }
            var serviceResult = await _Service.Create(create);

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
