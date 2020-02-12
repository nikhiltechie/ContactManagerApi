using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IContactService
    {
         IEnumerable<ContactEntity> GetAllContacts();
         int UpdateContact(ContactEntity contact);
         int AddContact(ContactEntity contact);
         int DeleteContact(int id);
    }
}
