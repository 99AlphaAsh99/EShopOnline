using EShopOnline.Data;
using EShopOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopOnline.Pages
{
    public class CartModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BasketItem> BasketItems { get; set; }

        public async Task OnGetAsync()
        {
            int customerId = 2;

            BasketItems = await _context.BasketItems
                .Include(b => b.Product)
                .Where(b => b.CustomerID == customerId)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync(int basketId)
        {
            var item = await _context.BasketItems
                .Include(b => b.Product)
                .FirstOrDefaultAsync(b => b.BasketID == basketId);


            if (item != null)
            {
                item.Product.StockQuantity += item.Quantity;
                _context.BasketItems.Remove(item);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Item removed from cart.";
            }
            return RedirectToPage();
        }








    }







}

