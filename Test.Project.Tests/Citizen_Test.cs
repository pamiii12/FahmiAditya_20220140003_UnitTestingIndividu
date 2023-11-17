using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Project.Library;


namespace Test.Project.Tests
{
    [TestClass]
    public class Citizen_Test
    {
        /*Data*/
        Citizen Fahmi = new Citizen()
        {
            Name = "Fahmi",
            LastName = "Aditya",
            Document_Number = "00100101010",
            BirthDate = new DateTime(2003, 10, 03),
            Sex = 'M'
        };


        [TestMethod]
        public void Citizen_Creation()
        {

            Assert.IsTrue(Fahmi.Id == Guid.Empty);
            Assert.IsTrue(Fahmi.Save());
            Assert.AreEqual(Fahmi.Name, "Fahmi");
            Assert.AreEqual(Fahmi.LastName, "Aditya");
            Assert.AreEqual(Fahmi.Sex, (char)Citizen.SexType.Male);
            Assert.AreEqual(Fahmi.BirthDate, new DateTime(2003, 10, 03));
            Assert.AreEqual(Fahmi.Document_Number, "00100101010");
            Assert.IsTrue(Fahmi.Id != Guid.Empty);
        }

        [TestMethod]
        public void Citizen_Age()
        {
            Assert.IsTrue(Fahmi.Age() >= 20);
        }

        [TestMethod]
        public void Citizen_Adult()
        {
            Assert.IsTrue(Fahmi.IsAdult());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Citizen_Should_Throw_Invalid_Sex()
        {
            Fahmi.Sex = 'Y';
        }

        [TestMethod, ExpectedException(typeof(Exception), "Invalid blank document number")]
        public void Citizen_Should_Throw_Invalid_Document_Number()
        {
            Fahmi.Document_Number = "This is my document Number";
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Citizen_Should_Throw_Incomplete_Document_Number()
        {
            Fahmi.Document_Number = "1234567891";
        }

    }
}
