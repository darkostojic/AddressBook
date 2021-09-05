using Commons.Dto;
using Commons.Models;
using Commons.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Interfaces
{
    public interface IContactNumber
    {
        CommonResponse CreateContactNumber(int contactId, ContactNumberDto number);
        CommonResponse EditContactNumber(int id, ContactNumberDto number);
        CommonResponse DeleteContactNumber(int id);
        ContactNumber GetContactNumber(int id);
        List<ContactNumber> GetContactNumbers(int contactId);
        
    }
}
