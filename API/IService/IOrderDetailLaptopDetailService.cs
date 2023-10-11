using API.ServiceResult;
using API.ViewModel.OrderDetail;
using API.ViewModel.OrderDetailLaptopDetailViewModel;

namespace API.IService
{
    public interface IOrderDetailLaptopDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetAll();
        Task<ServiceResults<OrderDetailLaptopResponse>> Create(CreateOrdDetailLaptopDetail create);
    }
}
