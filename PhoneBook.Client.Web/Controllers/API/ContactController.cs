using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneBook.Business.Contracts;
using PhoneBook.Business.Entities;
using PhoneBook.Client.Web.Core;
using PhoneBook.Client.Web.Models;

namespace PhoneBook.Client.Web.Controllers.API
{
    public class ContactController : ApiControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public HttpResponseMessage GetContact(HttpRequestMessage request, int id)
        {
            return GetHttpResponse(request, () =>
            {
                var contact = _contactService.GetContactById(id);
                var contactViewModels = MvcApplication.Mapper.Map<Person, Contact>(contact);
                return request.CreateResponse(HttpStatusCode.OK, contactViewModels);
            });
        }

        [HttpGet]
        public HttpResponseMessage GetAllContacts(HttpRequestMessage request, string filter = null)
        {
            return GetHttpResponse(request, () =>
            {
                var contacts = _contactService.GetContacts(filter);
                var contactViewModels = MvcApplication.Mapper.Map<List<Person>, List<Contact>>(contacts);
                return request.CreateResponse(HttpStatusCode.OK, contactViewModels.ToArray());
            });
        }

        [HttpPost]
        public HttpResponseMessage UpdateContact(HttpRequestMessage request, [FromBody]Contact contact)
        {
            return GetHttpResponse(request, () =>
            {
                var contactDomainModel = MvcApplication.Mapper.Map<Contact, Person>(contact);
                contactDomainModel = _contactService.UpdateContact(contactDomainModel);
                var contactViewModels = MvcApplication.Mapper.Map<Person, Contact>(contactDomainModel);
                return request.CreateResponse(HttpStatusCode.OK, contactViewModels);
            });
        }

        [HttpPost]
        public HttpResponseMessage InsertContact(HttpRequestMessage request, [FromBody]Contact contact)
        {
            return GetHttpResponse(request, () =>
            {
                var contactDomainModel = MvcApplication.Mapper.Map<Contact, Person>(contact);
                contactDomainModel = _contactService.InsertContact(contactDomainModel);
                var contactViewModels = MvcApplication.Mapper.Map<Person, Contact>(contactDomainModel);
                return request.CreateResponse(HttpStatusCode.OK, contactViewModels);
            });
        }

        [HttpPost]
        public HttpResponseMessage DeleteContact(HttpRequestMessage request, int id)
        {
            return GetHttpResponse(request, () =>
            {
                _contactService.DeleteContact(id);
                return request.CreateResponse(HttpStatusCode.OK);
            });
        }
    }
}