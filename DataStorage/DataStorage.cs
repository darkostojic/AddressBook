using Commons.Interfaces;
using DataStorage.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage
{
    public class DataStorage
    {
        public static IAdressBook GetService(string service, string connString)
        {
            switch (service)
            {
                case "postgres":
                    return new PostgreDataSource(connString);
                case "sqlserver":
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
