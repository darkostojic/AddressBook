using Commons.Dto;
using Commons.Interfaces;
using Commons.Models;
using Commons.Responses;
using DataStorage.PostgreSQL.DataSources.ContactNumbers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.ContactNumbers
{
    public class ContactNumberDataSource : IContactNumber
    {
        private readonly string ConnectionString;

        public ContactNumberDataSource(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public CommonResponse CreateContactNumber(int contactId, ContactNumberDto number)
        {
            return InsertContactNumber.Insert(ConnectionString, contactId, number);
        }

        public CommonResponse DeleteContactNumber(int id)
        {
            return Commands.DeleteContactNumber.Delete(ConnectionString, id);
        }

        public CommonResponse EditContactNumber(int id, ContactNumberDto number)
        {
            return UpdateContactNumber.Update(ConnectionString, id, number);
        }

        public ContactNumber GetContactNumber(int id)
        {
            return Queries.GetContactNumber.Get(ConnectionString, id);
        }

        public List<ContactNumber> GetContactNumbers(int contactId)
        {
            return Queries.GetContactNumbers.Get(ConnectionString, contactId);
        }
    }
}
