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

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcDetailController : ControllerBase
    {
        private IAllRepositories<PcDetail> _PcDetailRepository;
        private IAllRepositories<SSD> _SSDRepository;
        private IAllRepositories<VGA> _VGARepository;
        private IAllRepositories<Ram> _RamRepository;
        private IAllRepositories<Main> _MainRepository;
        private IAllRepositories<PC> _PcRepository;
        private IAllRepositories<Power> _PowerRepository;
        private IAllRepositories<Case> _CaseRepository;
        private IAllRepositories<Custom> _CustomRepository;
        private IAllRepositories<Producer> _ProducerRepository;
        private IAllRepositories<Category> _CategoryRepository;
        private IAllRepositories<Cooling> _CoolingRepository;
        private IPcDetailService _Service;
        public PcDetailController(IAllRepositories<PcDetail> PcDetailRepository, IAllRepositories<SSD> SSDRepository, IAllRepositories<VGA> VGARepository, IAllRepositories<Ram> RamRepository, IAllRepositories<Main> MainRepository, IAllRepositories<PC> PcRepository, IAllRepositories<Power> PowerRepository, IAllRepositories<Case> CaseRepository, IAllRepositories<Custom> CustomRepository, IAllRepositories<Producer> ProducerRepository, IAllRepositories<Category> CategoryRepository, IAllRepositories<Cooling> CoolingRepository, IPcDetailService Service)
        {
            _PcDetailRepository = PcDetailRepository;
            _MainRepository = MainRepository;
            _CaseRepository = CaseRepository;
            _CategoryRepository = CategoryRepository;
            _ProducerRepository = ProducerRepository;
            _PcRepository = PcRepository;
            _PowerRepository = PowerRepository;
            _RamRepository = RamRepository;
            _VGARepository = VGARepository;
            _SSDRepository = SSDRepository;
            _CustomRepository = CustomRepository;
            _CoolingRepository = CoolingRepository;
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
            var listProductDetail = await _Service.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Name.ToLower().Contains(Find)
                || x.ProducerName.ToLower().Trim().Contains(Find)
                || x.CategoryName.Contains(Find));
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
                listProductDetail = listProductDetail.Where(x => x.Price >= from && x.Price <= to && x.Name.ToLower().Trim().Contains(Find)
                || x.ProducerName.ToLower().Trim().Contains(Find)
                || x.CategoryName.ToLower().Trim().Contains(Find));
            }
            if (from.HasValue && to.HasValue && !string.IsNullOrEmpty(search) && status.HasValue)
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Price >= from && x.Price <= to && x.Name.ToLower().Trim().Contains(Find)
                || x.ProducerName.ToLower().Trim().Contains(Find)
                || x.CategoryName.ToLower().Trim().Contains(Find) && x.Status == status);
            }

            return Ok(listProductDetail);
        }
        [HttpPost]
        [Route("create-pc-detail")]
        public async Task<IActionResult> Create(CreatePcDetail create)
        {
            if (!ModelState.IsValid || create.COGS > create.Price)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            if (await _Service.IsUpdateRequestValid(create))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            var PcDetailExist = await _Service.CheckPcDetailExistence(create);

            if (PcDetailExist != null)
            {
                PcDetailExist.Quatity = PcDetailExist.Quatity + create.Quatity;
                PcDetailExist.Price = create.Price;
                PcDetailExist.COGS = create.COGS;
                await _PcDetailRepository.UpdateOneAsyn(PcDetailExist);
                return StatusCode(StatusCodes.Status200OK, "Update Quatity succes");
            }
            //
            var data = await _PcDetailRepository.GetAllAsync();
            var id = "DTPC" + Helper.GenerateRandomString(5);
            var seri = Helper.GenerateRandomString(8);
            do
            {
                id = "DTPC" + Helper.GenerateRandomString(5);
                seri = Helper.GenerateRandomString(8);
            } while (data.Any(c => c.ID == id || c.Seri == seri));
            PcDetail pc = new PcDetail()
            {
                ID = id,
                Seri = seri,
                COGS = create.COGS,
                Price = create.Price,
                Quatity = create.Quatity,
                RamID = create.RamID,
                SSDId = create.SSDId,
                PowerID = create.PowerID,
                PcID = create.PcID,
                MainID = create.MainID,
                VgaID = create.VgaID,
                CoolingID = create.CoolingID,
                CaseID = create.CaseID,
                CustomID = create.CustomID == null ? null : create.CustomID,
                Status = 1,
            };
            try
            {
                var result = await _PcDetailRepository.AddOneAsyn(pc);
                return Ok(pc);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }

        }
        [HttpPut]
        [Route("update-pc-detail/id")]
        public async Task<IActionResult> Update(string id, UpdatePcDetail update)
        {
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var result = await _PcDetailRepository.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Pc Detail do not Exist");
            }
            //
            if (await _Service.IsUpdateRequestValid(update))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            //
            var PcDetailExist = await _Service.CheckPcDetailExistence(update);

            if (PcDetailExist != null)
            {
                PcDetailExist.Quatity = PcDetailExist.Quatity + update.Quatity;
                PcDetailExist.Price = update.Price;
                PcDetailExist.COGS = update.COGS;
                await _PcDetailRepository.UpdateOneAsyn(PcDetailExist);
                return StatusCode(StatusCodes.Status200OK, "Update Quatity succes");
            }
            result.COGS = update.COGS;
            result.Price = update.Price;
            result.Quatity = update.Quatity;
            result.RamID = update.RamID;
            result.SSDId = update.SSDId;
            result.PowerID = update.PowerID;
            result.PcID = update.PcID;
            result.MainID = update.MainID;
            result.VgaID = update.VgaID;
            result.CoolingID = update.CoolingID;
            result.CaseID = update.CaseID;
            result.CustomID = update.CustomID == null ? null : update.CustomID;
            result.Status = update.Status;
            try
            {
                await _PcDetailRepository.UpdateOneAsyn(result);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
            }
        }
        [HttpDelete]
        [Route("delete-laptopdetail/{id}")]
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
                    await _PcDetailRepository.UpdateOneAsyn(result);
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
