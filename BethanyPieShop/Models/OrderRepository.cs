using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var cartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = cartItem.Amount,
                    PieId = cartItem.Pie.PieId,
                    Price = cartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _context.Orders.Add(order);

            _context.SaveChanges();
        }
    }
}
