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
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int StylistId = rdr.GetInt32(0);
          string StylistName = rdr.GetString(1);
          Stylist newStylist = new Stylist(StylistName, StylistId);
          allStylists.Add(newStylist);
        }

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allStylists;
    }

    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO stylists (stylist_name) VALUES (@stylist_name);";

        MySqlParameter stylistName = new MySqlParameter();
        stylistName.ParameterName = "@stylist_name";
        stylistName.Value = this._stylistName;
        cmd.Parameters.Add(stylistName);

        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public static Stylist Find(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId)";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int StylistId = 0;
        string StylistName = "";

        while(rdr.Read())
        {
          StylistId = rdr.GetInt32(0);
          StylistName = rdr.GetString(1);
        }

        Stylist newStylist = new Stylist(StylistName, StylistId);
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newStylist;
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
