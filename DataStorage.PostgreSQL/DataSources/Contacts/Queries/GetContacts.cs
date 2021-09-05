using Commons.Dto;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.Contacts.Queries
{
    public class GetContacts
    {
        public static List<ContactGetDto> Get(String conString, int limit, int start)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {
                conn.Open();
                NpgsqlCommand command = conn.CreateCommand();


                command.Parameters.Add(new NpgsqlParameter("@limit", limit));
                command.Parameters.Add(new NpgsqlParameter("@offset", limit * start));

                command.CommandText = string.Format(@"select * from address_book.contacts c 
                                                                            order by c.name asc
                                                                            limit @limit
                                                                            offset @offset");

                NpgsqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) { reader.Close(); return null; }

                List<ContactGetDto> contacts = new List<ContactGetDto>();
                while (reader.Read())
                {
                    var contactGetDto = new ContactGetDto()
                    {
                        Id = reader.GetRecord<int>("id"),
                        Name = reader.GetRecord<string>("name"),
                        Address = reader.GetRecord<string>("address"),
                        DateOfBirth = reader.GetRecord<DateTime>("date_of_birth")
                    };
                    contacts.Add(contactGetDto);
                }
                reader.Close();
                return contacts;
            }
        }
    }
}
