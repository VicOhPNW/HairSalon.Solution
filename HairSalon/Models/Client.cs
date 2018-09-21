using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _clientName;
    private int _stylistId;

    public Client(string clientName, int stylistId, int id = 0)
    {
      _clientName = clientName;
      _stylistId = stylistId;
      _id= id;
    }

    public string GetClientName()
    {
      return _clientName;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = this.GetId().Equals(newClient.GetId());
                bool nameEquality = this.GetClientName().Equals(newClient.GetClientName());
                bool stylistIdEquality = this.GetStylistId().Equals(newClient.GetStylistId());
                return (idEquality && nameEquality && stylistIdEquality);
            }
        }
    public override int GetHashCode()
    {
        return this.GetClientName().GetHashCode();
    }


    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients;";
        cmd.ExecuteNonQuery();
        conn.Close();

        if (conn != null)
        {
            conn.Dispose();
        }
    }
  }
}
