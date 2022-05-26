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
        public MainController(IComplectLogic complect, ISborkaLogic sborka, IZakupkaLogic zakupka)
        {
            _complect = complect;
            _sborka = sborka;
            _zakupka = zakupka;
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
        public List<SborkaViewModel> GetSborkaList(int postavshikId) => _sborka.Read(new SborkaBindingModel { PostavshikId = postavshikId });
        [HttpGet]
        public ComplectViewModel GetSborka(int sborkaId) => _complect.Read(new ComplectBindingModel { Id = sborkaId })?[0];
        [HttpPost]
        public void CreateSborka (SborkaBindingModel model) => _sborka.CreateOrUpdate(model);
    }
}
