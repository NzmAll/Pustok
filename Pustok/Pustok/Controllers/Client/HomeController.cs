using Microsoft.AspNetCore.Mvc;
using Pustok.Database.Models;
using Pustok.Database.Repositories;
using Pustok.ViewModels;

namespace Pustok.Controllers.Client
{
    public class HomeController : Controller //controller
    {
        private readonly SlideBannerRepository _slideBannerRepository;
        private readonly ProductRepository _productRepository;

        public HomeController()
        {
            _slideBannerRepository = new SlideBannerRepository();
            _productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                SlideBanners = _slideBannerRepository
                    .GetAll()
                    .OrderBy(sb => sb.Order)
                    .ToList(),

                Products = _productRepository
                    .GetAll()
                    .OrderBy(p => p.Name)
                    .ToList()
            };

            return View("~/Views/Client/Home/Index.cshtml", model);
        }
    }
}