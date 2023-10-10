using API.IService;
using API.ViewModel.MonitorViewModel;
using API.ViewModel.OrderDetail;
using Data.IRepositories;
using DATA.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IAllRepositories<OrderDetail> _OrderDetailController;
        private IOrderDetailService _Service;
        public OrderDetailController(IAllRepositories<OrderDetail> orderDetailController, IOrderDetailService Service)
        {
            _OrderDetailController = orderDetailController;
            _Service = Service;
        }
        [HttpGet]
        [Route("get-all-order-detail")]
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
        [HttpGet]
        [Route("get-order-detail-by-id/{id}")]
        public async Task<IActionResult> GetBatteryById(string id)
        {
            var result = await _OrderDetailController.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Order Detail Do Not Exit");
            return Ok(result);
        }
        [HttpPost]
        [Route("create-monitor-detail")]
        public async Task<IActionResult> Create(CreateOrderDetail create)
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
        [HttpPut]
        [Route("update-monitor-detail")]
        public async Task<IActionResult> Update(string Id,UpdateOrderDetail update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state invalid");
            }

            var serviceResult = await _Service.Update(Id,update);

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
        [Route("Delete-order-detail/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _OrderDetailController.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Order Detail do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _OrderDetailController.UpdateOneAsync(result);
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
