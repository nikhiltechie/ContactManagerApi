using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataAccess;
using AutoMapper;

namespace BusinessServices
{
    public class ContactService : IContactService
    {
        public IEnumerable<ContactEntity> GetAllContacts()
        {
            IEnumerable<ContactEntity> lstContact;
            using (EvolentTestEntities dbContext = new EvolentTestEntities())
            {
                var contacts = dbContext.tblContacts.Where(c => c.Status == true).ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<tblContact, ContactEntity>();
                });
                IMapper imapper = config.CreateMapper();

                lstContact = contacts.Select(imapper.Map<tblContact, ContactEntity>);
                return lstContact;
            }
        }

        public int UpdateContact(ContactEntity contact)
        {
            using (EvolentTestEntities dbContext = new EvolentTestEntities())
            {
                int entriesAffected =0;
                var objContact = dbContext.tblContacts.SingleOrDefault(c => c.Id == contact.Id);
                if (objContact != null)
                {
                    objContact.FirstName = contact.FirstName;
                    objContact.LastName = contact.LastName;
                    objContact.PhoneNumber = contact.PhoneNumber;
                    objContact.Email = contact.Email;
                    entriesAffected = dbContext.SaveChanges();
                }
                return entriesAffected;
            }
            
            
        }
        public int AddContact(ContactEntity contact)
        {
            using(EvolentTestEntities dbContext = new EvolentTestEntities())
            {
                dbContext.tblContacts.Add(new tblContact()
                {
                    Email = contact.Email,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    PhoneNumber = contact.PhoneNumber,
                    Status = contact.Status
                });
                int entriesAffected = dbContext.SaveChanges();
                return entriesAffected;
            }
            
        }
        public int DeleteContact(int id)
        {
            using (EvolentTestEntities dbContext = new EvolentTestEntities())
            {
                int entriesAffected = 0;
                var objContact = dbContext.tblContacts.SingleOrDefault(c => c.Id == id);
                if (objContact != null)
                {
                    objContact.Status = false;
                    entriesAffected = dbContext.SaveChanges();
                }
                return entriesAffected;
            }

        }
    }

}
