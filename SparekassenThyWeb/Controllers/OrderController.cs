
using Microsoft.AspNetCore.Mvc;
using MomentozWebClient.BusinessLogicLayer;
using MomentozWebClient.Models;
using System.Security.Claims;

namespace MomentozWebClient.Controllers
{
    public class OrderController : Controller
    {
        readonly OrderLogic _ordersLogic;
        readonly CustomerLogic _customerLogic;
        private static OrderData dataBag = OrderData.getInstance();

        public OrderController(IConfiguration inConfiguration)
        {
            _ordersLogic = new OrderLogic(inConfiguration);
            _customerLogic = new CustomerLogic(inConfiguration);
        }

        public async Task<ActionResult> ViewOrderData(int id)
        {
            dataBag.OrderFlight = await _ordersLogic.getFlightById(id);

            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customerFromService = await _customerLogic.GetCustomerByUserId(userId);

            dataBag.OrderCustomer = customerFromService;

            return View(dataBag);
        }

        // POST: api/Order/{Order}
        [HttpPost("Order")]
        public async Task<ActionResult> ViewOrderReceipt(int id)
        {
            if (dataBag.Id != id)
            {
                return View(null);
            }

            Order order = new Order();
            order.FlightID = dataBag.OrderFlight.FlightID;
            order.CustomerID = dataBag.OrderCustomer.CustomerID;
            order.TotalPrice = dataBag.OrderFlight.Price;
            order.PurchaseDate = DateTime.Now;

            Order submittedOrder = await _ordersLogic.postNewOrder(order);
            if (submittedOrder == null)
            {
                return View(null);
            }
            dataBag.OrderOrder = submittedOrder;

            return View(dataBag);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
