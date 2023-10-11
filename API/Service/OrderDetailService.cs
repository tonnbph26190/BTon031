using API.Extensions;
using API.IService;
using API.ServiceResult;
using API.ViewModel.MonitorViewModel;
using API.ViewModel.OrderDetail;
using API.ViewModel.PcViewModel;
using AutoMapper;
using Data.IRepositories;
using DATA.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        IPcDetailService _pcDetailService;
        IAllRepositories<OrderDetail> _OrderDetailRepo;
        IAllRepositories<Order> _OrderRepo;
        IAllRepositories<PcDetail> _PcDetailRepo;
        IMapper _Mapper;
        public OrderDetailService(IPcDetailService pcDetailService, IAllRepositories<OrderDetail> OrderDetailRepo, IAllRepositories<Order> OrderRepo,IMapper mapper, IAllRepositories<PcDetail> pcDetailRepo)
        {
            _pcDetailService = pcDetailService;
            _OrderDetailRepo = OrderDetailRepo;
            _OrderRepo = OrderRepo;
            _Mapper = mapper;
            _PcDetailRepo = pcDetailRepo;
        }

        public async Task<ServiceResults<OrderDetailResponse>> Create(CreateOrderDetail create)
        {
            if (!await IsUpdateRequestValid(create))
            {
                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Pc detail does not exist or invalid",
                };
            }
            var id = "ORDL" + Helper.GenerateRandomString(5);
            var data = await _OrderDetailRepo.GetAllAsync();
            var ProductDetail = await _PcDetailRepo.GetByIdAsync(create.PcDetailID);

            var PcDtoData = await _pcDetailService.GetAll();
            var ProductPrice=PcDtoData.FirstOrDefault(c=>c.ID==create.PcDetailID).Price;

            if (ProductDetail.Quatity<create.Quatity||ProductDetail.Quatity<0)
            {
                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Not enough quantity",
                };
            }

            OrderDetail ExistOrderDetail =new OrderDetail();

            do
            {
                id = "ORDL" + Helper.GenerateRandomString(5);
                ExistOrderDetail = await _OrderDetailRepo.GetByIdAsync(id);
            } while (ExistOrderDetail!=null);
            OrderDetail orderDetail= new OrderDetail()
            { 
                ID= id,
                Quatity=create.Quatity,
                CreateDate=DateTime.Now,
                Status=1,
                OrderID=create.OrderID,
                PcDetailID=create.PcDetailID,
                Price=ProductPrice * create.Quatity,
            };
            try
            {          
                ProductDetail.Quatity = ProductDetail.Quatity-create.Quatity;
                await _PcDetailRepo.UpdateOneAsync(ProductDetail);
                var result = await _OrderDetailRepo.AddOneAsync(orderDetail);
                var response = _Mapper.Map<OrderDetailResponse>(result);

                

                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = true,
                    Data = response,
                };
            }
            catch (Exception)
            {
                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail",
                };
            }
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAll()
        {
            List<OrderDetailDto> orderDetailDtos= new List<OrderDetailDto>();
            orderDetailDtos = 
                (
                from a in await _OrderDetailRepo.GetAllAsync()
                join b in await _pcDetailService.GetAll() on a.PcDetailID equals b.ID
                join c in await _OrderRepo.GetAllAsync() on a.OrderID equals c.ID
                select new OrderDetailDto
                {
                    ID= a.ID,
                    Price= b.Price*a.Quatity,
                    OrderID=c.ID,
                    CreateDate=a.CreateDate,
                    Status=a.Status,
                    ProductName=b.Name,
                    Quatity=a.Quatity,
                    ProductID=b.ID
                }
                ).ToList();
            return orderDetailDtos;
        }

        public async Task<bool> IsUpdateRequestValid(IOrderDetail obj)
        {    

         var PcDetail = await _PcDetailRepo.GetByIdAsync(obj.PcDetailID);
            if (PcDetail.Quatity<0||PcDetail.Status==0)
            {
                return false;
            }
            return true;
        }

        public async Task<ServiceResults<OrderDetailResponse>> Update(string ID, UpdateOrderDetail update)
        {
            if (!await IsUpdateRequestValid(update))
            {
                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "The product does not have enough quantity available or is not working properly.",
                };
            }
            var result = await _OrderDetailRepo.GetByIdAsync(ID);
            var ProductDetail = await _PcDetailRepo.GetByIdAsync(update.PcDetailID);
            if (result == null||ProductDetail.Quatity<update.Quatity)
            {
                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Order detail not found",
                };
            }

            var oldQuantity = result.Quatity;
            var oldPcDetail = await _PcDetailRepo.GetByIdAsync(result.PcDetailID);

            result.Quatity = update.Quatity;
            result.OrderID = update.OrderID;
            result.Status = update.Status;
            result.PcDetailID = update.PcDetailID;

            try
            {
                if (result.PcDetailID != update.PcDetailID)
                {
                    oldPcDetail.Quatity += oldQuantity;
                    await _PcDetailRepo.UpdateOneAsync(oldPcDetail);

                    var newPcDetail = await _PcDetailRepo.GetByIdAsync(update.PcDetailID);
                    newPcDetail.Quatity -= update.Quatity;
                    await _PcDetailRepo.UpdateOneAsync(newPcDetail);
                }
                else
                {
                    var quantityDifference = update.Quatity - oldQuantity;
                    if (quantityDifference > 0)
                    {
                        oldPcDetail.Quatity -= quantityDifference;
                    }
                    else if (quantityDifference < 0)
                    {
                        oldPcDetail.Quatity += Math.Abs(quantityDifference);
                    }
                    await _PcDetailRepo.UpdateOneAsync(oldPcDetail);
                }

                var updateResult = await _OrderDetailRepo.UpdateOneAsync(result);
                var response = _Mapper.Map<OrderDetailResponse>(updateResult);

                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = true,
                    Data = response,
                };
            }
            catch (Exception)
            {
                return new ServiceResults<OrderDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update failed",
                };
            }
        }
    }
}
