using NUnit.Framework;
using Project1.Application.API;
using Project1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEventStore;
using BCrypt.Net;
using Project1.Application.API.Helpers;

namespace Project1.Test.ApplicationAPI
{
    [TestFixture]
    public class APICommonTests
    {
        [Test]
        public void BCrypt_Test()
        {
            string myPassword = "password";
  
            string hash = Hashing.HashPassword(myPassword);
            
            Assert.IsTrue(Hashing.ValidatePassword(myPassword, hash));
        }

        [Test]
        public void BCrypt_IsDifferentHash_Test()
        {
            string myPassword = "1";

            string hash1 = Hashing.HashPassword(myPassword);
            string hash2 = Hashing.HashPassword(myPassword);

            Assert.AreNotEqual(hash1, hash2);
        }

        [Test]
        public void BCrypt_OnePassword_TwoHash_Test()
        {
            string myPassword = "1";

            string hash1 = Hashing.HashPassword(myPassword);
            string hash2 = Hashing.HashPassword(myPassword);

            Assert.IsTrue(Hashing.ValidatePassword(myPassword, hash1));
            Assert.IsTrue(Hashing.ValidatePassword(myPassword, hash2));
        }

        //[Test]
        //public void RabbitUri_Test()
        //{
        //    var nEventStoreConfig = new Startup();


        //}
    }
}
