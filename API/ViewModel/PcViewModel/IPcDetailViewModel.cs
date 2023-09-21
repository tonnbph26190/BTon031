using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.PcViewModel
{
    public interface IPcDetailViewModel
    {
        [Required]
        [StringLength(30)]
        public string SSDId { get; set; }
        [Required]
        [StringLength(30)]
        public string RamID { get; set; }
        [Required]
        [StringLength(30)]
        public string VgaID { get; set; }
        [Required]
        [StringLength(30)]
        public string MainID { get; set; }
        [Required]
        [StringLength(30)]
        public string CustomID { get; set; }
        [Required]
        [StringLength(30)]
        public string CoolingID { get; set; }
        [Required]
        [StringLength(30)]
        public string CaseID { get; set; }
        [Required]
        [StringLength(30)]
        public string PcID { get; set; }
        [Required]
        [StringLength(30)]
        public string PowerID { get; set; }
    }
}
