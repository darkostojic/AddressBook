using Commons.Dto;
using Commons.Responses;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.PostgreSQL.DataSources.Contacts.Commands
{
    public class InsertContact
    {
        public static CommonResponse Insert(String conString, ContactCreateDto contact)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(conString))
            {
                int createdId = 0;
                CommonResponse response = new CommonResponse();
               
                conn.Open();
                NpgsqlCommand command = conn.CreateCommand();
                using (NpgsqlTransaction transaction = conn.BeginTransaction()) {
                    command.Parameters.Add(new NpgsqlParameter("@name", contact.Name));
                    command.Parameters.Add(new NpgsqlParameter("@date_of_birth", contact.DateOfBirth));
                    command.Parameters.Add(new NpgsqlParameter("@address", contact.Address));

                    command.CommandText = string.Format(@"insert into address_book.contacts(name, date_of_birth, address)
                                                    values (@name, @date_of_birth, @address) returning id");
                    try
                    {
                        createdId = (int)command.ExecuteScalar();
                    }
                    catch(Exception e)
                    {

                        response.Success = false;
                        response.Message = e.Message.ToString();
                        return response;
                    }
                    command.Parameters.Clear();
                    if(contact.ContactNumbers.Count == 0 || contact.ContactNumbers != null)
                    {
                        int counter = 0;
                        List<string> valuesList = new List<string>();
                        foreach (var number in contact.ContactNumbers)
                        {
                            command.Parameters.Add(new NpgsqlParameter("@number_" + counter.ToString(), number));
                            valuesList.Add("(" + "@number_" + counter.ToString() + ", "+ createdId + ")");
                            counter++;
                        }
                        string valuesString = string.Join(",", valuesList);
                        command.CommandText = string.Format(@"insert into address_book.contact_numbers(number, contact_id)
                                                      values {0} ", valuesString);
                        try
                        {
                            int sucess = command.ExecuteNonQuery();
                            response.Success = sucess > 0;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            response.Success = false;
                            response.Message = ex.Message.ToString();
                            return response;
                        }
                        transaction.Commit();
                    }
                    conn.Close();
                }
                
                response.ReturningId = createdId;
                return response;
            }
        }
    }
}
