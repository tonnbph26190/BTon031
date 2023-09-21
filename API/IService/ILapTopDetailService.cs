using API.ViewModel.LatopDetailViewModel;
using DATA.Entity;

namespace API.IService
{
    public interface ILapTopDetailService
    {
        Task<IEnumerable<LaptopDetailDto>> GetAllLaptopDetail();
        Task<bool> CheckComponentsStatus(ILaptopDetailViewModel monitorViewModel);
        Task<Laptop_Detail> FindExistingDetailAsync(ILaptopDetailViewModel model);
    }
}
