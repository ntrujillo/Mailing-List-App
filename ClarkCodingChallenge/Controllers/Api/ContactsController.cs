using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MailingList.DataAccess;
using MailingList.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailingList.Controllers.Api
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly MailingListContext _context;

        public ContactsController(MailingListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAll([FromQuery] string lastName, [FromQuery] bool descending)
        {
            IQueryable<Contact> contacts = _context.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(lastName)) /* if last name filter */
            {
                /* filter out contacts that dont have LastName = lastName */
                contacts = contacts.Where(c => c.LastName == lastName);
            }

            /* order by descending if flagged */ 
            if (descending)
            {
                contacts = contacts
                    .OrderByDescending(c => c.LastName)
                    .ThenByDescending(c => c.FirstName);
            }
            else
            {
                contacts = contacts
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.FirstName);
            }

            /* return the updated constacts */
            return new JsonResult(Ok(contacts));
        }
    }
}

