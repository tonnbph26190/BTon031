using API.ViewModel.LatopDetailViewModel;
using API.ViewModel.PcViewModel;
using DATA.Entity;

namespace API.IService
{
    public interface IPcDetailService
    {
        Task<IEnumerable<PcDto>> GetAll();
        Task<bool> IsUpdateRequestValid(IPcDetailViewModel update);
        Task<PcDetail> CheckPcDetailExistence(IPcDetailViewModel update);
    }
}
