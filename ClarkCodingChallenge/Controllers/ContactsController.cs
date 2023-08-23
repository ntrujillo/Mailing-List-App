using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MailingList.Models;
using MailingList.DataAccess;


namespace MailingList.Controllers
{
    public class ContactsController : Controller
    {
        private readonly MailingListContext _context;

        public ContactsController(MailingListContext context)
        {
            _context = context;
        }

        /* Index (Home) */
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList(); // Retrieve all contacts
            return View(contacts); // Pass the list of contacts to the view
        }

        /* View Create Form */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /* Submit Create Form */
        [HttpPost]
        public IActionResult Create(Contact createContactRequest)
        {
            /* check that model binding had completed successfulyl */
            if (createContactRequest != null && ModelState.IsValid)
            {

                /* ensure contact doesn't already exist */
                var contactInDb = _context.Contacts.Find(createContactRequest.Email);
                if (contactInDb == null)
                {
                    /* Contact successfully created */
                    _context.Contacts.Add(createContactRequest);
                    _context.SaveChanges();
                    TempData["AlertMessage"] = "Successfuly Created Contact!";
                    return View();
                }
                else
                {
                    /* Contact already exists */
                    ModelState.AddModelError(nameof(Contact.Email), "Contact Email Already Exists!");
                    return View(createContactRequest);
                }

            } else
            {
                /* Model is not valid */
                return View(createContactRequest);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
