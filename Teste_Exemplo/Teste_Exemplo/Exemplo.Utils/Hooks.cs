using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;
using Teste_Exemplo.Exemplo.Enum;
using Teste_Exemplo.Exemplo.Pages;

namespace Teste_Exemplo.Exemplo.Utils
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeTest()
        {
            Browser(EnumNavegador.Chrome);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
        }
        
        [AfterScenario]
        public void Quit()
        {
            _driver.Quit();
        }

        public void Browser(EnumNavegador navegador)
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

                case EnumNavegador.Edge:
                    _driver = new EdgeDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;

                case EnumNavegador.IE:
                    _driver = new InternetExplorerDriver();
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
            }
        }
    }
}
