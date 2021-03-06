﻿using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

using UBSWebApplication.Core.Models;
using UBSWebApplication.Core.Repositories;

namespace UBSWebApplication.Persistance.EF.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetContacts(string query = null)
        {
            if(!string.IsNullOrWhiteSpace(query))
            {
                var tokens = query.Split(null);
             
                return _context.Contacts.Where(c => tokens.Any(t=> c.FirstName.ToLower().Contains(t.ToLower())) || tokens.Any(t => c.LastName.ToLower().Contains(t.ToLower()))).ToList();
            }

            return _context.Contacts.ToList();
        }

        public Contact AddContact(Contact contact)
        {
            _context.Contacts.AddOrUpdate(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact UpdateContact(Contact contact)
        {
            _context.Contacts.AddOrUpdate(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact DeleteContact(int contactId)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == contactId);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();

                return contact;
            }

            return null;
        }
    }
}