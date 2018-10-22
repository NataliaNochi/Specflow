using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;
using Teste_Exemplo.Exemplo.Enum;

namespace Teste_Exemplo.Exemplo.Utils
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        private EnumNavegador _browser;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeTest()
        {
            var browser = TestContext.Parameters.Get("Browser", "Chrome");
            _browser = (EnumNavegador)System.Enum.Parse(typeof(EnumNavegador), browser);
            SelecionarBrowser(_browser);

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
        }

        [AfterScenario]
        public void Quit()
        {
            _driver.Quit();
        }

        public void SelecionarBrowser(EnumNavegador navegador)
        {
            switch (navegador)
            {
                case EnumNavegador.Chrome:
                    _driver = new ChromeDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;

                case EnumNavegador.Firefox:
                    _driver = new FirefoxDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;

                case EnumNavegador.IE:
                    _driver = new InternetExplorerDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;

                case EnumNavegador.Edge:
                    _driver = new EdgeDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;

                case EnumNavegador.Chrome_Headless:
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--headless");
                    _driver = new ChromeDriver(option);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
            }
        }
    }
}
