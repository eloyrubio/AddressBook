using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using UBSWebApplication.Core.Mappers;
using UBSWebApplication.Core.Repositories;
using UBSWebApplication.Core.ViewModels;

namespace UBSWebApplication.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepository;
        
        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var contacts = _contactsRepository.GetContacts().Select(c => c.ToViewModel());

            return View(contacts);
        }

        [HttpGet]
        public JsonResult Contacts(string query = null)
        {
            var contacts = _contactsRepository.GetContacts(query).Select(c => c.ToViewModel());

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var contact = _contactsRepository.AddContact(contactViewModel.ToModel()); 

            return Json(new { success = true, contact = contact.ToViewModel() });
        }
   
        [HttpPost]
        public JsonResult Edit(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var contact = _contactsRepository.UpdateContact(contactViewModel.ToModel());

            return Json(new { success = true, contact = contact.ToViewModel() });
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var contact = _contactsRepository.DeleteContact(id);
            return Json(new { success = contact != null, contact = contact.ToViewModel() }, JsonRequestBehavior.AllowGet);
        }
    }
}
