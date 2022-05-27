using ComputerShopPostavhikApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ComputerShopContracts.BindingModels;
using ComputerShopContracts.ViewModels;

namespace ComputerShopPostavhikApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Postavshik);
        }

        [HttpPost]
        public void Privacy(string mail, string password, string login)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(mail))
            {
                APIPostavshik.PostRequest("api/postavshik/updatedata", new PostavshikBindingModel
                {
                    Id = Program.Postavshik.Id,
                    Mail = mail,
                    Login = login,
                    Password = password
                });
                Program.Postavshik.Mail = mail;
                Program.Postavshik.Login = login;
                Program.Postavshik.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string mail, string password)
        {
            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(password))
            {
                Program.Postavshik = APIPostavshik.GetRequest<PostavshikViewModel>($"api/postavshik/mail?mail={mail}&password={password}");
                if (Program.Postavshik == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string mail, string password, string login)
        {
            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(login))
            {
                APIPostavshik.PostRequest("api/postavshik/register", new PostavshikBindingModel
                {
                    Login = login,
                    Mail = mail,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и название деканата");
        }
        [HttpGet]
        public IActionResult Complect()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIPostavshik.GetRequest<List<ComplectViewModel>>($"api/main/getcomplectlist?postavshikid={Program.Postavshik.Id}"));
        }
        [HttpGet]
        public IActionResult Sborka()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return 
            View(APIPostavshik.GetRequest<List<SborkaViewModel>>($"/api/main/getsborkalist?postavshikid={Program.Postavshik.Id}"));
        }


        [HttpGet]
        public IActionResult CreateComplect()
        {
            return View();
        }

        [HttpPost]
        public void CreateComplect(string complectname, int price)
        {
            if (!string.IsNullOrEmpty(complectname) && !string.IsNullOrEmpty(Convert.ToString(price)))
            {
                APIPostavshik.PostRequest("api/main/createcomplect", new ComplectBindingModel
                {
                    ComplectName = complectname,
                    PostavshikId = Convert.ToInt32(Program.Postavshik.Id),
                    Price = price
                });
                Response.Redirect("Complect");
            }
        }

        [HttpGet]
        public IActionResult CreateSborka()
        {
            ViewBag.Complects =  APIPostavshik.GetRequest<List<ComplectViewModel>>("api/main/getfullcomplectlist");
            return View();
        }
        [HttpPost]
        public void CreateSborka(string sborkaname, int complect, decimal sum, List <int> complectsId)
        {
            List<ComplectViewModel> complects = new List<ComplectViewModel>();
            foreach (var complectId in complectsId)
            {
                complects.Add(APIPostavshik.GetRequest<ComplectViewModel>($"api/main/getcomplect?complectId={complectId}"));
            }
            if (sum == 0 || sum == 0)
            {
                return;
            }
            //прописать запрос
            APIPostavshik.PostRequest("api/main/createsborka", new SborkaBindingModel
            {
                SborkaName = sborkaname,
                PostavshikId = Convert.ToInt32(Program.Postavshik.Id),
                SborkaComplect = complects.ToDictionary(x => x.Id, x => x.ComplectName),
                Sum = sum,
            }); 
            Response.Redirect("Index");
        }

        [HttpPost]
        public decimal Calc (decimal count, int complect)
        {
            ComplectViewModel prod = APIPostavshik.GetRequest<ComplectViewModel>($"api/main/getcomplect?complectId={complect}");
            return count + prod.Price;
        }

        [HttpGet]
        public IActionResult Zakupka()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIPostavshik.GetRequest<List<ZakupkaViewModel>>($"/api/main/getzakupkalist?postavshikid={Program.Postavshik.Id}"));
        }

        [HttpGet]
        public IActionResult CreateZakupka()
        {
            ViewBag.Complects = APIPostavshik.GetRequest<List<ComplectViewModel>>("api/main/getfullcomplectlist");
            return View();
        }

        [HttpPost]
        public void CreateZakupka(string zakupkaname, DateTime datebuy, int complect)
        {
            if (!string.IsNullOrEmpty(zakupkaname) && !string.IsNullOrEmpty(Convert.ToString(datebuy)) && !string.IsNullOrEmpty(Convert.ToString(complect)))
            {
                APIPostavshik.PostRequest("api/main/createzakupka", new ZakupkaBindingModel
                {
                    ZakupkaName = zakupkaname,
                    PostavshikId = Convert.ToInt32(Program.Postavshik.Id),
                    DateBuy = datebuy,
                    ComplectId = complect
                });
                Response.Redirect("Complect");
            }
        }

        [HttpGet]
        public IActionResult PolTechnic()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIPostavshik.GetRequest<List<PolTechnicViewModel>>($"/api/main/getpoltechniclist"));
        }

        [HttpGet]
        public IActionResult CreatePolTechnic()
        {
            ViewBag.Complects = APIPostavshik.GetRequest<List<ComplectViewModel>>("api/main/getfullcomplectlist");
            return View();
        }

        [HttpPost]
        public void CreatePolTechnic(string poltechnicname, DateTime datepos, int complect, List<int> complectsId)
        {
            List<ComplectViewModel> complects = new List<ComplectViewModel>();
            foreach (var complectId in complectsId)
            {
                complects.Add(APIPostavshik.GetRequest<ComplectViewModel>($"api/main/getcomplect?complectId={complectId}"));
            }
            //прописать запрос
            APIPostavshik.PostRequest("api/main/createpoltechnic", new PolTechnicBindingModel
            {
                PolTechnicName = poltechnicname,
                ComplectPolTechnic = complects.ToDictionary(x => x.Id, x => x.ComplectName),
                DatePos = datepos
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Zaiavka()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIPostavshik.GetRequest<List<ZaiavkaViewModel>>($"/api/main/getzaiavkalist"));
        }

        [HttpGet]
        public IActionResult CreateZaiavka()
        {
            ViewBag.Sborkas = APIPostavshik.GetRequest<List<SborkaViewModel>>("api/main/getfullsborkalist");
            return View();
        }

        [HttpPost]
        public void CreateZaiavka(string zaiavkaname, int sborka, List<int> sborkasId)
        {
            List<SborkaViewModel> sborkas = new List<SborkaViewModel>();
            foreach (var sborkaId in sborkasId)
            {
                sborkas.Add(APIPostavshik.GetRequest<SborkaViewModel>($"api/main/getsborka?sborkaId={sborkaId}"));
            }
            //прописать запрос
            APIPostavshik.PostRequest("api/main/createzaiavka", new ZaiavkaBindingModel
            {
                ZaiavkaName = zaiavkaname,
                SborkaZaiavka = sborkas.ToDictionary(x => x.Id, x => x.SborkaName),
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Postavka()
        {
            if (Program.Postavshik == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIPostavshik.GetRequest<List<PostavkaViewModel>>($"/api/main/getpostavkalist"));
        }

        [HttpGet]
        public IActionResult CreatePostavka()
        {
            ViewBag.Zakupkas = APIPostavshik.GetRequest<List<ZakupkaViewModel>>("api/main/getfullzakupkalist");
            return View();
        }

        [HttpPost]
        public void CreatePostavka(string postavkaname, DateTime postavkacreate, int zakupka)
        {
            if (!string.IsNullOrEmpty(postavkaname) && !string.IsNullOrEmpty(Convert.ToString(postavkacreate)) && !string.IsNullOrEmpty(Convert.ToString(zakupka)))
            {
                APIPostavshik.PostRequest("api/main/createpostavka", new PostavkaBindingModel
                {
                    PostavkaName = postavkaname,
                    PostavkaCreate = postavkacreate,
                    ZakupkaId = zakupka
                });
                Response.Redirect("Complect");
            }
        }
    }
}
