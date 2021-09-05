using Commons.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.Contacts.Queries
{
    public class GetContact
    {
        public static Contact Get(String conString, int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {
                conn.Open();
                NpgsqlCommand command = conn.CreateCommand();


                command.Parameters.Add(new NpgsqlParameter("@id", id));

                command.CommandText = string.Format(@"select c.id c_id, 
                                                        c.name c_name, 
                                                        c.address c_address, 
                                                        c.date_of_birth  c_date_of_birth, 
                                                        cn.id cn_id, 
                                                        cn.number cn_number 
                                                        from address_book.contacts c  
                                                        left join address_book.contact_numbers cn on c.id =cn.contact_id 
                                                        where c.id  = @id");

                NpgsqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) { reader.Close(); return null; }

                Contact contact = null;
                while (reader.Read())
                {
                    if(contact == null)
                    {
                        contact = new Contact()
                        {
                            Id = reader.GetRecord<int>("c_id"),
                            Name = reader.GetRecord<string>("c_name"),
                            Address = reader.GetRecord<string>("c_address"),
                            DateOfBirth = reader.GetRecord<DateTime>("c_date_of_birth"),
                            ContactNumbers = new List<ContactNumber>()
                        };
                    }
                    ContactNumber contactNumber = new ContactNumber()
                    {
                        Id = reader.GetRecord<int>("cn_id"),
                        Number = reader.GetRecord<string>("cn_number")
                    };
                    contact.ContactNumbers.Add(contactNumber);

                }
                reader.Close();
                return contact;
            }
        }
    }
}
