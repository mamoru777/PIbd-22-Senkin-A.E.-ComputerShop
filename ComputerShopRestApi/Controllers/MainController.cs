using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.BuisnessLogicContracts;
using ComputerShopContracts.ViewModels;

namespace ComputerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly IComplectLogic _complect;
        private readonly ISborkaLogic _sborka;
        private readonly IZakupkaLogic _zakupka;
        private readonly IPolTechnicLogic _poltechnic;
        private readonly IZaiavkaLogic _zaiavka;
        private readonly IPostavkaLogic _postavka;
        public MainController(IComplectLogic complect, ISborkaLogic sborka, IZakupkaLogic zakupka, IPolTechnicLogic poltechniclogic, IZaiavkaLogic zaiavkaLogic, IPostavkaLogic postavkaLogic)
        {
            _complect = complect;
            _sborka = sborka;
            _zakupka = zakupka;
            _poltechnic = poltechniclogic;
            _zaiavka = zaiavkaLogic;
            _postavka = postavkaLogic;
        }
        [HttpGet]
        public List<ComplectViewModel> GetFullComplectList() => _complect.Read(null)?.ToList();
        [HttpGet]
        public List<ComplectViewModel> GetComplectList(int postavshikid) => _complect.Read(new ComplectBindingModel { PostavshikId = postavshikid });
        [HttpGet]
        public ComplectViewModel GetComplect(int complectId) => _complect.Read(new ComplectBindingModel { Id = complectId })?[0];
        [HttpPost]
        public void CreateComplect(ComplectBindingModel model) => _complect.CreateOrUpdate(model);
        [HttpGet]
        public List<SborkaViewModel> GetFullSborkaList() => _sborka.Read(null)?.ToList();
        [HttpGet]
        public List<SborkaViewModel> GetSborkaList(int postavshikId) => _sborka.Read(new SborkaBindingModel { PostavshikId = postavshikId });
        [HttpGet]
        public SborkaViewModel GetSborka(int sborkaId) => _sborka.Read(new SborkaBindingModel { Id = sborkaId })?[0];
        [HttpPost]
        public void CreateSborka (SborkaBindingModel model) => _sborka.CreateOrUpdate(model);
        [HttpGet]
        public List<ZakupkaViewModel> GetZakupkaList(int postavshikid) => _zakupka.Read(new ZakupkaBindingModel { PostavshikId = postavshikid });
        [HttpGet]
        public List<ZakupkaViewModel> GetFullZakupkaList() => _zakupka.Read(null)?.ToList();
        [HttpGet]
        public ZakupkaViewModel GetZakupka(int zakupkaId) => _zakupka.Read(new ZakupkaBindingModel { Id = zakupkaId })?[0];
        [HttpPost]
        public void CreateZakupka(ZakupkaBindingModel model) => _zakupka.CreateOrUpdate(model);

        [HttpPost]
        public void CreatePolTechnic(PolTechnicBindingModel model) => _poltechnic.CreateOrUpdate(model);

        [HttpGet]
        public List<PolTechnicViewModel> GetPolTechnicList() => _poltechnic.Read(null)?.ToList();

        [HttpPost]
        public void CreateZaiavka(ZaiavkaBindingModel model) => _zaiavka.CreateOrUpdate(model);

        [HttpGet]
        public List<ZaiavkaViewModel> GetZaiavkaList() => _zaiavka.Read(null)?.ToList();

        [HttpPost]
        public void CreatePostavka(PostavkaBindingModel model) => _postavka.CreateOrUpdate(model);

        [HttpGet]
        public List<PostavkaViewModel> GetPostavkaList() => _postavka.Read(null)?.ToList();
    }
}
