using EShopOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EShopOnline.Data;

namespace EShopOnline.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CheckOutModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CheckoutViewModel CheckoutData { get; set; }

        public decimal CartTotal { get; set; }
        public IList<BasketItem> BasketItems { get; set; }

        public void OnGet() {
            int customerId = 1; // Hardcoded for now
            BasketItems = _context.BasketItems
                .Include(b => b.Product)
                .Where(b => b.CustomerID == customerId)
                .ToList();
            CartTotal = BasketItems.Sum(b => b.Product.Price * b.Quantity);

            CheckoutData = new CheckoutViewModel
            {
                DeliveryAddress = "",
                PostalCode = "",
                City = "",
                Country = ""
            };


        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var order = new Order
            {
                CustomerID = 1, // Hardcoded for now
                OrderDate = DateTime.Now,
                ExpectedDeliveryDate = DateTime.Now.AddDays(7),
                DeliveryAddress = CheckoutData.DeliveryAddress,
                PostalCode = CheckoutData.PostalCode,
                City = CheckoutData.City,
                Country = CheckoutData.Country,
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            var basketItems = _context.BasketItems.Where(b => b.CustomerID == 1);
            _context.BasketItems.RemoveRange(basketItems);
            _context.SaveChanges();

            return RedirectToPage("OrderConfirmation", new { orderId = order.OrderID });

        }




    }
}
