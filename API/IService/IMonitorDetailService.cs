using API.ViewModel.MonitorViewModel;
using API.ViewModel.PcViewModel;

namespace API.IService
{
    public interface IMonitorDetailService
    {
        Task<IEnumerable<MonitorDetailDto>> GetAll();
    }
}
