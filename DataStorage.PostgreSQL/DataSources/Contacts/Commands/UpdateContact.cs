using Commons.Dto;
using Commons.Responses;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.Contacts.Commands
{
    public class UpdateContact
    {
        public static CommonResponse Update(String conString, int id, ContactEditDto contact)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {
                CommonResponse response = new CommonResponse();

                conn.Open();
                NpgsqlCommand command = conn.CreateCommand();

                command.Parameters.Add(new NpgsqlParameter("@id", id));
                command.Parameters.Add(new NpgsqlParameter("@name", contact.Name));
                command.Parameters.Add(new NpgsqlParameter("@date_of_birth", contact.DateOfBirth));
                command.Parameters.Add(new NpgsqlParameter("@address", contact.Address));
                command.CommandText = string.Format(@"update address_book.contacts set
                                                    name = @name,
                                                    date_of_birth = @date_of_birth,
                                                    address = @address
                                                    where id = @id");

                try
                {
                    var executed = command.ExecuteNonQuery();
                    response.Success = executed > 0;

                }
                catch (Exception e)
                {
                    response.Message = e.Message.ToString();
                    response.Success = false;
                }
                return response;
            }
        }
    }
}
