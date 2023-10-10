using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using API.Extensions;
using API.ViewModel.CaseViewModel;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IAllRepositories<Order> _OderRepository;
        public OrderController(IAllRepositories<Order> OderRepo)
        {
            _OderRepository = OderRepo;
        }
        [HttpGet]
        [Route("get-all-Order")]
        public async Task<IActionResult> GetAll(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang

            var results = await _OderRepository.GetAllAsync();

            var totalCount = results.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var pagedResults = results.ToPagedList(pageNumber, pageSize);

            var response = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Results = pagedResults
            };

            return Ok(response);
        }
        [HttpGet]
        [Route("get-order-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _OderRepository.GetByIdAsync(id);
            if (result == null) return BadRequest("Case Do Not Exit");
            return Ok(result);
        }
        [HttpPost]
        [Route("create-Oder")]
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var id = "Ord" + Helper.GenerateRandomString(5);
            Order ex = new Order();
            do
            {
                id = "Ord" + Helper.GenerateRandomString(5);
                ex = await _OderRepository.GetByIdAsync(id);
            } while (ex != null);
            Order NewObj = new Order()
            {
                ID = id,
            };
            try
            {
                var result = await _OderRepository.AddOneAsync(NewObj);
                return Ok(NewObj);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }
        }


    }
}
