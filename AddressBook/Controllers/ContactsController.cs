using AddressBook.Services;
using Commons.Dto;
using Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBook.Controllers
{
    [Route("api/contact/")]
    public class ContactsController : ControllerBase
    {

        private ILogger _logger;
        private IContact _contact;
        private NotificationService _notificationService;

        public ContactsController(ILogger<ContactsController> logger, IAdressBook adressBook, NotificationService notificationService)
        {
            this._logger = logger;
            this._contact = adressBook.ContactsDataSource();
            this._notificationService = notificationService;
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] ContactCreateDto contact)
        {
            _logger.LogInformation("InsertContact Action Called");
            _notificationService.SendNotificationAsync("InsertContact Action Called");
            var response = _contact.CreateContact(contact);
            _logger.LogInformation("InsertContact Action Finished");
            return Ok(response);
        }

        [HttpGet("{id}")]   
        public IActionResult GetContact(int id)
        {
            _logger.LogInformation("GetContact Action Called");
            _notificationService.SendNotificationAsync("GetContact Action Called");
            var contact = _contact.GetContact(id);
            _logger.LogInformation("GetContact Action Finished");
            return Ok(contact);
        }

        [HttpGet("{limit}/{start}")]
        public IActionResult GetContacts(int limit, int start)
        {
            _logger.LogInformation("GetContacts Action Called");
            _notificationService.SendNotificationAsync("GetContacts Action Called");
            var contact = _contact.GetContacts(limit, start);
            _logger.LogInformation("GetContacts Action Finished");
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _logger.LogInformation("DeleteContact Action Called");
            _notificationService.SendNotificationAsync("DeleteContact Action Called");
            var response = _contact.DeleteContact(id);
            _logger.LogInformation("DeleteContact Action Finished");
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] ContactEditDto contact)
        {
            _logger.LogInformation("UpdateContact Action Called");
            _notificationService.SendNotificationAsync("UpdateContact Action Called");
            var response = _contact.EditContact(id, contact);
            _logger.LogInformation("UpdateContact Finished");
            return Ok(response);
        }

    }
}
