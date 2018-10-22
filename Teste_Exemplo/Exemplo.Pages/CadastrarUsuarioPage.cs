
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Teste_Exemplo.Exemplo.Details;
using Teste_Exemplo.Exemplo.Enum;
using Teste_Exemplo.Exemplo.Utils;

namespace Teste_Exemplo.Exemplo.Pages
{
    public class CadastrarUsuarioPage
    {
        private IWebDriver _driver;
        public CadastrarUsuarioPage(IWebDriver driver) => _driver = driver;

        private BasePage basePage;

        public void AcessarMenuUsuario()
        {
            basePage = new BasePage(_driver);

            IWebElement menuUserForm = basePage.ObterElemento("#cssmenu > ul > li:nth-child(3) > a > span", EnumTipoElemento.Css);
            menuUserForm.Click();
        }

        public void CadastrarUsuario(Table dadosUsuario)
        {

            var usuario = dadosUsuario.CreateSet<CadastroUsuarioDetails>();
            foreach (var dado in usuario)
            {
                SelectElement cbxTitulo = new SelectElement(basePage.ObterElemento("TitleId", EnumTipoElemento.Name));
                cbxTitulo.SelectByText(dado.Titulo);

                IWebElement txtNome = basePage.ObterElemento("FirstName", EnumTipoElemento.Id);
                txtNome.SendKeys(dado.Nome);

                if (dado.Genero == "Female")
                {
                    IWebElement rbnGenero = basePage.ObterElemento("Female", EnumTipoElemento.Name);
                    rbnGenero.Click();
                }
                else if (dado.Genero == "Male")
                {
                    IWebElement rbnGenero = basePage.ObterElemento("Male", EnumTipoElemento.Name);
                    rbnGenero.Click();
                }
                else
                    throw new Exception("Genêro informado inválido: " + dado.Genero);

                IWebElement btnGerarUsuario = basePage.ObterElemento("generate", EnumTipoElemento.Name);
                btnGerarUsuario.Click();
            }
        }

        public void ValidarExibicaoPopUp()
        {
            var alert = _driver.SwitchTo().Alert().Text;
            Assert.IsTrue(alert.Equals("You generated a Javascript alert"));
        }
    }
}
