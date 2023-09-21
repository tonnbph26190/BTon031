using API.IService;
using API.ViewModel.PcViewModel;
using DATA.Entity;
using Data.IRepositories;
using API.ViewModel.LatopDetailViewModel;
using System.Linq;

namespace API.Service
{
    public class PcDetailService : IPcDetailService
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
        public PcDetailService(IAllRepositories<PcDetail> PcDetailRepository, IAllRepositories<SSD> SSDRepository, IAllRepositories<VGA> VGARepository, IAllRepositories<Ram> RamRepository, IAllRepositories<Main> MainRepository, IAllRepositories<PC> PcRepository, IAllRepositories<Power> PowerRepository, IAllRepositories<Case> CaseRepository, IAllRepositories<Custom> CustomRepository, IAllRepositories<Producer> ProducerRepository, IAllRepositories<Category> CategoryRepository, IAllRepositories<Cooling> CoolingRepository)
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
        }
        public async Task<IEnumerable<PcDto>> GetAll()
        {
            List<PcDto> PcDetails = new List<PcDto>();
            PcDetails =
                (
                from a in await _PcDetailRepository.GetAllAsync()
                join b in await _MainRepository.GetAllAsync() on a.MainID equals b.ID
                join c in await _CaseRepository.GetAllAsync() on a.CaseID equals c.ID
                join d in await _PowerRepository.GetAllAsync() on a.PowerID equals d.ID
                join e in await _RamRepository.GetAllAsync() on a.RamID equals e.ID
                join f in await _VGARepository.GetAllAsync() on a.VgaID equals f.ID
                join j in await _SSDRepository.GetAllAsync() on a.SSDId equals j.ID
                join h in await _CustomRepository.GetAllAsync() on a.CustomID equals h.ID
                join i in await _CoolingRepository.GetAllAsync() on a.CoolingID equals i.ID
                join k in await _PcRepository.GetAllAsync() on a.PcID equals k.ID
                join l in await _ProducerRepository.GetAllAsync() on k.ProducerId equals l.ID
                join m in await _CategoryRepository.GetAllAsync() on k.CatId equals m.ID
                select new PcDto
                {
                    ID = a.ID,
                    Seri = a.Seri,
                    COGS = a.COGS,
                    Price = a.Price,
                    Quatity = a.Quatity,
                    SSDName = j.Name,
                    SSDValue = j.Parameter,
                    RamName = e.Name,
                    RamValue = e.Parameter,
                    VgaName = f.Name,
                    VGaValue = f.Parameter,
                    MainName = b.Name,
                    MainValue = b.Parameter,
                    PowerName = d.Name,
                    PowerValue = d.Value,
                    PCName = k.Name,
                    Status = a.Status,
                    CategoryName = m.Name,
                    ProducerName = l.Name,
                    CaseName = c.Name + " " + c.Value,
                    CoolingName = i.Name + " " + i.Value,
                    Name ="PC "+l.Name+" " +k.Name + " " + b.Name + " " + f.Name,
                }
                ).ToList();
            var filteredPcDetail = PcDetails.Where(x => x.Status == 1).ToList();
            return filteredPcDetail;
        }
        public async Task<bool> IsUpdateRequestValid(IPcDetailViewModel update)
        {
            var Ram = await _RamRepository.GetByIdAsync(update.RamID);
            var SSD = await _SSDRepository.GetByIdAsync(update.SSDId);
            var Power = await _PowerRepository.GetByIdAsync(update?.PowerID);
            var PC = await _PcRepository.GetByIdAsync(update.PcID);
            var Main = await _MainRepository.GetByIdAsync(update?.MainID);
            var Vga = await _VGARepository.GetByIdAsync(update.VgaID);
            var cooling = await _CoolingRepository.GetByIdAsync(update.CoolingID);
            var Case = await _CaseRepository.GetByIdAsync(update.CaseID);
            var Custom = await _CustomRepository.GetByIdAsync(update.CustomID);
            var ex = await _PcDetailRepository.GetAllAsync();

            if (Ram.Status == 0 || SSD.Status == 0 || Power.Status == 0 || PC.Status == 0 || Main.Status == 0 || Vga.Status == 0 || cooling.Status == 0 || Case.Status == 0 || Custom.Status == 0)
            {
                return true;
            }

            return false;
        }
        public async Task<PcDetail> CheckPcDetailExistence(IPcDetailViewModel update)
        {
           
            var data = await _PcDetailRepository.GetAllAsync();
            var ValidData=data.Where(x=>x.Status==1).ToList();
            var objExist = ValidData.FirstOrDefault(x => x.RamID == update.RamID
                        && x.SSDId == update.SSDId
                        && x.PcID == update.PcID
                        && x.MainID == update.MainID
                        && x.VgaID == update.VgaID
                        && x.CoolingID == update.CoolingID
                        && x.CaseID == update.CaseID
                        && x.CustomID == update.CustomID);
            return objExist;
        }
    }
}
