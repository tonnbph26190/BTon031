using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.MonitorViewModel
{
    public interface IMonitorDetail
    {
        [Required]
        [StringLength(50)]
        public string ResolutionID { get; set; }
        [Required]
        [StringLength(50)]
        public string PanelID { get; set; }
        [Required]
        [StringLength(50)]
        public string MonitorID { get; set; }
    }
}
