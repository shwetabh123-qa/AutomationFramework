
using AutomationFramework.BaseClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.TestScripts
{

    [TestClass]
    public class Author

    {

        public static DriverAndLoginDto DriverAndLogin;
        public TestContext TestContext { get; set; }

        private static TestContext _testContext;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _testContext = context;
            DriverAndLogin = new DriverAndLoginDto
            {
                Url = context.Properties["Url"].ToString(),
                Browser = context.Properties["Browser"].ToString(),
                Username = context.Properties["Username"].ToString(),
                Password = context.Properties["Password"].ToString(),
                Account = context.Properties["Account"].ToString()
            };

        }


        [TestMethod]
        public void VerifytheHiddenQuestionshowninActualPlayer()
        {

            IWebDriver driver = BaseClasses.GetWebDriver(DriverAndLogin.Browser, DriverAndLogin.Url);



        }
    }
}
