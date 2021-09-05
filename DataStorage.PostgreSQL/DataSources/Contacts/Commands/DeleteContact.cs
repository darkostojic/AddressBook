using Commons.Responses;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.Contacts.Commands
{
    public class DeleteContact
    {
        public static CommonResponse Delete(String conString, int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {

                CommonResponse response = new CommonResponse();
                try
                {
                    conn.Open();
                    NpgsqlCommand command = conn.CreateCommand();
                    command.Parameters.Add(new NpgsqlParameter("@id", id));

                    command.CommandText = string.Format(@"delete from address_book.contacts
                                                        where id = @id");

                    var executed = (int)command.ExecuteNonQuery();
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
