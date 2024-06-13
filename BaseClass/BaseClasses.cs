using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using log4net;
using OpenQA.Selenium.Remote;


namespace AutomationFramework.BaseClass
{


    [TestClass]
    public  class BaseClasses
    {

      
       


        public static FirefoxProfile GetFirefoxptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();

         
           // Logger.Info(" Using Firefox Profile ");


            return profile;
        }

        public static FirefoxOptions GetOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions options = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,

            };
            return options;
        }
        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddArgument("--headless");
            //option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
      //      Logger.Info(" Using Chrome Options ");
            return option;
        }

        public static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
    //        Logger.Info(" Using Internet Explorer Options ");
            return options;
        }


        public static FirefoxDriver GetFirefoxDriver( )
        {
            //FirefoxOptions options = new FirefoxOptions();
            //FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());

            FirefoxOptions option = new FirefoxOptions();
            ICapabilities cap = option.ToCapabilities();

            FirefoxProfileManager mangage = new FirefoxProfileManager();
            FirefoxProfile profile = mangage.GetProfile(mangage.ExistingProfiles[0]);

            FirefoxDriver driver = new FirefoxDriver(); ;


            return driver;
        }

        public static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        public static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }

        //private static PhantomJSDriver GetPhantomJsDriver()
        //{
        //    PhantomJSDriver driver = new PhantomJSDriver(GetPhantomJsDrvierService());

        //    return driver;
        //}

        //private static PhantomJSOptions GetPhantomJsptions()
        //{
        //    PhantomJSOptions option = new PhantomJSOptions();
        //    option.AddAdditionalCapability("handlesAlerts", true);
        //    Logger.Info(" Using PhantomJS Options  ");
        //    return option;
        //}

        //private static PhantomJSDriverService GetPhantomJsDrvierService()
        //{
        //    PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
        //    service.LogFile = "TestPhantomJS.log";
        //    service.HideCommandPromptWindow = false;
        //    service.LoadImages = true;
        //    Logger.Info(" Using PhantomJS Driver Service  ");
        //    return service;
        //}


        public static RemoteWebDriver getDriver(String browser)
        {
            DesiredCapabilities Capabilities = new DesiredCapabilities();

            Capabilities.SetCapability(CapabilityType.BrowserName, "firefox");

            string GridURL = "http://localhost:4444/wd/hub";

            return new RemoteWebDriver(new Uri(GridURL), Capabilities);
        }

       

   
        public static IWebDriver GetWebDriver(String browser, string url)
        {

            IWebDriver driver = null;
            switch (browser)
            {
                case "Firefox":


                    driver = GetFirefoxDriver();
                    break;
                case "IE":
                    driver = GetIEDriver();
                    break;

                case "Chrome":

                    driver = GetChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }


            //ObjectRepository.Config = new AppConfigReader();
            //Reporter.GetReportManager();
            //Reporter.AddTestCaseMetadataToHtmlReport(tc);
            //switch (ObjectRepository.Config.GetBrowser())
            //{
            //    case BrowserType.Firefox:
            //        ObjectRepository.Driver = GetFirefoxDriver();
            //        Logger.Info(" Using Firefox Driver  ");

            //        break;

            //    case BrowserType.Chrome:
            //        ObjectRepository.Driver = GetChromeDriver();
            //        Logger.Info(" Using Chrome Driver  ");
            //        break;

            //    case BrowserType.IExplorer:
            //        ObjectRepository.Driver = GetIEDriver();
            //        Logger.Info(" Using Internet Explorer Driver  ");
            //        break;

            //    case BrowserType.PhantomJs:
            //        ObjectRepository.Driver = GetPhantomJsDriver();
            //        Logger.Info(" Using PhantomJs Driver  ");
            //        break;

            //    default:
            //        throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            //}
            //ObjectRepository.Driver.Manage()
            //    .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            //ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            //BrowserHelper.BrowserMaximize();






        }


        //[AssemblyCleanup]
        ////[AfterScenario()]
        //public static void TearDown()
        //{
        //    //if (ObjectRepository.Driver != null)
        //    //{
        //    //    ObjectRepository.Driver.Close();
        //    //    ObjectRepository.Driver.Quit();
        //    //}
        //    //Logger.Info(" Stopping the Driver  ");
        //}
    }



