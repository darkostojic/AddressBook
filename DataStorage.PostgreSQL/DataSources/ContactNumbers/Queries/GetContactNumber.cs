using Commons.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.ContactNumbers.Queries
{
    public class GetContactNumber
    {
        public static ContactNumber Get(String conString, int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {
                conn.Open();
                NpgsqlCommand command = conn.CreateCommand();


                command.Parameters.Add(new NpgsqlParameter("@id", id));

                command.CommandText = string.Format(@"select 
                                                        id, 
                                                        number, 
                                                        contact_id
                                                      from address_book.contact_numbers where                                                      
                                                        id=@id");

                NpgsqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) { reader.Close(); return null; }

                ContactNumber contactNumber = null;
                while (reader.Read())
                {
                    contactNumber = new ContactNumber()
                    {
                        Id = reader.GetRecord<int>("id"),
                        Number = reader.GetRecord<string>("number")
                    };

                }
                reader.Close();
                return contactNumber;
            }
        }
    }
}
