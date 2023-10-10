using API.ServiceResult;
using API.ViewModel.LatopDetailViewModel;
using DATA.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.IService
{
    public interface ILapTopDetailService
    {
        Task<IEnumerable<LaptopDetailDto>> GetAllLaptopDetail();
        Task<bool> CheckComponentsStatus(ILaptopDetailViewModel monitorViewModel);
        Task<Laptop_Detail> FindExistingDetailAsync(ILaptopDetailViewModel model);
        Task<IEnumerable<LaptopDetailDto>> FilterProductDetails(string? search, decimal? from, decimal? to, int? status);
        Task<ServiceResults<Laptop_Detail>> CreateLaptopDetail(CreateLaptopViewModel create);
        Task<ServiceResults<Laptop_Detail>> UpdateLaptopDetail(string ID, UpdateLaptopDetailViewModel update);
    }
}
