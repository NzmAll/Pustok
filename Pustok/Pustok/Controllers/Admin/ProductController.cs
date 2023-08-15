using Microsoft.AspNetCore.Mvc;
using Pustok.Database.Models;
using Pustok.Database.Repositories;
using Pustok.ViewModels;

namespace Pustok.Controllers;

public class ProductController : Controller
{
    private readonly ProductRepository _productRepository;

    public ProductController()
    {
        _productRepository = new ProductRepository();
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _productRepository.GetAll();
            var productViewModels = products
            .Select(p => new ProductListItemViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Color = p.Color,
                Size = p.Size,
                Price = p.Price
            })
            .ToList();

        //var productViewModels = new List<ProductListItemViewModel>();

        //foreach (var product in products)
        //{
        //    productViewModels.Add(new ProductListItemViewModel
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Color = product.Color,
        //        Size = product.Size,
        //        Price = product.Price
        //    });
        //}

        var result = View("~/Views/Admin/Product/Index.cshtml", productViewModels);
        return result;
    }

    #region Add

    [HttpGet]
    public IActionResult Add()
    {
        return View("~/Views/Admin/Product/Add.cshtml");
    }

    [HttpPost]
    public IActionResult Add(ProductAddViewModel model)
    {
        var product = new Product(
            model.Name,
            model.Description,
            model.Color,
            model.Size,
            model.Price);

        _productRepository.Insert(product);

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null) return NotFound();

        var model = new ProductUpdateViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Color = product.Color,
            Size = product.Size,
            Price = product.Price
        };

        return View("~/Views/Admin/Product/Update.cshtml", model);
    }

    [HttpPost]
    public IActionResult Update(ProductUpdateViewModel model)
    {
        var product = _productRepository.GetById(model.Id);
        if (product == null) return NotFound();

        product.Name = model.Name;
        product.Description = model.Description;
        product.Color = model.Color;
        product.Price = model.Price;

        return RedirectToAction(nameof(Index));
    }

    #endregion

    //#region Delete

    //[HttpPost]
    //public IActionResult Delete(int id)
    //{
    //    var book = _productRepository.GetById(id);
    //    if (book == null) return NotFound();

    //    _productRepository.RemoveById(id);

    //    return RedirectToAction(nameof(Index));
    //}

    //#endregion
}