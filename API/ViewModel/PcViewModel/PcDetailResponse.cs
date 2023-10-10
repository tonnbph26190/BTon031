    using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.ViewModel.PcViewModel
{
    public class PcDetailResponse
    {
      
        public string ID { get; set; }
      
        public string Seri { get; set; }
        
        public int Status { get; set; }
        
        public int Quatity { get; set; }
       
        public string SSDId { get; set; }
       
        public string RamID { get; set; }
       
        public string VgaID { get; set; }
       
        public string MainID { get; set; }
       
        public string CustomID { get; set; }
       
        public string CoolingID { get; set; }
       
        public string CaseID { get; set; }
        
        public string PcID { get; set; }
      
        public string PowerID { get; set; }
    }
}
