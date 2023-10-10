using API.IService;
using API.ViewModel.LatopDetailViewModel;
using DATA.Entity;
using Data.IRepositories;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;
using API.ServiceResult;

namespace API.Service
{
    public class LapTopDetailService : ILapTopDetailService
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
        public LapTopDetailService(IAllRepositories<Laptop_Detail> repo, IAllRepositories<SSD> repoSSD, IAllRepositories<VGA> repoVGA, IAllRepositories<Ram> repoRam, IAllRepositories<Battery> repoBattery, IAllRepositories<Main> repoMain, IAllRepositories<Webcam> repoWebCam, IAllRepositories<Screen> repoScreen, IAllRepositories<Laptop> repoLap, IAllRepositories<Producer> repoPro, IAllRepositories<Category> repoCat)
        {
            _LapTopDetailRepositoty = repo;
            _SSDRepositoty = repoSSD;
            _VGARepositoty = repoVGA;
            _RamRepositoty = repoRam;
            _BatteryRepositoty = repoBattery;
            _MainRepositoty = repoMain;
            _WebCamRepositoty = repoWebCam;
            _ScreenRepositoty = repoScreen;
            _LapTopRepositoty = repoLap;
            _ProducerRepositoty = repoPro;
            _CategoryRepositoty = repoCat;
        }
        public async Task<IEnumerable<LaptopDetailDto>> GetAllLaptopDetail()
        {
            List<LaptopDetailDto> laptopDetails = new List<LaptopDetailDto>();
            laptopDetails =
                (
                from a in await _LapTopDetailRepositoty.GetAllAsync()
                join b in await _RamRepositoty.GetAllAsync() on a.IdRam equals b.ID
                join c in await _MainRepositoty.GetAllAsync() on a.IdMain equals c.ID
                join d in await _SSDRepositoty.GetAllAsync() on a.IdSSD equals d.ID
                join e in await _VGARepositoty.GetAllAsync() on a.IdVga equals e.ID
                join f in await _WebCamRepositoty.GetAllAsync() on a.IdCam equals f.ID
                join g in await _LapTopRepositoty.GetAllAsync() on a.IdLap equals g.ID
                join i in await _BatteryRepositoty.GetAllAsync() on a.IdBattery equals i.ID
                join k in await _ProducerRepositoty.GetAllAsync() on g.IdProducer equals k.ID
                join l in await _CategoryRepositoty.GetAllAsync() on g.IdCat equals l.ID
                join q in await _ScreenRepositoty.GetAllAsync() on a.IdScren equals q.ID
                select new LaptopDetailDto
                {
                    ID = a.ID,
                    Seri = a.Seri,
                    COGS = a.COGS,
                    Price = a.Price,
                    Status = a.Status,
                    Name = g.Name + " Ram: " + b.Name + " Bộ nhớ trong: " + d.Name + " Card: " + e.Name,
                    RamName = b.Name,
                    RamPara = b.Parameter,
                    MainName = c.Name,
                    MainPara = c.Parameter,
                    SSDName = d.Name,
                    SSDPara = d.Parameter,
                    VgaName = e.Name,
                    VGaPara = e.Parameter,
                    CamName = f.Name,
                    CAMPara = f.Parameter,
                    ScreenName = q.Name,
                    ScreenSize = q.Size,
                    ScreenRate = q.Rate,
                    BatteryName = i.ID,
                    PinPara = i.Name,
                    LaptopName = g.Name,
                    CategoryName = l.Name,
                    ProducerName = k.Name,
                    Hight = a.Hight,
                    Weight = a.Weight,
                    leght = a.leght,
                    Quatity = a.Quatity,
                }
                ).ToList();
            var filteredLaptopDetails = laptopDetails.Where(x => x.Status == 1).ToList();
            return filteredLaptopDetails.ToList();
        }
        public async Task<bool> CheckComponentsStatus(ILaptopDetailViewModel monitorViewModel)
        {
            var Ram = await _RamRepositoty.GetByIdAsync(monitorViewModel.IdRam);
            var SSD = await _SSDRepositoty.GetByIdAsync(monitorViewModel.IdSSD);
            var Battery = await _BatteryRepositoty.GetByIdAsync(monitorViewModel.IdBattery);
            var Cam = await _WebCamRepositoty.GetByIdAsync(monitorViewModel.IdCam);
            var Lap = await _LapTopRepositoty.GetByIdAsync(monitorViewModel.IdLap);
            var Main = await _MainRepositoty.GetByIdAsync(monitorViewModel.IdMain);
            var Screen = await _ScreenRepositoty.GetByIdAsync(monitorViewModel.IdScreen);
            var VGA = await _VGARepositoty.GetByIdAsync(monitorViewModel.IdVga);

            bool isAnyComponentInvalid = Ram.Status == 0 ||
                                         SSD.Status == 0 ||
                                         Battery.Status == 0 ||
                                         Cam.Status == 0 ||
                                         Lap.Status == 0 ||
                                         Main.Status == 0 ||
                                         Screen.Status == 0 ||
                                         VGA.Status == 0 ||
                                         VGA.Type != 1 ||
                                         SSD.Type != 1 ||
                                         Ram.Type != 1 ||
                                         Main.Type != 1;

            return isAnyComponentInvalid;
        }
        public async Task<Laptop_Detail> FindExistingDetailAsync(ILaptopDetailViewModel model)
        {
            var data = await _LapTopDetailRepositoty.GetAllAsync();
            var ValidData=data.Where(x=>x.Status== 1).ToList();

            var existingDetail = ValidData.FirstOrDefault(x =>
                x.IdRam == model.IdRam &&
                x.IdSSD == model.IdSSD &&
                x.IdBattery == model.IdBattery &&
                x.IdCam == model.IdCam &&
                x.IdLap == model.IdLap &&
                x.IdMain == model.IdMain &&
                x.IdScren == model.IdScreen &&
                x.IdVga == model.IdVga &&
                x.Weight == model.Weight &&
                x.leght == model.leght &&
                x.Hight== model.Hight);

            return existingDetail;
        }

        public async Task<IEnumerable<LaptopDetailDto>> FilterProductDetails(string? search, decimal? from, decimal? to, int? status)
        {
            var listProductDetail = await GetAllLaptopDetail();

            if (!string.IsNullOrEmpty(search))
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(
                    x => x.Name.ToLower().Contains(Find)
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
                listProductDetail = listProductDetail.Where(x => x.Price >= from
                && x.Price <= to
                && x.Name.ToLower().Contains(Find));
            }

            if (from.HasValue && to.HasValue && !string.IsNullOrEmpty(search) && status.HasValue)
            {
                var Find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(
                    x => x.Price >= from
                    && x.Price <= to
                    && x.Name.ToLower().Trim().Contains(Find)
                    || x.ProducerName.ToLower().Trim().Contains(Find)
                    || x.CategoryName.ToLower().Trim().Contains(Find)
                    && x.Status == status);
            }

            return listProductDetail;
        }

        public async Task<ServiceResults<Laptop_Detail>> CreateLaptopDetail(CreateLaptopViewModel create)
        {
            var result = new ServiceResults<Laptop_Detail>();

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
                var addedLaptopDetail = await _LapTopDetailRepositoty.AddOneAsync(cv);
                result.IsSuccess = true;
                result.Data = addedLaptopDetail;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Create Fail";
            }

            return result;
        }
        public async Task<ServiceResults<Laptop_Detail>> UpdateLaptopDetail(string ID,UpdateLaptopDetailViewModel update)
        {
            var result = new ServiceResults<Laptop_Detail>();

            try
            {
                var laptopDetail = await _LapTopDetailRepositoty.GetByIdAsync(ID);

                if (laptopDetail == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Laptop Detail not found";
                    return result;
                }

                laptopDetail.COGS = update.COGS;
                laptopDetail.Price = update.Price;
                laptopDetail.Quatity = update.Quatity;
                laptopDetail.IdSSD = update.IdSSD;
                laptopDetail.IdRam = update.IdRam;
                laptopDetail.IdBattery = update.IdBattery;
                laptopDetail.IdCam = update.IdCam;
                laptopDetail.IdLap = update.IdLap;
                laptopDetail.IdMain = update.IdMain;
                laptopDetail.IdScren = update.IdScreen;
                laptopDetail.IdVga = update.IdVga;
                laptopDetail.Weight = update.Weight;
                laptopDetail.leght = update.leght;
                laptopDetail.Hight = update.Hight;
                laptopDetail.Status = update.Status;

                await _LapTopDetailRepositoty.UpdateOneAsync(laptopDetail);

                result.IsSuccess = true;
                result.Data = laptopDetail;
            }
            catch (Exception)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Update Fail";
            }

            return result;
        }
    }
}
