using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using UBSWebApplication.Core.Models;
using UBSWebApplication.Core.Repositories;

namespace UBSWebApplication.Persistance.JSON.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private const string DatabasePath = @"c:\temp\adress.json";

        public IEnumerable<Contact> GetContacts(string query = null)
        {
            if(!File.Exists(DatabasePath))
            {
                File.Create(DatabasePath).Dispose();
                File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(new List<Contact>()));
            }

            var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(File.ReadAllText(DatabasePath));

            if (query != null)
            {
                return contacts.Where(c => c.FirstName.ToLower().Contains(query.ToLower()) || c.LastName.ToLower().Contains(query.ToLower())).ToList();
            }

            return contacts;
        }

        public Contact AddContact(Contact contact)
        {
            var contacts = GetContacts().ToList();

            contact.Id = GetNextId(contacts);

            contacts.Add(contact);

            File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(contacts));

            return contact;
        }

        public Contact UpdateContact(Contact contact)
        {
            var contacts = GetContacts().ToList();
            contacts.RemoveAll(c => c.Id == contact.Id);
            contacts.Add(contact);

            File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(contacts));

            return contact;
        }

        public Contact DeleteContact(int contactId)
        {
            var contacts = GetContacts().ToList();
            var contact = contacts.FirstOrDefault(c=>c.Id == contactId);
            contacts.Remove(contact);

            File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(contacts));

            return contact;
        }

        private static int GetNextId(IEnumerable<Contact> contacts)
        {
            if (contacts.Any())
            {
                return contacts.OrderByDescending(c => c.Id).Select(c => c.Id).First() + 1;
            }

            return 1;
        }
    }
}
