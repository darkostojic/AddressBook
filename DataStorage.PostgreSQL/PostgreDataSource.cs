using Commons.Interfaces;
using DataStorage.PostgreSQL.DataSources.ContactNumbers;
using DataStorage.PostgreSQL.DataSources.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL
{
    public class PostgreDataSource : IAdressBook
    {
        private readonly string ConnectionString;

        public PostgreDataSource(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IContactNumber ContactNumbersDataSource()
        {
            return new ContactNumberDataSource(ConnectionString); ;
        }

        public IContact ContactsDataSource()
        {
            return new ContactDataSource(ConnectionString);
        }
    }
}
