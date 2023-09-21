using API.IService;
using API.ViewModel.LatopDetailViewModel;
using DATA.Entity;
using Data.IRepositories;

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

            if (Ram.Status == 0 || SSD.Status == 0 || Battery.Status == 0 || Cam.Status == 0 || Lap.Status == 0 || Main.Status == 0 || Screen.Status == 0 || VGA.Status == 0)
            {
                return true;
            }

            return false;
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
    }
}
