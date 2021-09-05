using Commons.Dto;
using Commons.Responses;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.ContactNumbers.Commands
{
    public class UpdateContactNumber
    {
        public static CommonResponse Update(String conString, int id, ContactNumberDto number)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {
                CommonResponse response = new CommonResponse();

                conn.Open();
                NpgsqlCommand command = conn.CreateCommand();


                command.Parameters.Add(new NpgsqlParameter("@id", id));
                command.Parameters.Add(new NpgsqlParameter("@number", number.Number));
                command.CommandText = string.Format(@"update address_book.contact_numbers set
                                                    number = @number
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
