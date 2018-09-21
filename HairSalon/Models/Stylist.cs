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

    public string GetAll()
    {

    }

  }
}
