using API.ServiceResult;
using API.ViewModel.OrderDetail;
using API.ViewModel.PcViewModel;

namespace API.IService
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetAll();
        Task<ServiceResults<OrderDetailResponse>> Create(CreateOrderDetail create);
        Task<ServiceResults<OrderDetailResponse>> Update(string ID, UpdateOrderDetail update);
        Task<bool> IsUpdateRequestValid(IOrderDetail obj);
    }
}
