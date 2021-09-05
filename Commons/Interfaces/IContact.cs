using Commons.Dto;
using Commons.Models;
using Commons.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Interfaces
{
    public interface IContact
    {
        CommonResponse CreateContact(ContactCreateDto contact);
        CommonResponse EditContact(int id, ContactEditDto contact);
        CommonResponse DeleteContact(int id);
        Contact GetContact(int id);
        List<ContactGetDto> GetContacts(int limit, int start);

    }
}
