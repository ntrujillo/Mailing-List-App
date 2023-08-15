using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.DataAccess;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsDataAccess _context;

        public ContactsController(ContactsDataAccess context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact addContactRequest)
        {
            if (addContactRequest != null)
            {
                var contactInDb = _context.Contacts.Find(addContactRequest.Email);

                // check that entry hasn't been made already
                if (contactInDb == null)
                {
                    _context.Contacts.Add(addContactRequest);
                    _context.SaveChanges();
                    TempData["AlertMessage"] = "Successfully created contact!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["AlertMessage"] = "Contact already exists.";
                    return View();
                }

            } else
            {
                TempData["AlertMessage"] = "Invalid contact.";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
