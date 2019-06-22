using Business.PageObjects;
using Business.TestBases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.SetUp
{
    [SetUpFixture]
    public class SetUpClass: TestBase
    {                
            [SetUp]
            public void RunBeforeAnyTests()
            {
                BasePageObject.Login.SignIn("LogInCorrectCreds");
            }

            [TearDown]
            public void RunAfterAnyTests()
            {
                BasePageObject.Main.LogOut();
            }
    }
}
