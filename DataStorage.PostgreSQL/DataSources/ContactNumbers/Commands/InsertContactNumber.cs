using Commons.Dto;
using Commons.Responses;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.ContactNumbers.Commands
{
    public class InsertContactNumber
    {
        public static CommonResponse Insert(String conString,int contactId, ContactNumberDto number)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {

                CommonResponse response = new CommonResponse();
                try
                {
                    conn.Open();
                    NpgsqlCommand command = conn.CreateCommand();
                    command.Parameters.Add(new NpgsqlParameter("@contact_id", contactId));
                    command.Parameters.Add(new NpgsqlParameter("@number", number.Number));

                    command.CommandText = string.Format(@"insert into address_book.contact_numbers(number, contact_id)
                                                      values (@number, @contact_id) returning id");

                    var id = (int)command.ExecuteScalar();
                    response.Success = id > 0;
                    response.ReturningId = id;
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
