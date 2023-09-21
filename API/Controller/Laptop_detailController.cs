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
        private IAllRepositories<SSD> _SSDRepositoty;
        private IAllRepositories<VGA> _VGARepositoty;
        private IAllRepositories<Ram> _RamRepositoty;
        private IAllRepositories<Battery> _BatteryRepositoty;
        private IAllRepositories<Main> _MainRepositoty;
        private IAllRepositories<Webcam> _WebCamRepositoty;
        private IAllRepositories<Screen> _ScreenRepositoty;
        private IAllRepositories<Laptop> _LapTopRepositoty;
        private IAllRepositories<Producer> _ProducerRepositoty;
        private IAllRepositories<Category> _CategoryRepositoty;
        private ILapTopDetailService _Services;
        public Laptop_detailController(IAllRepositories<Laptop_Detail> repo, IAllRepositories<SSD> repoSSD, IAllRepositories<VGA> repoVGA, IAllRepositories<Ram> repoRam, IAllRepositories<Battery> repoBattery, IAllRepositories<Main> repoMain, IAllRepositories<Webcam> repoWebCam, IAllRepositories<Screen> repoScreen, IAllRepositories<Laptop> repoLap, IAllRepositories<Producer> repoPro, IAllRepositories<Category> repoCat, ILapTopDetailService Services)
        {
          _LapTopDetailRepositoty= repo;
            _SSDRepositoty=repoSSD;
            _VGARepositoty = repoVGA;
            _RamRepositoty=repoRam;
            _BatteryRepositoty=repoBattery;
            _MainRepositoty = repoMain;
            _Services= Services;
            _WebCamRepositoty = repoWebCam;
            _ScreenRepositoty = repoScreen;
            _LapTopRepositoty = repoLap;
            _ProducerRepositoty = repoPro;
            _CategoryRepositoty = repoCat;
        }
        [HttpGet]
        [Route("get-all-laptopdetail-page")]
        public async Task<IActionResult> GetAllLaptopDetailPage(int page=1, int Size=10)
        {
            var pageNumber = page; // Trang hiện tại (mặc định là 1)
            var pageSize = Size; // Số mục trên mỗi trang
            var list =await _Services.GetAllLaptopDetail();
            if (list==null)
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
            var result= list.Where(c=>c.ID==id).FirstOrDefault();

            if (result == null || result.Status == 0) return Ok("Category Do Not Exit");
            return Ok(result);
        }
        [HttpGet]
        [Route("find-laptopdetail")]
        public async Task<IActionResult> FindCategory(decimal? from, decimal? to, string? search,int? status)
        {
            var listProductDetail = await _Services.GetAllLaptopDetail();
            if (!string.IsNullOrEmpty(search))
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(
                    x => x.Name.ToLower().Contains(Find)
                    ||x.ProducerName.ToLower().Trim().Contains(Find)
                    ||x.CategoryName.Contains(Find));
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
                listProductDetail=listProductDetail.Where(x=>x.Status == status);
            }
            if (from.HasValue && to.HasValue&& !string.IsNullOrEmpty(search))
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Price >= from && x.Price <= to&&x.Name.ToLower().Contains(Find));
            }
            if (from.HasValue && to.HasValue && !string.IsNullOrEmpty(search)&&status.HasValue)
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(
                    x => x.Price >= from && x.Price <= to 
                    && x.Name.ToLower().Trim().Contains(Find)
                    ||x.ProducerName.ToLower().Trim().Contains(Find)
                    ||x.CategoryName.ToLower().Trim().Contains(Find)
                    &&x.Status==status);
            }

            return Ok(listProductDetail);
        }
        [HttpPost]
        [Route("create-laptopdetail")]
        public async Task<IActionResult> CreateLaptopDetail( CreateLaptopViewModel create)
        {
            if (!ModelState.IsValid|| create.COGS>create.Price)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            
            //
            if (  await _Services.CheckComponentsStatus(create))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var LaptopDetailExist =await _Services.FindExistingDetailAsync(create);
            if (LaptopDetailExist!=null)
            {
                LaptopDetailExist.Quatity = LaptopDetailExist.Quatity + create.Quatity;
                LaptopDetailExist.Price = create.Price;
                LaptopDetailExist.COGS = create.COGS;
               await _LapTopDetailRepositoty.UpdateOneAsyn(LaptopDetailExist);
                return StatusCode(StatusCodes.Status200OK, "Update Quatity succes");
            }
            
            var data = await _LapTopDetailRepositoty.GetAllAsync();
            var id = "DTL" + Helper.GenerateRandomString(5);
            var seri = Helper.GenerateRandomString(8);

            do
            {
                id = "DTL" + Helper.GenerateRandomString(5);
                seri = Helper.GenerateRandomString(8);
            } while (data.Any(c => c.ID == id || c.Seri == seri));

            Laptop_Detail cv = new Laptop_Detail()
            {
                ID = id,
                Seri = seri,
                COGS = create.COGS,
                Price = create.Price,
                Quatity = create.Quatity,
                IdSSD = create.IdSSD,
                IdRam = create.IdRam,
                IdBattery = create.IdBattery,
                IdCam = create.IdCam,
                IdLap = create.IdLap,
                IdMain = create.IdMain,
                IdScren = create.IdScreen,
                IdVga = create.IdVga,
                Weight = create.Weight,
                leght = create.leght,
                Hight = create.Hight,
                Status = 1,
            };

            try
            {
                var result = await _LapTopDetailRepositoty.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }
        }
        [HttpPost]
        [Route("update-Laptopdetail/id")]
        public async Task<IActionResult> UpdateLaptopDetail(string id,  UpdateLaptopDetailViewModel update)
        {
            var result = await _LapTopDetailRepositoty.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }

            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            if (await _Services.CheckComponentsStatus(update))
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }

            var LaptopDetailExist = await _Services.FindExistingDetailAsync(update);

            if (LaptopDetailExist != null)
            {
                LaptopDetailExist.Quatity = LaptopDetailExist.Quatity + update.Quatity;
                LaptopDetailExist.Price = update.Price;
                LaptopDetailExist.COGS = update.COGS;
                await _LapTopDetailRepositoty.UpdateOneAsyn(LaptopDetailExist);
                return StatusCode(StatusCodes.Status200OK, "Update Quatity succes");
            }
            else
            {          
                result.COGS = update.COGS;
                result.Price = update.Price;
                result.Quatity = update.Quatity;
                result.IdSSD = update.IdSSD;
                result.IdRam = update.IdRam;
                result.IdBattery = update.IdBattery;
                result.IdCam = update.IdCam;
                result.IdLap = update.IdLap;
                result.IdMain = update.IdMain;
                result.IdScren = update.IdScreen;
                result.IdVga = update.IdVga;
                result.Weight = update.Weight;
                result.leght = update.leght;
                result.Hight = update.Hight;
                result.Status = update.Status;
                try
                {
                    await _LapTopDetailRepositoty.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }
            }
        }
        [HttpDelete]
        [Route("delete-laptopdetail/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _LapTopDetailRepositoty.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            else
            {
                try
                {
                    result.Status = 0;
                    await _LapTopDetailRepositoty.UpdateOneAsyn(result);
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
