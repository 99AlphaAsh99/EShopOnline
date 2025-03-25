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

        public void OnGet() 
        {
            int customerId = 2; // Hardcoded for now
            BasketItems = _context.BasketItems
                .Include(b => b.Product)
                .Where(b => b.CustomerID == customerId)
                .ToList();
            CartTotal = BasketItems.Sum(b => b.Product.Price * b.Quantity);

            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == customerId);

            CheckoutData = new CheckoutViewModel
            {
                Name = customer != null ? $"{customer.FirstName} {customer.LastName}" : "",
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

            int customerId = 2; // Hardcoded for now

            BasketItems = _context.BasketItems
                .Include(b => b.Product)
                .Where(b => b.CustomerID == customerId)
                .ToList();

            // Check if the basket is empty
            if (BasketItems == null || !BasketItems.Any())
            {
                ModelState.AddModelError("", "Your cart is empty. Please add items to your cart before checking out.");
                return Page();
            }

            var order = new Order
            {
                CustomerID = 2, // Hardcoded for now
                OrderDate = DateTime.Now,
                ExpectedDeliveryDate = DateTime.Now.AddDays(7),
                DeliveryAddress = CheckoutData.DeliveryAddress,
                PostalCode = CheckoutData.PostalCode,
                City = CheckoutData.City,
                Country = CheckoutData.Country,
                OrderItems = new List<OrderItem>()
            };

            foreach (var basketItem in BasketItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductID = basketItem.ProductID,
                    Quantity = basketItem.Quantity,
                    UnitPrice = basketItem.Product.Price // Store the price at purchase time
                });
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            var basketItems = _context.BasketItems.Where(b => b.CustomerID == 2);
            _context.BasketItems.RemoveRange(basketItems);
            _context.SaveChanges();

            return RedirectToPage("OrderConfirmation", new { orderId = order.OrderID });

        }




    }
}
