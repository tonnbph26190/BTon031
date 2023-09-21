using API.IService;
using API.ViewModel.MonitorViewModel;
using DATA.Entity;
using Data.IRepositories;

namespace API.Service
{
    public class MonitorDetailService : IMonitorDetailService
    {
        private IAllRepositories<Producer> _ProducerRepository;
        private IAllRepositories<Category> _CategoryRepository;
        private IAllRepositories<DATA.Entity.Monitor> _MonitorRepository;
        private IAllRepositories<MonitorDetail> _MonitorDetailRepository;
        private IAllRepositories<Panel> _PanelRepository;
        private IAllRepositories<Resolution> _ResolutionRepository;
        public MonitorDetailService(IAllRepositories<Producer> producerRepository, IAllRepositories<Category> categoryRepository, IAllRepositories<DATA.Entity.Monitor> monitorRepository, IAllRepositories<MonitorDetail> monitorDetailRepository)
        {
            _ProducerRepository = producerRepository;
            _CategoryRepository = categoryRepository;
            _MonitorRepository = monitorRepository;
            _MonitorDetailRepository = monitorDetailRepository;
        }
        public async Task<IEnumerable<MonitorDetailDto>> GetAll()
        {
            List<MonitorDetailDto> monitorDetailDtos = new List<MonitorDetailDto>();
            monitorDetailDtos = 
                (
                from a in await _MonitorDetailRepository.GetAllAsync()
                join b in await _PanelRepository.GetAllAsync() on a.PanelID equals b.ID
                join c in await _ResolutionRepository.GetAllAsync() on a.ResolutionID equals c.ID
                join d in await _MonitorRepository.GetAllAsync() on a.MonitorID equals d.ID
                join e in await _ProducerRepository.GetAllAsync() on d.ProducerId equals e.ID
                join f in await _CategoryRepository.GetAllAsync() on d.CatId equals f.ID
                select new MonitorDetailDto
                {
                    ID = a.ID,
                    Seri=a.Seri,
                    COGS=a.COGS,
                    Price=a.Price,
                    Status=a.Status,
                    Speaker=a.Speaker,
                    Display=a.Display,
                    Brightness=a.Brightness,
                    Description=a.Description,
                    Inch=a.Inch,
                    Rate=a.Rate,
                    ResponseTime=a.ResponseTime,
                    MonitorName=d.Name,
                    PanelName=b.Name,
                    ResolutionValue=b.Value,
                    Name=e.Name+" "+d.Name+" "+b.Value+" "+a.Inch+" "+a.Rate,
                    ProducreName=e.Name,
                    CatgoryName=f.Name,
                }
                
                ).ToList();
            var filterd=monitorDetailDtos.Where(x=>x.Status==1).ToList();
            return filterd;

        }
    }
}
