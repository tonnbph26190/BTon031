using API.IService;
using API.ViewModel.PcViewModel;
using DATA.Entity;
using Data.IRepositories;
using API.ViewModel.LatopDetailViewModel;
using System.Linq;
using API.Extensions;
using API.ServiceResult;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc;

namespace API.Service
{
    public class PcDetailService : IPcDetailService
    {
        private IAllRepositories<PcDetail> _PcDetailRepository;
        private IAllRepositories<SSD> _SSDRepository;
        private IAllRepositories<VGA> _VGARepository;
        private IAllRepositories<Ram> _RamRepository;
        private IAllRepositories<Main> _MainRepository;
        private IAllRepositories<PC> _PcRepository;
        private IAllRepositories<Power> _PowerRepository;
        private IAllRepositories<Case> _CaseRepository;
        private IAllRepositories<Custom> _CustomRepository;
        private IAllRepositories<Producer> _ProducerRepository;
        private IAllRepositories<Category> _CategoryRepository;
        private IAllRepositories<Cooling> _CoolingRepository;
        private IMapper _Mapper;
        public PcDetailService(IAllRepositories<PcDetail> PcDetailRepository, IAllRepositories<SSD> SSDRepository, IAllRepositories<VGA> VGARepository, IAllRepositories<Ram> RamRepository, IAllRepositories<Main> MainRepository, IAllRepositories<PC> PcRepository, IAllRepositories<Power> PowerRepository, IAllRepositories<Case> CaseRepository, IAllRepositories<Custom> CustomRepository, IAllRepositories<Producer> ProducerRepository, IAllRepositories<Category> CategoryRepository, IAllRepositories<Cooling> CoolingRepository,IMapper mapper)
        {
            _PcDetailRepository = PcDetailRepository;
            _MainRepository = MainRepository;
            _CaseRepository = CaseRepository;
            _CategoryRepository = CategoryRepository;
            _ProducerRepository = ProducerRepository;
            _PcRepository = PcRepository;
            _PowerRepository = PowerRepository;
            _RamRepository = RamRepository;
            _VGARepository = VGARepository;
            _SSDRepository = SSDRepository;
            _CustomRepository = CustomRepository;
            _CoolingRepository = CoolingRepository;
            _Mapper = mapper;
        }

        /// <summary>
        /// Lấy toàn bộ dự liệu PcDetail
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PcDto>> GetAll()
        {
            List<PcDto> PcDetails = new List<PcDto>();

            PcDetails =
                (
                from a in await _PcDetailRepository.GetAllAsync()
                join b in await _MainRepository.GetAllAsync() on a.MainID equals b.ID
                join c in await _CaseRepository.GetAllAsync() on a.CaseID equals c.ID
                join d in await _PowerRepository.GetAllAsync() on a.PowerID equals d.ID
                join e in await _RamRepository.GetAllAsync() on a.RamID equals e.ID
                join f in await _VGARepository.GetAllAsync() on a.VgaID equals f.ID
                join j in await _SSDRepository.GetAllAsync() on a.SSDId equals j.ID
                join h in await _CustomRepository.GetAllAsync() on a.CustomID equals h.ID
                join i in await _CoolingRepository.GetAllAsync() on a.CoolingID equals i.ID
                join k in await _PcRepository.GetAllAsync() on a.PcID equals k.ID
                join l in await _ProducerRepository.GetAllAsync() on k.ProducerId equals l.ID
                join m in await _CategoryRepository.GetAllAsync() on k.CatId equals m.ID
                select new PcDto
                {
                    ID = a.ID,
                    Seri = a.Seri,
                    COGS = (b.COGS ?? 0) + (c.COGS ?? 0) + (d.COGS ?? 0) + (e.COGS ?? 0) + (f.COGS ?? 0) + (e.COGS ?? 0) + (f.COGS ?? 0) + (j.COGS ?? 0) + (h.COGS ?? 0) + (i.COGS ?? 0),
                    Price = (b.Price ?? 0) + (c.Price ?? 0) + (d.Price ?? 0) + (e.Price ?? 0) + (f.Price ?? 0) + (e.Price ?? 0) + (f.Price ?? 0) + (j.Price ?? 0) + (h.Price ?? 0) + (i.Price ?? 0),
                    Quatity = a.Quatity,
                    SSDName = j.Name,
                    SSDValue = j.Parameter,
                    RamName = e.Name,
                    RamValue = e.Parameter,
                    VgaName = f.Name,
                    VGaValue = f.Parameter,
                    MainName = b.Name,
                    MainValue = b.Parameter,
                    PowerName = d.Name,
                    PowerValue = d.Value,
                    PCName = k.Name,
                    Status = a.Status,
                    CategoryName = m.Name,
                    ProducerName = l.Name,
                    CaseName = c.Name + " " + c.Value,
                    CoolingName = i.Name + " " + i.Value,
                    Name ="PC "+l.Name+" " +k.Name + " " + b.Name + " " + f.Name,
                }
                ).ToList();

            var filteredPcDetail = PcDetails.Where(x => x.Status == 1).ToList();

            return filteredPcDetail;
        }

        /// <summary>
        /// check điều kiện của repuest phải có số lượng >0 type= 2 status =1
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task<bool> IsUpdateRequestValid(IPcDetailViewModel update)
        {
            var Ram = await _RamRepository.GetByIdAsync(update.RamID);
            var SSD = await _SSDRepository.GetByIdAsync(update.SSDId);
            var Power = await _PowerRepository.GetByIdAsync(update?.PowerID);
            var PC = await _PcRepository.GetByIdAsync(update.PcID);
            var Main = await _MainRepository.GetByIdAsync(update?.MainID);
            var Vga = await _VGARepository.GetByIdAsync(update.VgaID);
            var cooling = await _CoolingRepository.GetByIdAsync(update.CoolingID);
            var Case = await _CaseRepository.GetByIdAsync(update.CaseID);
            var Custom = await _CustomRepository.GetByIdAsync(update.CustomID);

            if (Ram.Status == 0)
            {
                LogError("RAM is not available.");
                return false;
            }

            if (SSD.Status == 0)
            {
                LogError("SSD is not available.");
                return false;
            }

            if (Power.Status == 0)
            {
                LogError("Power is not available.");
                return false;
            }

            if (PC.Status == 0)
            {
                LogError("PC is not available.");
                return false;
            }

            if (Main.Status == 0)
            {
                LogError("Main is not available.");
                return false;
            }

            if (Vga.Status == 0)
            {
                LogError("VGA is not available.");
                return false;
            }

            if (cooling.Status == 0)
            {
                LogError("Cooling is not available.");
                return false;
            }

            if (Case.Status == 0)
            {
                LogError("Case is not available.");
                return false;
            }

            if (Custom.Status == 0)
            {
                LogError("Custom is not available.");
                return false;
            }

            if (Vga.Type != 2)
            {
                LogError("VGA type is invalid.");
                return false;
            }

            if (SSD.Type != 2)
            {
                LogError("SSD type is invalid.");
                return false;
            }

            if (Ram.Type != 2)
            {
                LogError("RAM type is invalid.");
                return false;
            }

            if (Main.Type != 2)
            {
                LogError("Main type is invalid.");
                return false;
            }

            if (Vga.Quatity <= 0)
            {
                LogError("VGA quantity is invalid.");
                return false;
            }

            if (SSD.Quatity <= 0)
            {
                LogError("SSD quantity is invalid.");
                return false;
            }

            if (Ram.Quatity <= 0)
            {
                LogError("RAM quantity is invalid.");
                return false;
            }

            if (Main.Quatity <= 0)
            {
                LogError("Main quantity is invalid.");
                return false;
            }

            if (Case.Quatity <= 0)
            {
                LogError("Case quantity is invalid.");
                return false;
            }

            if (cooling.Quatity <= 0)
            {
                LogError("Cooling quantity is invalid.");
                return false;
            }

            if (Power.Quatity <= 0)
            {
                LogError("Power quantity is invalid.");
                return false;
            }

            if (Custom.Quatity <= 0)
            {
                LogError("Custom quantity is invalid.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// viết log báo lỗi
        /// </summary>
        /// <param name="errorMessage"></param>
        private void LogError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
        public async Task<PcDetail> CheckPcDetailExistence(IPcDetailViewModel update)
        {
           
            var data = await _PcDetailRepository.GetAllAsync();
            var ValidData=data.Where(x=>x.Status==1).ToList();
            var objExist = ValidData.FirstOrDefault(x => x.RamID == update.RamID
                        && x.SSDId == update.SSDId
                        && x.PcID == update.PcID
                        && x.MainID == update.MainID
                        && x.VgaID == update.VgaID
                        && x.CoolingID == update.CoolingID
                        && x.CaseID == update.CaseID
                        && x.CustomID == update.CustomID);
            return objExist;
        }

        /// <summary>
        /// Lọc Pc detail theo giá, tên, trang thái
        /// </summary>
        /// <param name="search"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PcDto>> GetFilteredProductDetails(string? search, decimal? from, decimal? to, int? status)
        {
            var listProductDetail = await GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                var find = search.Trim().ToLower();
                listProductDetail = listProductDetail.Where(x => x.Name.ToLower().Contains(find)
                                    || x.ProducerName.ToLower().Trim().Contains(find)
                                    || x.CategoryName.Contains(find))
                                    .ToList();
            }

            if (from.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Price >= from).ToList();
            }

            if (to.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Price <= to).ToList();
            }

            if (status.HasValue)
            {
                listProductDetail = listProductDetail.Where(x => x.Status == status).ToList();
            }

            return listProductDetail;
        }
     
        /// <summary>
        /// THêm mới Pc Detail
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public async Task<ServiceResults<PcDetailResponse>> CreatePcDetail(CreatePcDetail create)
        {
            var result = new ServiceResults<PcDetailResponse>();

            var ram = await _RamRepository.GetByIdAsync(create.RamID);
            var SSD = await _SSDRepository.GetByIdAsync(create.SSDId);
            var Power = await _PowerRepository.GetByIdAsync(create?.PowerID);
            var PC = await _PcRepository.GetByIdAsync(create.PcID);
            var Main = await _MainRepository.GetByIdAsync(create?.MainID);
            var vga = await _VGARepository.GetByIdAsync(create.VgaID);
            var cooling = await _CoolingRepository.GetByIdAsync(create.CoolingID);
            var Case = await _CaseRepository.GetByIdAsync(create.CaseID);
            var Custom = await _CustomRepository.GetByIdAsync(create.CustomID);

            // Check số lượng product có hợp lệ không
            if (create.Quatity >= ram.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds RAM's available quantity",
                };
            }

            if (create.Quatity > SSD.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds SSD's available quantity",
                };
            }

            if (create.Quatity > Power.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds Power's available quantity",
                };
            }

            if (create.Quatity > Main.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds Main's available quantity",
                };
            }

            if (create.Quatity > vga.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds VGA's available quantity",
                };
            }

            if (create.Quatity > cooling.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds Cooling's available quantity",
                };
            }

            if (create.Quatity > Case.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds Case's available quantity",
                };
            }

            if (create.Quatity > Custom.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Create Fail: Quantity exceeds Custom's available quantity",
                };
            }

            try
            {
                var data = await _PcDetailRepository.GetAllAsync();
                var id = "DTPC" + Helper.GenerateRandomString(5);
                var seri = Helper.GenerateRandomString(8);
                PcDetail existId=new PcDetail();
                do
                {
                    id = "DTPC" + Helper.GenerateRandomString(5);
                    existId = await _PcDetailRepository.GetByIdAsync(id);
                } while (existId != null);

                var pc = new PcDetail()
                {
                    ID = id,
                    Seri = seri,
                    Quatity = create.Quatity,
                    RamID = create.RamID,
                    SSDId = create.SSDId,
                    PowerID = create.PowerID,
                    PcID = create.PcID,
                    MainID = create.MainID,
                    VgaID = create.VgaID,
                    CoolingID = create.CoolingID,
                    CaseID = create.CaseID,
                    CustomID = create.CustomID,
                    Status = 1,
                };

                var addedPcDetail = await _PcDetailRepository.AddOneAsync(pc);
                var response = _Mapper.Map<PcDetailResponse>(addedPcDetail);

                await _RamRepository.UpdateQuantity(ram,ram.Quatity-create.Quatity??0);
                await _SSDRepository.UpdateQuantity(SSD,SSD.Quatity-create.Quatity??0);
                await _PowerRepository.UpdateQuantity(Power, Power.Quatity-create.Quatity ??0);
                await _MainRepository.UpdateQuantity(Main, Main.Quatity - create.Quatity ??0);
                await _VGARepository.UpdateQuantity(vga, vga.Quatity - create.Quatity ??0);
                await _CaseRepository.UpdateQuantity(Case, Case.Quatity - create.Quatity ??0);
                await _CoolingRepository.UpdateQuantity(cooling,cooling.Quatity - create.Quatity ??0);
                await _CustomRepository.UpdateQuantity(Custom, Custom.Quatity - create.Quatity ??0);

                result.IsSuccess = true;
                result.Data = response;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Create Fail because exception:{e}";
            }

            return result;
        }
        public async Task<ServiceResults<PcDetailResponse>> UpdatePcDetail(string ID, UpdatePcDetail update)
        {
            var result = await _PcDetailRepository.GetByIdAsync(ID);

            if (result == null)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "PcDetail not found",
                };
            }

            var previousSsdID = result.SSDId;
            var previousPowerID = result.PowerID;
            var previousMainID = result.MainID;
            var previousVgaID = result.VgaID;
            var previousCoolingID = result.CoolingID;
            var previousCaseID = result.CaseID;
            var previousCustomID = result.CustomID;
            var previousRam = result.RamID;
            var previousQuatity=result.Quatity;

            var newRam = await _RamRepository.GetByIdAsync(update.RamID);
            var newSSD = await _SSDRepository.GetByIdAsync(update.SSDId);
            var newPower = await _PowerRepository.GetByIdAsync(update.PowerID);
            var newMain = await _MainRepository.GetByIdAsync(update.MainID);
            var newVGACard = await _VGARepository.GetByIdAsync(update.VgaID);
            var newCooling = await _CoolingRepository.GetByIdAsync(update.CoolingID);
            var newCase = await _CaseRepository.GetByIdAsync(update.CaseID);
            var newCustom = await _CustomRepository.GetByIdAsync(update.CustomID);

            result.Status = update.Status;

            bool hasChanged = false;

            if (update.Quatity > newRam.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds RAM quantity",
                };
            }

            if (update.Quatity > newSSD.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds SSD quantity",    
                };
            }

            if (update.Quatity > newPower.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds Power quantity",
                };
            }

            if (update.Quatity > newMain.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds Main quantity",
                };
            }

            if (update.Quatity > newVGACard.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds VGA Card quantity",
                };
            }

            if (update.Quatity > newCooling.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds Cooling quantity",
                };
            }

            if (update.Quatity > newCase.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds Case quantity",
                };
            }

            if (update.Quatity > newCustom.Quatity)
            {
                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Update Fail: Quantity exceeds Custom quantity",
                };
            }


            if (result.Quatity != update.Quatity)
            {
                int quantityDifference = update.Quatity - result.Quatity;
                result.Quatity = update.Quatity;
                hasChanged = true;

                // Subtract or add the difference to the corresponding inventory items
                if (quantityDifference > 0)
                {
                    newRam.Quatity -= quantityDifference;
                    newSSD.Quatity -= quantityDifference;
                    newPower.Quatity -= quantityDifference;
                    newMain.Quatity -= quantityDifference;
                    newVGACard.Quatity -= quantityDifference;
                    newCooling.Quatity -= quantityDifference;
                    newCase.Quatity -= quantityDifference;
                    newCustom.Quatity -= quantityDifference;
                }
                else if (quantityDifference < 0)
                { 
                    newRam.Quatity += Math.Abs(quantityDifference);
                    newSSD.Quatity += Math.Abs(quantityDifference);
                    newPower.Quatity += Math.Abs(quantityDifference);
                    newMain.Quatity += Math.Abs(quantityDifference);
                    newVGACard.Quatity += Math.Abs(quantityDifference);
                    newCooling.Quatity += Math.Abs(quantityDifference);
                    newCase.Quatity += Math.Abs(quantityDifference);
                    newCustom.Quatity += Math.Abs(quantityDifference);
                }
             
                await _RamRepository.UpdateOneAsync(newRam);
                await _SSDRepository.UpdateOneAsync(newSSD);
                await _PowerRepository.UpdateOneAsync(newPower);
                await _MainRepository.UpdateOneAsync(newMain);
                await _VGARepository.UpdateOneAsync(newVGACard);
                await _CoolingRepository.UpdateOneAsync(newCooling);
                await _CaseRepository.UpdateOneAsync(newCase);
                await _CustomRepository.UpdateOneAsync(newCustom);
            }

            if (result.RamID != update.RamID)
            {
                await _RamRepository.UpdateQuantity(newRam,newRam.Quatity -update.Quatity ??0);

                var PreviousRam = await _RamRepository.GetByIdAsync(previousRam);
                await _RamRepository.UpdateQuantity(PreviousRam,PreviousRam.Quatity+previousQuatity??0);

                result.RamID = update.RamID;
                hasChanged = true;
            }

            if (result.SSDId != update.SSDId)
            {
                await _SSDRepository.UpdateQuantity(newSSD, newSSD.Quatity - update.Quatity ?? 0);

                var previousSSD = await _SSDRepository.GetByIdAsync(previousSsdID);
                await _SSDRepository.UpdateQuantity(previousSSD, previousSSD.Quatity + previousQuatity ?? 0);

                result.SSDId = update.SSDId;
                hasChanged = true;
            }

            if (result.PowerID != update.PowerID)
            {
               
                await _PowerRepository.UpdateQuantity(newPower, newPower.Quatity - update.Quatity ?? 0);

                var previousPower = await _PowerRepository.GetByIdAsync(previousPowerID);
                await _PowerRepository.UpdateQuantity(previousPower, previousPower.Quatity + previousQuatity ?? 0);

                result.PowerID = update.PowerID;
                hasChanged = true;
            }

            if (result.MainID != update.MainID)
            {  
                await _MainRepository.UpdateQuantity(newMain, newMain.Quatity - update.Quatity ?? 0);

                var previousMain = await _MainRepository.GetByIdAsync(previousMainID);
                await _MainRepository.UpdateQuantity(previousMain, previousMain.Quatity + previousQuatity ?? 0);

                result.MainID = update.MainID;
                hasChanged = true;
            }

            if (result.VgaID != update.VgaID)
            {
                await _VGARepository.UpdateQuantity(newVGACard, newVGACard.Quatity - update.Quatity ?? 0);

                var previousVGACard = await _VGARepository.GetByIdAsync(previousVgaID);
                await _VGARepository.UpdateQuantity(previousVGACard, previousVGACard.Quatity + previousQuatity ?? 0);

                result.VgaID = update.VgaID;
                hasChanged = true;
            }

            if (result.CoolingID != update.CoolingID)
            {              
                await _CoolingRepository.UpdateQuantity(newCooling, newCooling.Quatity - update.Quatity ?? 0);

                var previousCooling = await _CoolingRepository.GetByIdAsync(previousCoolingID);
                await _CoolingRepository.UpdateQuantity(previousCooling, previousCooling.Quatity + previousQuatity ?? 0);

                result.CoolingID = update.CoolingID;
                hasChanged = true;
            }

            if (result.CaseID != update.CaseID)
            {              
                await _CaseRepository.UpdateQuantity(newCase, newCase.Quatity - update.Quatity ?? 0);

                var previousCase = await _CaseRepository.GetByIdAsync(previousCaseID);
                await _CaseRepository.UpdateQuantity(previousCase, previousCase.Quatity + previousQuatity ?? 0);

                result.CaseID = update.CaseID;
                hasChanged = true;
            }

            if (result.CustomID != update.CustomID)
            {
                await _CustomRepository.UpdateQuantity(newCustom, newCustom.Quatity - update.Quatity ?? 0);

                var previousCustom = await _CustomRepository.GetByIdAsync(previousCustomID);
                await _CustomRepository.UpdateQuantity(previousCustom, previousCustom.Quatity + previousQuatity ?? 0);

                result.CustomID = update.CustomID;
                hasChanged = true;
            }   

            if (hasChanged)
            {

                try
                {
                    var updateResult = await _PcDetailRepository.UpdateOneAsync(result);
                    var response = _Mapper.Map<PcDetailResponse>(updateResult);

                    return new ServiceResults<PcDetailResponse>()
                    {
                        IsSuccess = true,
                        Data = response,
                    };
                }
                catch (Exception e)
                {
                    return new ServiceResults<PcDetailResponse>()
                    {
                        IsSuccess = false,
                        ErrorMessage = $"Update Fail because exception: {e}",
                    };
                }
            }
            else
            {
                var originalResponse = _Mapper.Map<PcDetailResponse>(result);

                return new ServiceResults<PcDetailResponse>()
                {
                    IsSuccess = true,
                    Data = originalResponse,
                };
            }
        }


    }
}
