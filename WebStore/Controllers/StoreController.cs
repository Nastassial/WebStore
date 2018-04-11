using System.Threading.Tasks;
using System.Web.Mvc;
using DAL.Models;
using BLL.Services.Implementations;

namespace WebStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        
        public async Task<ActionResult> Index()
        {
            return View(await _storeService.GetAll());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Name,Address,WorkingTime")] Store store)
        {
            if (ModelState.IsValid)
            {
                await _storeService.Create(store);
                return RedirectToAction("Index");
            }

            return View(store);
        }

        public async Task<ActionResult> GetProducts(int id)
        {
            var store = await _storeService.GetProducts(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }
    }
}
