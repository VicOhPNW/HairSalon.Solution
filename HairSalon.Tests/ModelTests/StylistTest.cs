using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Test
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=victoria_oh_test;";
    }
      [TestMethod]
      public void GetStylistName_ReturnsStylistName_String()
      {
        //Arrange
        string stylistName = "Panatda";
        Stylist newStylist = new Stylist(stylistName);

        //Act
        string result = newStylist.GetStylistName();

        //Assert
        Assert.AreEqual(stylistName, result);
      }

      [TestMethod]
      public void GetId_Id_int()
      {
        //Arrange
        int id = 0;
        Stylist newStylist = new Stylist("", 0);

        //Act
        int result = newStylist.GetId();

        //Assert
        Assert.AreEqual(id, result);
      }

      [TestMethod]
      public void Equals_ReturnsTrueForSameName_Stylist()
      {
        //Arrange, Act
        Stylist firstName = new Stylist("Panatda");
        Stylist secondName = new Stylist("Panatda");

        //Assert
        Assert.AreEqual(firstName, secondName);
      }

      [TestMethod]
       public void GetAll_StylistsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Stylist.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
