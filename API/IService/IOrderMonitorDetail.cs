using API.ServiceResult;
using API.ViewModel.OrderDetail;
using API.ViewModel.OrderDetailLaptopDetailViewModel;
using API.ViewModel.OrderMonitorDetail;

namespace API.IService
{
    public interface IOrderMonitorDetail
    {
        Task<IEnumerable<OrderDetailDto>> GetAll();
        Task<ServiceResults<MonitorResponse>> Create(CreateOrderMonitorDetail create);
    }
}
