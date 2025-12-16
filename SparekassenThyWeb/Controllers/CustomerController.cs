using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomentozWebClient.BusinessLogicLayer;
using MomentozWebClient.Models;
using System.Security.Claims;

namespace MomentozWebClient.Controllers
{
    public class CustomerController : Controller
    {

        readonly CustomerLogic _customerLogic;
        private static string userId;
        public void setUserId(string id) { userId = id; }
        public CustomerController(IConfiguration inConfiguration)
        {
            _customerLogic = new CustomerLogic(inConfiguration);
        }



        // GET: CustomerController. 

        public async Task<ActionResult> GetAllCustomers()
        {
            System.Security.Claims.ClaimsPrincipal loggedInUser = User;
            
            
            List<Customer>? foundCustomers = await _customerLogic.GetAllCustomers();
            return View(foundCustomers);

            
        }


        [Authorize] 
        public async Task<IActionResult> Profile()
        {
            // Get id logged in user
            userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Get customer through service
            Customer customerFromService = await _customerLogic.GetCustomerByUserId(userId);
            // If customer was not found (but call ok)
            if (customerFromService != null && customerFromService.LoginUserId == null || customerFromService == null)
            {
                string? loginEmail = User.Identity is not null ? User.Identity.Name : null;
                /* Create customer - and get created customer */
                customerFromService = await _customerLogic.CreateCustomerFromUserAccount(userId, loginEmail);
            }
            return View(customerFromService);
        }

        public async Task<Customer> getCustomerByOrderCustomerId()
        {
            Customer fromService = await _customerLogic.GetCustomerByUserId(userId);
            return fromService;
        }



        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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

        // GET: CustomerController/Edit/{id}
        public ActionResult Edit(string id)
        {
            userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!userId.Equals(id)) { /* throw error */ }

            string? email = User.Identity is not null ? User.Identity.Name : null;
            Customer loggedCustomer = new Customer(userId, email);
            return View(loggedCustomer);
        }

        // POST: CustomerController/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IFormCollection formCustomer)
        {
            try
            {
                Customer reOrientedCustomer = new Customer(formCustomer);
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string? email = User.Identity is not null ? User.Identity.Name : null;
                reOrientedCustomer.LoginUserId = userId;
                reOrientedCustomer.Email = email;
                Customer customerUpdated = await _customerLogic.UpdateCustomer(reOrientedCustomer);

                if (customerUpdated == null) {/* handle error */}
                    
                return RedirectToAction("Profile");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
