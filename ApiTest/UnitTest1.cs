using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessEntities;
using BusinessServices;
using System.Collections.Generic;

namespace ApiTest
{
    [TestClass]
    public class ContactControllerTest
    {
        [TestMethod]
        public void GetContactList()
        {
            ContactService service = new ContactService();
            var testContacts = GetTestContacts();
            List<ContactEntity> result = service.GetAllContacts() as List<ContactEntity>;
            Assert.AreEqual(testContacts.Count, result.Count);
        }

        [TestMethod]
        public void EditContact()
        {
            ContactService service = new ContactService();
            ContactEntity contact = new ContactEntity() { Id = 2,FirstName = "Tom",LastName = "Wilson",Email="tw@gmail.com",PhoneNumber="123456",Status = true };
           
            var result = service.UpdateContact(contact);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteContact()
        {
            ContactService service = new ContactService();
            
            var result = service.DeleteContact(1);
            Assert.AreEqual(1, result);
        }
        private List<ContactEntity> GetTestContacts()
        {
            var testContacts = new List<ContactEntity>();
            testContacts.Add(new ContactEntity { Id =1 ,FirstName = "John", LastName = "Jackson",PhoneNumber = "1234567890",Email = "jj@gmail.com",Status=true });
            testContacts.Add(new ContactEntity { Id = 2, FirstName = "Alex", LastName = "Trump", PhoneNumber = "2233445590", Email = "at@gmail.com", Status = true });
            testContacts.Add(new ContactEntity { Id = 3, FirstName = "Rahul", LastName = "Singh", PhoneNumber = "456372891", Email = "rs@gmail.com", Status = true });
            testContacts.Add(new ContactEntity { Id = 4, FirstName = "Ramesh", LastName = "Gupta", PhoneNumber = "23788967", Email = "rg@gmail.com", Status = true });

            return testContacts;
        }
    }
}
