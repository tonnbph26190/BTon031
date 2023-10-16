namespace API.ViewModel.OrderMonitorDetail
{
    public class MonitorResponse
    {
        public string ID { get; set; }
        public int Quatity { get; set; }
        public string OrderID { get; set; }
        public string MonitorDetailID { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
