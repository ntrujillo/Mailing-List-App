using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClarkCodingChallenge.Controllers.Api
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsDataAccess _context;

        public ContactsController(ContactsDataAccess context)
        {
            _context = context;
        }


        // Get All
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Ok(_context.Contacts));
        }

        // Create
        [HttpPost]
        public JsonResult Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return new JsonResult(Ok(contact));
        }
    }
}

