using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository_Layer.Entity;
using Service_Layer.Services;

namespace demo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            if (products == null)
            {
                products = new List<Product>();
            }

            ViewBag.TotalProducts = _productService.GetTotalProductCount();

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Furniture",
                "Clothing",
                "Books",
                "Sports",
                "Food & Beverages"
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                bool success = _productService.AddProduct(product);
                if (success)
                {
                    TempData["SuccessMessage"] = "Product created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Failed to add product. Check validation rules.");
            }

            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Furniture",
                "Clothing",
                "Books",
                "Sports",
                "Food & Beverages"
            });
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Furniture",
                "Clothing",
                "Books",
                "Sports",
                "Food & Beverages"
            }, product.Category);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                bool success = _productService.UpdateProduct(product);
                if (success)
                {
                    TempData["SuccessMessage"] = "Product updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Failed to update product.");
            }

            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Furniture",
                "Clothing",
                "Books",
                "Sports",
                "Food & Beverages"
            }, product.Category);

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool success = _productService.DeleteProduct(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Product deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete product.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
