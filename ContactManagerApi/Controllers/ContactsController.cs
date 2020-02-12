using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessServices;
using BusinessEntities;

namespace ContactManagerApi.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        [Route("api/contactlist")]
        public IHttpActionResult Get()
        {
            try
            {
                var contacts = _contactService.GetAllContacts();
                return Ok(contacts);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
       
        [HttpPost]
        [Route("api/addcontact")]
        public IHttpActionResult AddContact([FromBody]ContactEntity contact)
        {
            try
            {
                if (_contactService.AddContact(contact) == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/editcontact")]
        public IHttpActionResult UpdateContact([FromBody]ContactEntity contact)
        {
            try
            {
                if (_contactService.UpdateContact(contact) == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/deletecontact/{id}")]
        public IHttpActionResult DeleteContact(int id)
        {
            try
            {
                if (_contactService.DeleteContact(id) == 1)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return InternalServerError();
            } 
        }
    }
}
