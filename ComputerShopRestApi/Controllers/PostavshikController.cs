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
    public class PostavshikController : ControllerBase
    {
        private readonly IPostavshikLogic _logic;
        public PostavshikController(IPostavshikLogic logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public PostavshikViewModel Mail(string mail, string password)
        {
            var list = _logic.Read(new PostavshikBindingModel
            {
                Mail = mail,
                Password = password
            });
            return (list != null && list.Count > 0) ? list[0] : null;
        }
        [HttpPost]
        public void Register(PostavshikBindingModel model) =>
        _logic.CreateOrUpdate(model);
        [HttpPost]
        public void UpdateData(PostavshikBindingModel model) =>
        _logic.CreateOrUpdate(model);
    }
}
