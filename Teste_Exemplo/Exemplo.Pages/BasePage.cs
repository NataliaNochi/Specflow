using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

using Teste_Exemplo.Exemplo.Enum;

namespace Teste_Exemplo.Exemplo.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        public BasePage(IWebDriver driver) => _driver = driver;

        public IWebElement ObterElemento(string nomeElemento, EnumTipoElemento tipoElemento)
        {
            IWebElement elemento = null;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            switch (tipoElemento)
            {
                case EnumTipoElemento.Id:
                    elemento = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(nomeElemento)));
                    break;

                case EnumTipoElemento.Class:
                    elemento = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(nomeElemento)));
                    break;

                case EnumTipoElemento.Name:
                    elemento = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nomeElemento)));
                    break;

                case EnumTipoElemento.Css:
                    elemento = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(nomeElemento)));
                    break;

                case EnumTipoElemento.Xpath:
                    elemento = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(nomeElemento)));
                    break;

                case EnumTipoElemento.LinkText:
                    elemento = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(nomeElemento)));
                    break;
            }
            Assert.IsNotNull(elemento);
            return elemento;
        }
    }
}
