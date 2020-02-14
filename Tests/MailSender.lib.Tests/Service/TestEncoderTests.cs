using MailSenderLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;



namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class TestEncoderTests
    {
        static TestEncoderTests ()
        {

        }

        public TestEncoderTests()
        {

        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext Context)
        {

        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext Context)
        {

        }

        [TestInitialize]
        public static void TestInitialize(TestContext Context)
        {

        }

        [TestCleanup]
        public static void TestCleanup(TestContext Context)
        {

        }

        [ClassCleanup]
        public static void ClassCleanup(TestContext Context)
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup(TestContext Context)
        {

        }

        [TestMethod]
        public  void Encode_ABC_to_BCD_with_key_1()
        {
            //A-A-A = Arrange - Act - Assert


            #region arrange
            const string str = "ABC";
            const string expected_str = "BCD";
            const int key = 1;
            #endregion

            #region act
            var actual_str = PassCrypter.Encrypt(str,key);
            #endregion

            #region assert
            Assert.AreEqual(expected_str, actual_str);
            #endregion
        }
        [TestMethod]
        public void Decode_BCD_to_ABC_with_key_1()
        {
            //A-A-A = Arrange - Act - Assert


            #region arrange
            const string str = "BCD";
            const string expected_str = "ABC";
            const int key = 1;
            #endregion

            #region act
            var actual_str = PassCrypter.Decrypt(str, key);
            #endregion

            #region assert
            Assert.AreEqual(expected_str, actual_str);
            #endregion
        }
    }
}
