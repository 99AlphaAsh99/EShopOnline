using EShopOnline.Data;
using EShopOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopOnline.Pages.Categories
{
    public class ClothingModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ClothingModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }
       
        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Where(p => p.CategoryID == 1)
                .ToListAsync();
        }
    }
}
