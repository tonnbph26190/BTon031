using API.IService;
using API.ViewModel.MonitorViewModel;
using DATA.Entity;
using Data.IRepositories;
using API.Extensions;
using API.ServiceResult;
using AutoMapper;

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
        private IMapper _Mapper;
        public MonitorDetailService(IAllRepositories<Producer> producerRepository, IAllRepositories<Category> categoryRepository, IAllRepositories<DATA.Entity.Monitor> monitorRepository, IAllRepositories<MonitorDetail> monitorDetailRepository, IAllRepositories<Panel> PanelRepository, IAllRepositories<Resolution> ResolutionRepository, IMapper mapper)
        {
            _ProducerRepository = producerRepository;
            _CategoryRepository = categoryRepository;
            _MonitorRepository = monitorRepository;
            _MonitorDetailRepository = monitorDetailRepository;
            _PanelRepository = PanelRepository;
            _ResolutionRepository = ResolutionRepository;
            _Mapper= mapper;
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
                    Quatity=a.Quatity
                }
                
                ).ToList();
            var filterd=monitorDetailDtos.Where(x=>x.Status==1).ToList();
            return filterd;

        }

        public async Task<MonitorDetail> IsDuplicate(IMonitorDetail monitor)
        {
            var data=await _MonitorDetailRepository.GetAllAsync();    
            var ObjExist= data.FirstOrDefault(x=>x.MonitorID==monitor.MonitorID&&x.PanelID==monitor.PanelID&&x.ResolutionID==monitor.ResolutionID);
            return ObjExist == null ? null : ObjExist;
            
        }

        public async Task<bool> ValidateMonitorPanelResolutionAsync(IMonitorDetail create)
        {
            var monitor = await _MonitorRepository.GetByIdAsync(create.MonitorID);
            var panel = await _PanelRepository.GetByIdAsync(create.PanelID);
            var resolution = await _ResolutionRepository.GetByIdAsync(create.ResolutionID);

            if (monitor.Status == 0)
            {
                LogError("Invalid monitor status");
                return true;
            }

            if (panel.Status == 0)
            {
                LogError("Invalid panel status");
                return true;
            }

            if (resolution.Status == 0)
            {
                LogError("Invalid resolution status");
                return true;
            }

            return false;
        }

        private void LogError(string errorMessage)
        {
            // Thực hiện ghi log ở đây, ví dụ:
            Console.WriteLine($"Error: {errorMessage}");
        }
        public async Task<IEnumerable<MonitorDetailDto>> SearchProductDetails(string? search, decimal? from, decimal? to, int? status)
        {
            var listProductDetail = await GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                var find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Name.ToLower().Contains(find)
                    || x.ProducreName.ToLower().Trim().Contains(find)
                    || x.CatgoryName.Contains(find));
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
                var find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Price >= from
                    && x.Price <= to
                    && x.Name.ToLower().Contains(find));
            }

            if (from.HasValue && to.HasValue && !string.IsNullOrEmpty(search) && status.HasValue)
            {
                var find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Price >= from
                    && x.Price <= to
                    && x.Name.ToLower().Trim().Contains(find)
                    || x.ProducreName.ToLower().Trim().Contains(find)
                    || x.CatgoryName.ToLower().Trim().Contains(find)
                    && x.Status == status);
            }

            return listProductDetail;
        }
        public async Task<ServiceResults<MonitorDetailResponse>> CreateMonitorDetail(CreateMonitorViewModel create)
        {
            var id = "MNDT" + Helper.GenerateRandomString(5);
            var seri = Helper.GenerateRandomString(8);
            var data = await _MonitorDetailRepository.GetAllAsync();

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
                var result = await _MonitorDetailRepository.AddOneAsync(monitorDetail);
                var response = _Mapper.Map<MonitorDetailResponse>(result);  

                return new ServiceResults<MonitorDetailResponse>()
                {
                    IsSuccess = true,
                    Data = response,
                };
            }
            catch (Exception)
            {
                return new ServiceResults<MonitorDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail",
                };
            }
        }
        public async Task<ServiceResults<MonitorDetailResponse>> UpdateMonitorDetail(string ID,UpdateMonitorViewModel update)
        {
            var result = await _MonitorDetailRepository.GetByIdAsync(ID);

            if (result == null)
            {
                return new ServiceResults<MonitorDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Monitor Detail not found",
                };
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
                var updatedModel = await _MonitorDetailRepository.UpdateOneAsync(result);
                var response = _Mapper.Map<MonitorDetailResponse>(updatedModel);
                return new ServiceResults<MonitorDetailResponse>()
                {
                    IsSuccess = true,
                    Data = response,
                };
            }
            catch (Exception)
            {
                return new ServiceResults<MonitorDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail",
                };
            }
        }
    }
}
