using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.IService;
using PagedList;
using API.ViewModel.MonitorViewModel;
using API.Extensions;
using System.DirectoryServices.Protocols;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorDetailController : ControllerBase
    {
        private IAllRepositories<Producer> _ProducerRepository;
        private IAllRepositories<Category> _CategoryRepository;
        private IAllRepositories<DATA.Entity.Monitor> _MonitorRepository;
        private IAllRepositories<MonitorDetail> _MonitorDetailRepository;
        private IAllRepositories<Panel> _PanelRepository;
        private IAllRepositories<Resolution> _ResolutionRepository;
        private IMonitorDetailService _Service;
        public MonitorDetailController(IAllRepositories<Producer> producerRepository, IAllRepositories<Category> categoryRepository, IAllRepositories<DATA.Entity.Monitor> monitorRepository, IAllRepositories<MonitorDetail> monitorDetailRepository, IMonitorDetailService Service)
        {
            _ProducerRepository = producerRepository;
            _CategoryRepository = categoryRepository;
            _MonitorRepository = monitorRepository;
            _MonitorDetailRepository = monitorDetailRepository;
            _Service = Service;
        }
        [HttpGet]
        [Route("get-all-monitor-detail-page")]
        public async Task<IActionResult> GetAllLaptopDetailPage(int page = 1, int Size = 10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang
            var list = await _Service.GetAll();
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
        [Route("get-monitor-detail-by-id/{id}")]
        public async Task<IActionResult> GeById(string id)
        {
            var list = await _Service.GetAll();
            var result = list.Where(c => c.ID == id).FirstOrDefault();

            if (result == null || result.Status == 0) return Ok("Category Do Not Exit");
            return Ok(result);
        }
        [HttpGet]
        [Route("find-monitor-detail")]
        public async Task<IActionResult> Find(decimal? from, decimal? to, string? search, int? status)
        {
            var listProductDetail = await _Service.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Name.ToLower().Contains(Find) || x.ProducreName.ToLower().Trim().Contains(Find) || x.CatgoryName.Contains(Find));
            }
            if (from.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Price >= from);
            }
            if (to.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Price <= to);
            }
            if (status.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Status == status);
            }
            if (from.HasValue && to.HasValue && !string.IsNullOrEmpty(search))
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Price >= from && x.Price <= to && x.Name.ToLower().Contains(Find));
            }
            if (from.HasValue && to.HasValue && !string.IsNullOrEmpty(search) && status.HasValue)
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Price >= from && x.Price <= to && x.Name.ToLower().Trim().Contains(Find) || x.ProducreName.ToLower().Trim().Contains(Find) || x.CatgoryName.ToLower().Trim().Contains(Find) && x.Status == status);
            }

            return Ok(listProductDetail);
        }
        [HttpDelete]
        [Route("delete-laptopdetail/{id}")]
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
                    await _MonitorDetailRepository.UpdateOneAsyn(result);
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
            if (!ModelState.IsValid || create.COGS > create.Price)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var Monitor = await _MonitorRepository.GetByIdAsync(create.MonitorID);
            var Panel = await _PanelRepository.GetByIdAsync(create.PanelID);
            var Resolution = await _ResolutionRepository.GetByIdAsync(create.ResolutionID);
            if (Monitor.Status == 0 || Panel.Status == 0 || Resolution.Status == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var data = await _MonitorDetailRepository.GetAllAsync();
            var id = "MNDT" + Helper.GenerateRandomString(5);
            var seri = Helper.GenerateRandomString(8);

            do
            {
                id = "MNDT" + Helper.GenerateRandomString(5);
                seri = Helper.GenerateRandomString(8);
            } while (data.Any(c => c.ID == id || c.Seri == seri));

            MonitorDetail monitorDetail = new MonitorDetail()
            {
                ID = id,
                Seri = seri,
                Price = create.Price,
                COGS = create.COGS,
                Quatity = create.Quatity,
                Status = 1,
                Brightness = create.Brightness,
                Inch = create.Inch,
                Rate = create.Rate,
                Display = create.Display,
                Description = create.Description,
                PanelID = create.PanelID,
                ResolutionID = create.ResolutionID,
                MonitorID = create.MonitorID,
                Speaker = create.Speaker,
            };
            try
            {
                var result = await _MonitorDetailRepository.AddOneAsyn(monitorDetail);
                return Ok(monitorDetail);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }
        }
        [HttpPost]
        [Route("update-monitor-detail/id")]
        public async Task<IActionResult> Update(string id, UpdateMonitorViewModel update)
        {
            var result = await _MonitorDetailRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            if (!ModelState.IsValid || update.COGS > update.Price)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var Monitor = await _MonitorRepository.GetByIdAsync(update.MonitorID);
            var Panel = await _PanelRepository.GetByIdAsync(update.PanelID);
            var Resolution = await _ResolutionRepository.GetByIdAsync(update.ResolutionID);
            if (Monitor.Status == 0 || Panel.Status == 0 || Resolution.Status == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            result.Price = update.Price;
            result.COGS = update.COGS;
            result.Quatity = update.Quatity;
            result.Status = update.Status;
            result.Brightness = update.Brightness;
            result.Inch = update.Inch;
            result.Rate = update.Rate;
            result.Display = update.Display;
            result.Description = update.Description;
            result.PanelID = update.PanelID;
            result.ResolutionID = update.ResolutionID;
            result.MonitorID = update.MonitorID;
            result.Speaker = update.Speaker;
            try
            {
                await _MonitorDetailRepository.UpdateOneAsyn(result);
                return Ok(result);  
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
            }
        }

    }
}
