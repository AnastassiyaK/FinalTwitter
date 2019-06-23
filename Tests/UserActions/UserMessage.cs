using Business.PageObjects;
using Business.TestBases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.SetUp;

namespace Tests.UserActions
{
    [TestFixture]
    class UserMessage: SetUpClass
    {
        [Test]
        [Order(1)]
        public void SendMessage()
        {
            List<string> methods = new List<string>();
            methods.Add("LoginUSer1");
            methods.Add("LoginUSer2");

            //string method = "LogInUser";
            BasePageObject.Message.SendMessage("TestMessage",methods);
            //Assert.IsTrue(BasePageObject.Login.LogInPageOpened(), "LogIn page is not opened");

        }

    }
}
