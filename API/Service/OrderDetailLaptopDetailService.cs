using API.IService;
using API.ViewModel.OrderDetail;
using AutoMapper;
using DATA.Entity;
using Data.IRepositories;
using API.ServiceResult;
using API.ViewModel.OrderDetailLaptopDetailViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using API.Extensions;

namespace API.Service
{
    public class OrderDetailLaptopDetailService : IOrderDetailLaptopDetailService
    {
        ILapTopDetailService _LapTopDetailService;
        IAllRepositories<OrderDetailLaptopDetail> _OrderDetailRepo;
        IAllRepositories<OrderLaptop> _OrderRepo;
        IAllRepositories<Laptop_Detail> _LapTopDetailRepo;
        IMapper _Mapper;
        public OrderDetailLaptopDetailService(ILapTopDetailService LapTopDetailService, IAllRepositories<OrderDetailLaptopDetail> OrderDetailRepo, IAllRepositories<OrderLaptop> OrderRepo, IMapper mapper, IAllRepositories<Laptop_Detail> LapTopDetailRepo)
        {
            _LapTopDetailRepo = LapTopDetailRepo;
            _OrderDetailRepo = OrderDetailRepo;
            _LapTopDetailService = LapTopDetailService;
            _OrderRepo = OrderRepo;
            _Mapper = mapper;
        }

        public async Task<ServiceResults<OrderDetailLaptopResponse>> Create(CreateOrdDetailLaptopDetail create)
        {
            if (!await IsRequestValid(create))
            {
                return new ServiceResults<OrderDetailLaptopResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "The product does not have enough quantity available or is not working properly.",
                };
            }
            var id = "ODLTD" + Helper.GenerateRandomString(5);
            var productDetail = await _LapTopDetailRepo.GetByIdAsync(create.LaptopDetailID);

            if (productDetail.Quatity < create.Quatity || productDetail.Quatity <= 0)
            {
                return new ServiceResults<OrderDetailLaptopResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Not enough quantity",
                };
            }

            OrderDetailLaptopDetail ExistOrderDetail = new OrderDetailLaptopDetail();

            do
            {
                id = "ODLTD" + Helper.GenerateRandomString(5);
                ExistOrderDetail = await _OrderDetailRepo.GetByIdAsync(id);
            } while (ExistOrderDetail != null);

            OrderDetailLaptopDetail orderDetail = new OrderDetailLaptopDetail()
            {
                ID = id,
                Quatity = create.Quatity,
                CreateDate = DateTime.Now,
                Status = 1,
                OrderLaptopID = create.OrderID,
                Laptop_DetailID = create.LaptopDetailID,
                Price = productDetail.Price * create.Quatity,
            };

            try
            {
              
                var result = await _OrderDetailRepo.AddOneAsync(orderDetail);
                var response = _Mapper.Map<OrderDetailLaptopResponse>(result);

                productDetail.Quatity = productDetail.Quatity - create.Quatity;
                await _LapTopDetailRepo.UpdateOneAsync(productDetail);

                return new ServiceResults<OrderDetailLaptopResponse>()
                {
                    IsSuccess = true,
                    Data = response,
                };
            }
            catch (Exception)
            {
                return new ServiceResults<OrderDetailLaptopResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail",
                };
            }
        }

        /// <summary>
        /// lấy tất cả hóa đơn của laptopDetail
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OrderDetailDto>> GetAll()
        {
            List<OrderDetailDto> orderDetailDtos = new List<OrderDetailDto>();
            orderDetailDtos =
                (
                from a in await _OrderDetailRepo.GetAllAsync()
                join b in await _LapTopDetailService.GetAllLaptopDetail() on a.Laptop_DetailID equals b.ID
                join c in await _OrderRepo.GetAllAsync() on a.OrderLaptopID equals c.ID
                select new OrderDetailDto
                {
                    ID = a.ID,
                    Price = b.Price * a.Quatity,
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

        /// <summary>
        /// Kiểm tra xem requet có hợp lệ chưa
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<bool> IsRequestValid(CreateOrdDetailLaptopDetail obj)
        {

            var laptop_Detail = await _LapTopDetailRepo.GetByIdAsync(obj.LaptopDetailID);
            if (laptop_Detail.Quatity < 0 || laptop_Detail.Status == 0)
            {
                return false;
            }
            return true;
        }

    }
}
