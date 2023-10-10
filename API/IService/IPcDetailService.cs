using API.ServiceResult;
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
        Task<IEnumerable<PcDto>> GetFilteredProductDetails(string? search, decimal? from, decimal? to, int? status);
        Task<ServiceResults<PcDetailResponse>> CreatePcDetail(CreatePcDetail create);
        Task<ServiceResults<PcDetailResponse>> UpdatePcDetail(string ID, UpdatePcDetail update);
    }
}
