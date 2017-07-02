using UBSWebApplication.Core.Helpers;
using UBSWebApplication.Core.Models;
using UBSWebApplication.Core.ViewModels;

namespace UBSWebApplication.Core.Mappers
{
    public static class ContactMapper
    {
        public static ContactViewModel ToViewModel(this Contact contact)
        {
            return new ContactViewModel
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Street = contact.Street,
                Zip = contact.Zip,
                Country = contact.Country,
                City = contact.City,
                Image = "https://api.randomuser.me/portraits/men/" + contact.Id + ".jpg"
        };
        }

        public static Contact ToModel(this ContactViewModel contact)
        {
            return new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Street = contact.Street,
                Zip = contact.Zip,
                Country = contact.Country,
                City = contact.City,
                ImageId = RandomNumber.Next()
            };
        }
    }
}