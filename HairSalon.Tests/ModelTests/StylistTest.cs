using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using ToDoList.Models;

namespace ToDoList.Test
{
  [TestClass]
  public class CategoryTests : IDisposable
  {
    public CategoryTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=victoria_oh_test;";
    }
