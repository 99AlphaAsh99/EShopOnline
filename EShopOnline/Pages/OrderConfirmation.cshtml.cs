using EShopOnline.Data;
using EShopOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShopOnline.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OrderConfirmationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public void OnGet(int orderId)
        {
            Order = _context.Orders
            .Include(o => o.OrderItems) 
            .ThenInclude(oi => oi.Product) 
            .FirstOrDefault(o => o.OrderID == orderId);


            if (Order != null)
            {
                // Calculate subtotal, shipping, tax, and total
                Subtotal = Order.OrderItems?.Sum(oi => oi.UnitPrice * oi.Quantity) ?? 0;
                Shipping = Subtotal > 0 ? 5.99m : 0;
                Tax = Subtotal * 0.08m;
                Total = Subtotal + Shipping + Tax;
            }

        }
    }
}
