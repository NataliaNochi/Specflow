using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Teste_Exemplo.Exemplo.Enum;
using Teste_Exemplo.Exemplo.Utils;

namespace Teste_Exemplo.Exemplo.Pages
{
    public class LoginPage 
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver) => _driver = driver;

        public BasePage basePage;

        public void Login(string user, string password)
        {
            basePage = new BasePage(_driver);

            IWebElement txtUserName = basePage.ObterElemento("UserName", EnumTipoElemento.Name);
            txtUserName.Click();
            txtUserName.SendKeys(user);

            IWebElement txtPassword = basePage.ObterElemento("Password", EnumTipoElemento.Name);
            txtPassword.SendKeys(password);

            IWebElement btnLogin = basePage.ObterElemento("Login", EnumTipoElemento.Name);
            btnLogin.Submit();
        }

        public void ValidaExibicaoFormulario()
        {
            IWebElement frmUser = basePage.ObterElemento("details", EnumTipoElemento.Id);
            Assert.True(frmUser.Displayed);
        }
    }
}
