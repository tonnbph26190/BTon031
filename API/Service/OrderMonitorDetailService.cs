using API.IService;
using API.ServiceResult;
using API.ViewModel.OrderDetail;
using API.ViewModel.OrderMonitorDetail;
using AutoMapper;
using DATA.Entity;
using Data.IRepositories;
using API.ViewModel.OrderDetailLaptopDetailViewModel;
using API.Extensions;

namespace API.Service
{
    public class OrderMonitorDetailService : IOrderMonitorDetail
    {
        IMonitorDetailService _MonitorDetailService;
        IAllRepositories<OrderMonitorDetail> _OrderDetailRepo;
        IAllRepositories<OrderMonitor> _OrderRepo;
        IAllRepositories<MonitorDetail> _MonitorDetailRepo;
        IMapper _Mapper;
        public OrderMonitorDetailService(IMonitorDetailService MonitorDetailService, IAllRepositories<OrderMonitorDetail> OrderDetailRepo, IAllRepositories<OrderMonitor> OrderRepo, IAllRepositories<MonitorDetail> MonitorDetailRepo, IMapper Mapper)
        {
            _MonitorDetailRepo = MonitorDetailRepo;
            _OrderDetailRepo = OrderDetailRepo;
            _Mapper = Mapper;
            _OrderRepo = OrderRepo;
            _MonitorDetailService = MonitorDetailService;
        }

        public async Task<bool> IsRequestValid(CreateOrderMonitorDetail obj)
        {
            var monitorDetail = await _MonitorDetailRepo.GetByIdAsync(obj.MonitorDetailID);

            if (monitorDetail.Quatity <= 0)
            {
                // Ghi log lỗi khi Quantity < 0
                Console.WriteLine("Error: Quantity is less than 0.");
                return false;
            }
            else if (monitorDetail.Status == 0)
            {
                // Ghi log lỗi khi Status == 0
                Console.WriteLine("Error: Status is equal to 0.");
                return false;
            }

            return true;
        }
        public async Task<ServiceResults<MonitorResponse>> Create(CreateOrderMonitorDetail create)
        {
            if (!await IsRequestValid(create))
            {
                return new ServiceResults<MonitorResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "The product does not have enough quantity available or is not working properly.",
                };
            }

            var id = "ODLTD" + Helper.GenerateRandomString(5);
            var data = await _OrderDetailRepo.GetAllAsync();
            var productDetail = await _MonitorDetailRepo.GetByIdAsync(create.MonitorDetailID);

            if (productDetail.Quatity < create.Quatity || productDetail.Quatity < 0)
            {
                return new ServiceResults<MonitorResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Not enough quantity",
                };
            }

            OrderMonitorDetail ExistOrderDetail = new OrderMonitorDetail();

            do
            {
                id = "ODLTD" + Helper.GenerateRandomString(5);
                ExistOrderDetail = await _OrderDetailRepo.GetByIdAsync(id);
            } while (ExistOrderDetail != null);

            OrderMonitorDetail orderDetail = new OrderMonitorDetail()
            {
                ID = id,
                Quatity = create.Quatity,
                CreateDate = DateTime.Now,
                Status = 1,
                OrderID = create.OrderID,
                MonitorDetailID = create.MonitorDetailID,
                Price = productDetail.Price * create.Quatity,
            };

            try
            {

                var result = await _OrderDetailRepo.AddOneAsync(orderDetail);
                var response = _Mapper.Map<MonitorResponse>(result);

                productDetail.Quatity = productDetail.Quatity - create.Quatity;
                await _MonitorDetailRepo.UpdateOneAsync(productDetail);

                return new ServiceResults<MonitorResponse>()
                {
                    IsSuccess = true,
                    Data = response,
                };
            }
            catch (Exception)
            {
                return new ServiceResults<MonitorResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail",
                };
            }
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAll()
        {
            List<OrderDetailDto> orderDetailDtos = new List<OrderDetailDto>();
            orderDetailDtos =
                (
                from a in await _OrderDetailRepo.GetAllAsync()
                join b in await _MonitorDetailService.GetAll() on a.MonitorDetailID equals b.ID
                join c in await _OrderRepo.GetAllAsync() on a.OrderID equals c.ID
                select new OrderDetailDto
                {
                    ID = a.ID,
                    Price = a.Price * a.Quatity,
                    OrderID = c.ID,
                    CreateDate = a.CreateDate,
                    Status = a.Status,
                    ProductName = b.Name,
                    Quatity = a.Quatity,
                    ProductID= b.ID,
                }
                ).ToList();
            return orderDetailDtos;
        }
    }
}
