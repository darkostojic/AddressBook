using AddressBook.Services;
using Commons.Dto;
using Commons.Interfaces;
using Commons.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [Route("api/contact/{contactId}/number/")]
    public class ContactNumbersController : ControllerBase
    {


        private ILogger _logger;
        private IContactNumber _contactNumber;
        private NotificationService _notificationService;

        public ContactNumbersController(ILogger<ContactNumbersController> logger, IAdressBook adressBook, NotificationService notificationService)
        {
            this._logger = logger;
            this._contactNumber = adressBook.ContactNumbersDataSource();
            this._notificationService = notificationService;
        }

        [HttpPost]
        public IActionResult CreateContactNumber(int contactId, [FromBody] ContactNumberDto number)
        {
            _logger.LogInformation("InsertContactNumber Action Called");
            _notificationService.SendNotificationAsync("InsertContactNumber Action Called");
            var response = _contactNumber.CreateContactNumber(contactId, number);
            _logger.LogInformation("InsertContactNumber Action Finished");
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactNumber(int id)
        {
            _logger.LogInformation("GetContactNumber Action Called");
            _notificationService.SendNotificationAsync("GetContactNumber Action Called");
            var contactNumber = _contactNumber.GetContactNumber(id);
            _logger.LogInformation("GetContactNumber Action Finished");
            return Ok(contactNumber);
        }

        [HttpGet]
        public IActionResult GetContactNumbers(int contactId)
        {
            _logger.LogInformation("GetContactNumbers Action Called");
            _notificationService.SendNotificationAsync("GetContactNumbers Action Called");
            var contactNumbers = _contactNumber.GetContactNumbers(contactId);
            _logger.LogInformation("GetContactNumbers Action Finished");
            return Ok(contactNumbers);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContactNumber(int id, [FromBody] ContactNumberDto number)
        {
            _logger.LogInformation("UpdateContactNumber Action Called");
            _notificationService.SendNotificationAsync("UpdateContactNumber Action Called");
            var response = _contactNumber.EditContactNumber(id, number);
            _logger.LogInformation("UpdateContactNumber Finished");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContactNumber(int id)
        {
            _logger.LogInformation("DeleteContactNumber Action Called");
            _notificationService.SendNotificationAsync("DeleteContactNumber Action Called");
            var response = _contactNumber.DeleteContactNumber(id);
            _logger.LogInformation("DeleteContactNumber Action Finished");
            return Ok(response);
        }
    }
}
