using ASM2.Models;
using ASM2.IServices;
using ASM2.Models;
using ASM2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NuGet.Protocol.Plugins;
using Newtonsoft.Json;

namespace ASM2.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService;
        IUserService _userService;
        private readonly IHttpContextAccessor _contxt;
        List<CartDetail> _LstCartDetail;
        private ICartDetailService _cartDetailService;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _productService = new ProductService();
            _userService = new UserService();
            _contxt = httpContext;
            _cartDetailService = new CartDetailService();
            _LstCartDetail = new List<CartDetail>();
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult ShowAll()
        //{
        //    List<Product> products = _productService.GetAllProducts();
        //    return View(products);
        //}

        public ActionResult ShowAll(string search)
        {
            List<Product> lst = new List<Product>();
            if(search == null)
            {
                lst = _productService.GetAllProducts();
            }
            else
            {
                lst = _productService.GetProductByName(search);
            }
            return View(lst);
        }
		public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (_productService.CreateProduct(product))
            {
                return RedirectToAction("ShowAll");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Details(Guid id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product prod, IFormFile imagefile)
        {
            if (_productService.UpdateProduct(prod))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }

        public IActionResult Delete(Guid id)
        {
            if (_productService.DeleteProduct(id))
            {


                return RedirectToAction("ShowAll");
            }
            else return BadRequest();

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {

            if (_userService.CreateUser(user))
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //ViewBag.error = "Username already exist! Use another username pls!";
                return BadRequest();
            }
        }

        public IActionResult Login(User user, string login)
        {
            string lg = "Log in failed! Please check username or password!";
            bool checktk = _userService.GetAllUsers().Select(c => c.Username).Contains(user.Username);
            bool checkmk = _userService.GetAllUsers().Select(c => c.Password).Contains(user.Password);
            if (!checkmk || !checktk)
            {
                _contxt.HttpContext.Session.SetString("login", lg);
                //return RedirectToAction("Login", "Home");
                return View();



            }
            else
            {
                lg = null;
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("Login");
        }



        //[HttpPost]
        public IActionResult AddCart(Guid id)
        {
            CartDetail cart = new CartDetail();
            cart.Id = Guid.NewGuid();
            cart.UserId = Guid.Parse("BD6F20DC-5DAA-4D1C-30BA-08DB396F0FCA");
            cart.IdSP = id;
            cart.Quantity = 1;

            //cart.Product = _productService.GetAllProducts().FirstOrDefault(c => c.Id == id);
            //if (_cartDetailService.CreateCartDetails(cart))
            //{
            List<CartDetail> lstCartDetails = SessionService.GetCartDetailFromSession(HttpContext.Session, "Cart");
            if (lstCartDetails.Count == 0)
            {
                lstCartDetails.Add(cart);
                SessionService.SetObjToSession(HttpContext.Session, "Cart", lstCartDetails);
            }
            else
            {
                if (lstCartDetails.Where(c => c.UserId == cart.UserId).Select(c => c.IdSP).Contains(cart.IdSP))
                {
                    cart.Quantity = 2;
                }
                else
                {
                    lstCartDetails.Add(cart);
                    SessionService.SetObjToSession(HttpContext.Session, "Cart", lstCartDetails);
                }
            }
            return RedirectToAction("ShowCart");

            //}
            //else
            //{
            //    return Content("Ko them dc");
            //}

        }

        public IActionResult ShowCart()
        {
            List<CartDetail> CartDT = SessionService.GetCartDetailFromSession(HttpContext.Session, "Cart");
            return View(CartDT);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}