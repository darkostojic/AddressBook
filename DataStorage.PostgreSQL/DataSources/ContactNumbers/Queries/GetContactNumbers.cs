using Commons.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.ContactNumbers.Queries
{
    public class GetContactNumbers
    {
        public static List<ContactNumber> Get(String conString, int contactId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {
                conn.Open();
                NpgsqlCommand command = conn.CreateCommand();


                command.Parameters.Add(new NpgsqlParameter("@contact_id", contactId));

                command.CommandText = string.Format(@"select 
                                                        id, 
                                                        number, 
                                                        contact_id
                                                      from address_book.contact_numbers where                                                      
                                                        contact_id=@contact_id");

                NpgsqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) { reader.Close(); return null; }

                List<ContactNumber> numbers = new List<ContactNumber>();
                while (reader.Read())
                {
                    var contactNumber = new ContactNumber()
                    {
                        Id = reader.GetRecord<int>("id"),
                        Number = reader.GetRecord<string>("number")
                    };
                    numbers.Add(contactNumber);
                }
                reader.Close();
                return numbers;
            }
        }
    }
}

