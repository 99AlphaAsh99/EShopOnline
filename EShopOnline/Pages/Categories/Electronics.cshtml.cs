using EShopOnline.Data;
using EShopOnline.Models;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopOnline.Pages.Categories
{
    public class ElectronicsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ElectronicsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }
       
        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Where(p => p.CategoryID == 2)
                .ToListAsync();

        }


        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductID == productId);

            if (product == null || product.StockQuantity <= 0)
            {
                TempData["Message"] = "This product is out of stock.";
                return RedirectToPage("/Index");
            }



            int customerId = 2; // Assume the customer is always customer with ID 2

            var existingItem = await _context.BasketItems
                .FirstOrDefaultAsync(b => b.ProductID == productId && b.CustomerID == customerId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var basketItem = new BasketItem
                {
                    ProductID = productId,
                    CustomerID = customerId,
                    Quantity = 1,
                    //DataAdded = DateTime.Now
                };
                _context.BasketItems.Add(basketItem);

            }

            product.StockQuantity--;

            await _context.SaveChangesAsync();

            TempData["Message"] = "Product added to cart successfully.";
            return RedirectToPage("/Cart");








        }



    }
}
