using API.ViewModel.MonitorViewModel;
using API.ViewModel.OrderDetail;
using API.ViewModel.PcViewModel;
using AutoMapper;
using DATA.Entity;

namespace API.AutoMapper
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<MonitorDetail,MonitorDetailResponse>().ReverseMap();
            CreateMap<PcDetail, PcDetailResponse>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailResponse>().ReverseMap();
        }
    }
}
