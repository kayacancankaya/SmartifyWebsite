using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MySqlConnector;
using SmartifyWebsite.Data;
using SmartifyWebsite.Models;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using System.Linq.Expressions;

namespace SmartifyWebsite.Controllers
{
	public class HomeController : Controller
	{
        private readonly ILogger<HomeController> _logger;
		private readonly SmartifyDbContext _context;
		private readonly IStringLocalizer<HomeController> _stringLocalizer;
		private readonly IWebHostEnvironment _env;
		public HomeController(ILogger<HomeController> logger,
                                IStringLocalizer<HomeController> stringLocalizer,
								SmartifyDbContext context,
								IWebHostEnvironment env)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
			_context = context;
			_env = env;
		}

        public IActionResult Index()
        {
			ViewData["CurrentCulture"] = CultureInfo.CurrentCulture.Name;
			return View();
		}
		//services
		public IActionResult Services()
        {

			return View("Services");
        }
		public IActionResult ServicesPartial()
        {
			return PartialView("ServicesPartial");
        }
		public IActionResult Category(int categoryID)
        {
			switch (categoryID)
			{
				case 1:
					return View("WebApplicationDevelopment");
				case 2:
					return View("MobileApplicationDevelopment");
				case 3:
					return View("DesktopApplicationDevelopment");
				case 4:
					return View("WebDesign");
				case 5:
					return View("ECommerceSolutions");
				case 6:
					return View("BIandReporting");
				default:
					return View("WebApplicationDevelopment");
			}
		}
		public IActionResult Products()
		{
			try
			{
				var currentCulture = CultureInfo.CurrentCulture.Name;
				ViewData["CurrentCulture"] = currentCulture;
				ViewData["TotalProducts"] = _context.Product.Count();
				ViewData["TotalDisplayed"] = 9;

				return View("Products");
			}
			catch (Exception)
			{
				return View("NotFound");
			}
		}
		[HttpPost]
		public IActionResult ProductsDisplaySection(int categoryId, int totalItemDisplayPerPage, int pageNumber,string searchString,decimal minValue,decimal maxValue)
		{
			try
			{
				var currentCulture = CultureInfo.CurrentCulture.Name;
				ViewData["CurrentCulture"] = currentCulture;
				IEnumerable<Product> products = Enumerable.Empty<Product>(); 
				if(!string.IsNullOrEmpty(searchString))
				{
					string prop = string.Empty;
					switch (currentCulture)
					{
						case "en-US":
							prop = "Name_EN";
							break;
						case "es-ES":
							prop = "Name_ES";
							break;
						case "tr-TR":
							prop = "Name_TR";
							break;
						default:
							prop = "Name_EN";
							break;
					}
					var parameter = Expression.Parameter(typeof(Product), "p");
					var property = Expression.Property(parameter, prop); 
					var lambda = Expression.Lambda<Func<Product, bool>>(
						Expression.Call(property, "Contains", null, Expression.Constant(searchString)),
						parameter
					);
					products = _context.Product.Where(lambda).Include(c => c.Category);
				}

				if (categoryId == 0)
				{
					if(!products.Any() && string.IsNullOrEmpty(searchString))
					{
						products = _context.Product.Where(p => p.ActualPrice <= maxValue && p.ActualPrice >= minValue).OrderByDescending(c => c.CreatedAt).Skip((pageNumber - 1) * totalItemDisplayPerPage).Include(c => c.Category).Take(totalItemDisplayPerPage);
						ViewData["TotalProductsFiltered"] = _context.Product.Count();
					}
					else if(!string.IsNullOrEmpty(searchString))
					{
						products = products.Where(p => p.ActualPrice <= maxValue && p.ActualPrice >= minValue).OrderByDescending(c => c.CreatedAt).Skip(pageNumber - 1).Take(totalItemDisplayPerPage);
						ViewData["TotalProductsFiltered"] = products.Where(p => p.ActualPrice <= maxValue && p.ActualPrice >= minValue).Count();
					}
				}
				else
				{
					if(!products.Any() && string.IsNullOrEmpty(searchString))
					{
						products = _context.Product.Where(c => c.CategoryID == categoryId && c.ActualPrice <= maxValue && c.ActualPrice >= minValue).OrderByDescending(c => c.CreatedAt).Include(c => c.Category).Skip((pageNumber - 1) * totalItemDisplayPerPage).Take(totalItemDisplayPerPage);
						ViewData["TotalProductsFiltered"] = _context.Product.Where(c => c.CategoryID == categoryId && c.ActualPrice <= maxValue && c.ActualPrice >= minValue).Count();

					}
					else if (!string.IsNullOrEmpty(searchString))
					{
						products = products.Where(c => c.CategoryID == categoryId && c.ActualPrice <= maxValue && c.ActualPrice >= minValue).OrderByDescending(c => c.CreatedAt).Skip((pageNumber - 1) * totalItemDisplayPerPage).Take(totalItemDisplayPerPage);
						ViewData["TotalProductsFiltered"] = products.Where(c => c.CategoryID == categoryId && c.ActualPrice <= maxValue && c.ActualPrice >= minValue).Count();

					}
				}

				ViewData["TotalDisplayed"] = products.Count();
				ViewData["RootPath"] = _env.WebRootPath;
				return PartialView("ProductsDisplaySection", products);
			}
			catch (Exception ex)
			{
				string message = ex.Message.ToString();
				return BadRequest();
			}
		}
		public async Task<IActionResult> Product(string productCode)
		{
			try
			{
				var currentCulture = CultureInfo.CurrentCulture.Name;
				ViewData["CurrentCulture"] = currentCulture;
				if (string.IsNullOrEmpty(productCode))
					return BadRequest();
				if (productCode.Length > 6)
					productCode = productCode.Substring(0, 6);
				Product? product = await _context.Product.Where(p => p.ProductCode == productCode).Include(c => c.Category).FirstOrDefaultAsync();
				
				bool pricingListExists = false;
				if (product != null)
					pricingListExists =  _context.PricingList.Where(p => p.ProductCode == productCode).Any();
				
				ViewData["PricingListExists"] = pricingListExists;
				ViewData["RootPath"] = _env.WebRootPath;

				return View("Product", product);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				return View("NotFound");
			}
		}	
		public async Task<IActionResult> ProductRelated(string productCode,string related,int categoryID)
		{
			try
			{
				var currentCulture = CultureInfo.CurrentCulture.Name;
				ViewData["CurrentCulture"] = currentCulture;

				if (string.IsNullOrEmpty(productCode)) 
					return BadRequest();

				if (productCode.Length > 6)
					productCode = productCode.Substring(0, 6);

				List<int> relatedIDs = new();
				if(!string.IsNullOrEmpty(related))
				{
					relatedIDs = related.Split(',')
									.Where(x => int.TryParse(x, out _)) // Validar que son números
									.Select(int.Parse)
									.ToList();
				}

				List<Product> products = new();
				products = await _context.Product
									.Where(i => relatedIDs.Contains(i.Id))
									.Include(c => c.Category)
									.ToListAsync();
				//add same category
				if(products.Count < 5)
				{
					int productNumber = products.Count;
					int additionalProductNumber = 5 - productNumber;
					List<Product> additionalProducts = await _context.Product.Where(i=>i.CategoryID == categoryID 
																		&& i.ProductCode.Substring(0,6) != productCode.Substring(0,6))
																		.Take(additionalProductNumber).ToListAsync();
					foreach (var product in additionalProducts) 
						products.Add(product);
					
				}
				//add populars
				if(products.Count < 5)
				{
					int productNumber = products.Count;
					int additionalProductNumber = 5 - productNumber;
					List<Product> additionalProducts = await _context.Product.OrderByDescending(p=>p.Popularity).Take(additionalProductNumber).ToListAsync();
					foreach (var product in additionalProducts) 
						products.Add(product);
				}

				ViewData["RootPath"] = _env.WebRootPath;

				return PartialView("ProductRelated", products);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				List<Product> products = new List<Product>();
				return PartialView("ProductRelated", products);
			}
		}
		[HttpPost]
		public IActionResult ProductFilterByCategory(int id,int totalItemDisplayPerPage,int pageNumber)
        {
			try
			{
				var currentCulture = CultureInfo.CurrentCulture.Name;
				ViewData["CurrentCulture"] = currentCulture;
				IEnumerable<Product> products;
				if (id == 0)
					products = _context.Product.OrderByDescending(c => c.CreatedAt).Skip(pageNumber - 1).Include(c => c.Category).Take(10);
				else
					products = _context.Product.Where(c => c.CategoryID == id).OrderByDescending(c => c.CreatedAt).Include(c => c.Category).Skip(pageNumber - 1).Take(10);

				return PartialView("ProductFilterByCategory",products);
			}
			catch (Exception ex)
			{
				string message = ex.Message.ToString();
				return BadRequest();
			}
        }
		[HttpPost]
		public async Task<IActionResult> PreviousNextProducts(int id)
        {
			try
			{
				if (id <= 0)
					return BadRequest("Invalid product ID.");

				var currentCulture = CultureInfo.CurrentCulture.Name;
				ViewData["CurrentCulture"] = currentCulture;
				ViewData["CurrentID"] = id;

				var products = new List<Product>();

				var previousProduct = await _context.Product
													.Where(i => i.Id == id - 1)
													.FirstOrDefaultAsync();
				if (previousProduct != null)
					products.Add(previousProduct);
				var nextProduct = await _context.Product
													.Where(i => i.Id == id + 1)
													.FirstOrDefaultAsync();
				if (nextProduct != null)
					products.Add(nextProduct);
				return PartialView("PreviousNextProducts",products);
			}
			catch (Exception ex)
			{
				string message = ex.Message.ToString();
				return BadRequest();
			}
        }
        public IActionResult WebApplicationDevelopment()
        {

			return View();
        }
        public IActionResult MobileApplicationDevelopment()
        {

			return View();
        }
        public IActionResult DesktopApplicationDevelopment()
        {

			return View();
        }
        public IActionResult WebDesign()
        {

			return View();
        }
        public IActionResult ECommerceSolutions()
        {

			return View();
        }
        public IActionResult BIandReporting()
        {

			return View();
        }
		//eof single services
        //projects
		public IActionResult Projects()
		{

			return View();
		}
		//eof projects
		//account and shop
		public IActionResult Shop()
        {

			return View();
        }
        public IActionResult Cart()
        {

			return View();
        }
        public IActionResult Checkout()
        {

			return View();
        }
        public IActionResult Account()
        {

			return View();
		}
		public IActionResult AccountOrders()
		{

			return View();
		}
		public IActionResult AccountDownloads()
        {

			return View();
		}
        public IActionResult AccountDetails()
        {

			return View();
		}
        public IActionResult Logout()
        {

			return RedirectToAction("Login");
		}
        public IActionResult Login()
        {

			return View();
		}
		//eof account and shop

        //others
		public IActionResult About()
		{

			return View();
		}
		public IActionResult AboutSmartifyPartial()
		{
			return PartialView("AboutSmartifyPartial");
		}
		public IActionResult WorkFlow()
		{
			return PartialView("WorkFlow");
		}
		public IActionResult Team()
		{
			return PartialView("Team");
		}
		public IActionResult YourProject()
		{
			return PartialView("YourProject");
		}
		public IActionResult ContactUsCallUs()
		{
			return PartialView("ContactUsCallUs");
		}
		public IActionResult ContactUsForm()
		{
			return PartialView("ContactUsForm");
		}
		public IActionResult ContactUs()
		{

			return View();
		}

		public IActionResult Blog()
		{

			return View();
		}
		//eof others
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
