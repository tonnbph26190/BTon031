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

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Laptop_detailController : ControllerBase
    {
        private IAllRepositories<Laptop_Detail> _repo;
        private IAllRepositories<SSD> _repoSSD;
        private IAllRepositories<VGA> _repoVGA;
        private IAllRepositories<Ram> _repoRam;
        private IAllRepositories<Battery> _repoBattery;
        private IAllRepositories<Main> _repoMain;
        private IAllRepositories<Webcam> _repoWebCam;
        private IAllRepositories<Screen> _repoScreen;
        private IAllRepositories<Laptop> _repoLap;
        private IAllRepositories<Producer> _repoPro;
        private IAllRepositories<Category> _repoCat;
        public Laptop_detailController(IAllRepositories<Laptop_Detail> repo, IAllRepositories<SSD> repoSSD, IAllRepositories<VGA> repoVGA, IAllRepositories<Ram> repoRam, IAllRepositories<Battery> repoBattery, IAllRepositories<Main> repoMain, IAllRepositories<Webcam> repoWebCam, IAllRepositories<Screen> repoScreen, IAllRepositories<Laptop> repoLap, IAllRepositories<Producer> repoPro, IAllRepositories<Category> repoCat)
        {
            _repo = repo;
            _repoSSD = repoSSD;
            _repoVGA = repoVGA;
            _repoRam = repoRam;
            _repoBattery = repoBattery;
            _repoMain = repoMain;
            _repoWebCam = repoWebCam;
            _repoScreen = repoScreen;
            _repoLap = repoLap;
            _repoScreen = repoScreen;
            _repoPro = repoPro;
            _repoCat = repoCat;
        }
        [HttpGet]
        [Route("Get-All-LaptopDetail")]
        public async Task<IEnumerable<ViewLaptopDetail>> GetAllLaptopDetail()
        {
            var results = await _repo.GetAllAsync();
            if (results == null) return new List<ViewLaptopDetail>();
            List<ViewLaptopDetail> laptopDetails= new List<ViewLaptopDetail>();
            laptopDetails =
                (
                from a in await _repo.GetAllAsync()
                join b in await _repoRam.GetAllAsync() on a.IdRam equals b.ID
                join c in await _repoMain.GetAllAsync() on a.IdMain equals c.ID
                join d in await _repoSSD.GetAllAsync() on a.IdSSD equals d.ID
                join e in await _repoVGA.GetAllAsync() on a.IdVga equals e.ID
                join f in await _repoWebCam.GetAllAsync() on a.IdCam equals f.ID
                join g in await _repoLap.GetAllAsync() on a.IdLap equals g.ID
                join i in await _repoBattery.GetAllAsync() on a.IdBattery equals i.ID
                join k in await _repoPro.GetAllAsync() on g.IdProducer equals k.ID
                join l in await _repoCat.GetAllAsync() on g.IdCat equals l.ID
                join q in await _repoScreen.GetAllAsync() on a.IdScren equals q.ID
                select new ViewLaptopDetail
                {
                    Seri=a.Seri,
                    COGS=a.COGS,
                    Price=a.Price,
                    Status=a.Status,
                    Name= g.Name+" Ram: "+b.Name+" Bộ nhớ trong: "+d.Name+" Card: "+e.Name,
                    NameRam=b.Name,
                    RamPara=b.Parameter,
                    NameMain=c.Name,
                    MainPara=c.Parameter,
                    NameSSD=d.Name,
                    SSDPara=d.Parameter,    
                    NameVga=e.Name,
                    VGaPara= e.Parameter,
                    NameCam=f.Name,
                    CAMPara=f.Parameter,
                    NameScren=q.Name,
                    ScreenSize=q.Size,
                    ScreenRate=q.Rate,
                    NameBattery=i.ID,
                    PinPara=i.Name,
                    NameLap=g.Name,
                    NameCat=l.Name,
                    NamePro=k.Name,
                    Hight=a.Hight,
                    Weight=a.Weight,
                    leght=a.leght                  
                }
                ).ToList();
            var filteredLaptopDetails = laptopDetails.Where(x => x.Status == 1).ToList();
            
            return filteredLaptopDetails.ToList();
        }
        [HttpGet]
        [Route("Get-All-LaptopDetail")]
        public async Task<IActionResult> GetAllLaptopDetailPage(int? page, int? Size)
        {
            var pageNumber = page ?? 1; // Trang hiện tại (mặc định là 1)
            var pageSize = Size ?? 10; // Số mục trên mỗi trang
            var list =await GetAllLaptopDetail();
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
        [Route("GetLapTopDetailById/{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null || result.Status == 0) return Ok("Category Do Not Exit");
            return Ok(result);
        }
        [HttpGet]
        [Route("FindtLapTopDetail/{id}")]
        public async Task<IActionResult> FindCategoryById(decimal? from, decimal? to, string? search)
        {
            var listProductDetail = await GetAllLaptopDetail();
            if (!string.IsNullOrEmpty(search))
            {
                listProductDetail = listProductDetail.Where(x => x.Name.Contains(search));
            }
            if (from.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Price >= from);
            }
            if (to.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Price <= to);
            }

            return Ok(listProductDetail);
        }
        [HttpPost]
        [Route("Create_LapTopDetail")]
        public async Task<IActionResult> CreateLaptopDetail([FromForm] CreateLaptopViewModel ccv)
        {
            if (!ModelState.IsValid|| ccv.COGS>ccv.Price)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var Ram =await _repoRam.GetByIdAsync(ccv.IdRam);
            var SSD = await _repoSSD.GetByIdAsync(ccv.IdSSD);
            var Battery = await _repoSSD.GetByIdAsync(ccv.IdBattery);
            var Cam = await _repoWebCam.GetByIdAsync(ccv.IdCam);
            var Lap = await _repoLap.GetByIdAsync(ccv.IdLap);
            var Main = await _repoLap.GetByIdAsync(ccv.IdMain);
            var Screen = await _repoScreen.GetByIdAsync(ccv.IdScren);
            var VGA = await _repoVGA.GetByIdAsync(ccv.IdVga);
            if (Ram.Status==0||SSD.Status==0|| Battery.Status==0||Cam.Status==0||Lap.Status==0||Main.Status==0||Screen.Status==0||VGA.Status==0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var data = await _repo.GetAllAsync();
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
                COGS = ccv.COGS,
                Price = ccv.Price,
                Quatity = ccv.Quatity,
                IdSSD = ccv.IdSSD,
                IdRam = ccv.IdRam,
                IdBattery = ccv.IdBattery,
                IdCam = ccv.IdCam,
                IdLap = ccv.IdLap,
                IdMain = ccv.IdMain,
                IdScren = ccv.IdScren,
                IdVga = ccv.IdVga,
                Weight = ccv.Weight,
                leght = ccv.leght,
                Hight = ccv.Hight,
                Status = 1,
            };
            try
            {
                var result = await _repo.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Fail");
            }
        }
        [HttpPost]
        [Route("Update_LapTopDetail/id")]
        public async Task<IActionResult> UpdateCategory(string id, [FromForm] UpdateLaptopDetailViewModel ccv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            if (!ModelState.IsValid)
            {
                StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            var Ram =await _repoRam.GetByIdAsync(ccv.IdRam);
            var SSD = await _repoSSD.GetByIdAsync(ccv.IdSSD);
            var Battery = await _repoSSD.GetByIdAsync(ccv.IdBattery);
            var Cam = await _repoWebCam.GetByIdAsync(ccv.IdCam);
            var Lap = await _repoLap.GetByIdAsync(ccv.IdLap);
            var Main = await _repoLap.GetByIdAsync(ccv.IdMain);
            var Screen = await _repoScreen.GetByIdAsync(ccv.IdScren);
            var VGA = await _repoVGA.GetByIdAsync(ccv.IdVga);
            if (Ram.Status==0||SSD.Status==0||Battery.Status==0||Cam.Status==0||Lap.Status==0||Main.Status==0||Screen.Status==0||VGA.Status==0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error Request");
            }
            else
            {          
                result.COGS = ccv.COGS;
                result.Price = ccv.Price;
                result.Quatity = ccv.Quatity;
                result.IdSSD = ccv.IdSSD;
                result.IdRam = ccv.IdRam;
                result.IdBattery = ccv.IdBattery;
                result.IdCam = ccv.IdCam;
                result.IdLap = ccv.IdLap;
                result.IdMain = ccv.IdMain;
                result.IdScren = ccv.IdScren;
                result.IdVga = ccv.IdVga;
                result.Weight = ccv.Weight;
                result.leght = ccv.leght;
                result.Hight = ccv.Hight;
                result.Status = ccv.Status;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update Fail");
                }
            }
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category do not Exist");
            }
            else
            {
                try
                {
                    await _repo.DeleteOneAsyn(result);
                    return Ok("Delete Successfully");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Delete Fail");
                }


            }
        }
    }
}
