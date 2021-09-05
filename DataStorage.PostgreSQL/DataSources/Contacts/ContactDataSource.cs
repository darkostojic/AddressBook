using Commons.Dto;
using Commons.Interfaces;
using Commons.Models;
using Commons.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.Contacts
{
    public class ContactDataSource : IContact
    {
        private readonly string ConnectionString;

        public ContactDataSource(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public CommonResponse CreateContact(ContactCreateDto contact)
        {
            return Commands.InsertContact.Insert(ConnectionString, contact);
        }

        public CommonResponse DeleteContact(int id)
        {
            return Commands.DeleteContact.Delete(ConnectionString, id);
        }

        public CommonResponse EditContact(int id, ContactEditDto contact)
        {
            return Commands.UpdateContact.Update(ConnectionString, id, contact);
        }

        public Contact GetContact(int id)
        {
            return Queries.GetContact.Get(ConnectionString, id);
        }

        public List<ContactGetDto> GetContacts(int limit, int start)
        {
            return Queries.GetContacts.Get(ConnectionString, limit, start);
        }
    }
}
