using System.Collections.Generic;

using UBSWebApplication.Core.Models;

namespace UBSWebApplication.Core.Repositories
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetContacts(string query = null);

        Contact AddContact(Contact contact);

        Contact UpdateContact(Contact contact);

        Contact DeleteContact(int contactId);
    }
}