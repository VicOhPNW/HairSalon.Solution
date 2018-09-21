using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _stylistName;

    public Stylist(string stylistName, int id = 0)
    {
      _stylistName = stylistName;
      _id = id;
    }

    public string GetStylistName()
    {
        return _stylistName;
    }
    public int GetId()
    {
        return _id;
    }

    public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.GetId().Equals(newStylist.GetId());
                bool nameEquality = this.GetStylistName().Equals(newStylist.GetStylistName());
                return (idEquality && nameEquality);
            }
        }
    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }

    public static List<Stylist> GetAll()
    {
        List<Stylist> allStylists = new List<Stylist>{};
        //more code to go here
        return allStylists;
    }

    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";
        cmd.ExecuteNonQuery();
        conn.Close();

        if (conn != null)
        {
            conn.Dispose();
        }
    }

  }
}
