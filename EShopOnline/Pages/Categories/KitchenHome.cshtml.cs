using Microsoft.AspNetCore.Mvc;
using EShopOnline.Data;
using EShopOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopOnline.Pages.Categories
{
    public class KitchenHomeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public KitchenHomeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Where(p => p.CategoryID == 3)
                .ToListAsync();
        }

    }
}
