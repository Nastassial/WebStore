using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL.Models;
using BLL.Services.Implementations;
using WebStore.Models;
using System.Text.RegularExpressions;

namespace WebStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly IStoreService _storeService;

        public ProductController(IProductService productService, IStoreService storeService)
        {
            _storeService = storeService;
            _productService = productService;
        }
        
        public async Task<ActionResult> Index()
        {
            return View(await _productService.GetAll());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Name,Description,StoreList")] ProductModel productModel)
        {
            var product = new Product()
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Stores = new List<Store>()
            };

            string[] stores = Regex.Split(productModel.StoreList, @",\s*");

            foreach (var item in stores)
            {
                product.Stores.Add(await _storeService.GetByName(item));
            }

            if (ModelState.IsValid)
            {
                await _productService.Create(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
