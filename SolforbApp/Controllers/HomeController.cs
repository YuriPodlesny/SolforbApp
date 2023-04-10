using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using SolforbApp.Models;
using SolforbApp.ViewModels;
using System.Diagnostics;

namespace SolforbApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _order;
        private readonly IProviderRepository _provider;
        private readonly IOrderItemRepository _orderItem;

        public HomeController(IOrderRepository orderRepository,
            IProviderRepository provider,
            IOrderItemRepository orderItem)
        {
            _order = orderRepository;
            _provider = provider;
            _orderItem = orderItem;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var results = _order.GetAll();
            return View(results);
        }


        public async Task<IActionResult> Detail(int orderId)
        {
            var order = await _order.Get(orderId);
            var orderItems = _orderItem.GetOrderItemsByOrderId(orderId);
            if (order == null || orderItems == null)
            {
                return NotFound();
            }
            var provider = await _provider.Get(order.ProviderId);
            var model = new DetailViewModel
            {
                OrderId = order.Id,
                OrderDate = order.Date,
                OrderNumber = order.Number,
                ProviderName = provider?.Name,
                OrderItems = orderItems
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            CreateOrderViewModel createOrderViewModel = new ();
            var selectProvider = _provider.GetAll();
            List<SelectListItem> listItems = _provider.GetAll()
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name,
                }).ToList();
            createOrderViewModel.Providers = listItems;
            return View(createOrderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Number = model.Number,
                    Date = model.Date,
                    ProviderId = model.ProviderId,
                };
                var result = await _order.Create(order);
                if (result == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditOrder(int orderId)
        {
            var selectProvider = _provider.GetAll();
            List<SelectListItem> listItems = _provider.GetAll()
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name,
                }).ToList();

            var order = await _order.Get(orderId);
            if (order == null)
            {
                return NotFound();
            }
            var model = new EditOrderViewModel
            {
                Id = orderId,
                Number = order.Number,
                Date = order.Date,
                ProviderId = order.ProviderId,
                Providers = listItems
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder (EditOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = await _order.Get(model.Id);
                if(order != null)
                {
                    order.Number = model.Number;
                    order.Date = model.Date;
                    order.ProviderId = model.ProviderId;

                    var result = await _order.Update(order);
                    if(result == true)
                    {
                        return RedirectToAction(nameof(Detail), new { orderId = order.Id });
                    }
                }
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = _order.Get(orderId);
            if (order != null)
            {
                var result = await _order.Delete(orderId);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateOrderItem(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(CreateOrderItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new OrderItem
                {
                    OrderId = model.OrderId,
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Unit = model.Unit
                };
                var result = await _orderItem.Create(order);
                if (result == true)
                {
                    return RedirectToAction(nameof(Detail), new { orderId = order.OrderId });
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditOrderItem(int orderItemId)
        {
            var orderItem = await _orderItem.Get(orderItemId);
            if (orderItem == null)
            {
                return NotFound();
            }
            var model = new EditOrderItemViewModel
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                Name = orderItem.Name,
                Quantity = orderItem.Quantity,
                Unit = orderItem.Unit
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrderItem(EditOrderItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderItem = await _orderItem.Get(model.Id);
                if (orderItem != null)
                {
                    orderItem.Name = model.Name;
                    orderItem.Quantity = model.Quantity;
                    orderItem.Unit = model.Unit;

                    var result = await _orderItem.Update(orderItem);
                    if (result == true)
                    {
                        return RedirectToAction(nameof(Detail), new { orderId = model.OrderId });
                    }
                }
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrderItems(int orderItemId)
        {
            var orderItem = await _orderItem.Get(orderItemId);
            if (orderItem != null)
            {
                var result = await _orderItem.Delete(orderItemId);
                if(result == true)
                {
                    return RedirectToAction(nameof(Detail), new { orderId = orderItem.OrderId });
                }
            }
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}