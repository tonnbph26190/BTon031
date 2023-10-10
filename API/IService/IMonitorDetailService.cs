using API.ServiceResult;
using API.ViewModel.MonitorViewModel;
using API.ViewModel.PcViewModel;
using DATA.Entity;

namespace API.IService
{
    public interface IMonitorDetailService
    {
        Task<IEnumerable<MonitorDetailDto>> GetAll();
        Task<bool> ValidateMonitorPanelResolutionAsync(IMonitorDetail create);
        Task<MonitorDetail> IsDuplicate(IMonitorDetail monitor);
        Task<IEnumerable<MonitorDetailDto>> SearchProductDetails(string? search, decimal? from, decimal? to, int? status);
        Task<ServiceResults<MonitorDetailResponse>> CreateMonitorDetail(CreateMonitorViewModel create);
        Task<ServiceResults<MonitorDetailResponse>> UpdateMonitorDetail(string ID,UpdateMonitorViewModel update);
    }
}
