using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Teste_Exemplo.Exemplo.Pages;
using Teste_Exemplo.Exemplo.Utils;

namespace Teste_Exemplo
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        public LoginSteps(IWebDriver driver) => _driver = driver;
        
        private LoginPage loginPage;
             
        [Given(@"o acesso ao site")]
        public void GivenOAcessoAoSite()
        {
            loginPage = new LoginPage(_driver);            
        }

        [When(@"os dados de login cadastrado são informados")]
        public void WhenOsDadosDeLoginCadastradoSaoInformados()
        {
            loginPage.Login("admin", "admin");
        }

        [Then(@"o formulário do usuário deve ser exibido")]
        public void ThenOFormularioDoUsuarioDeveSerExibido()
        {
            loginPage.ValidaExibicaoFormulario();
        }
    }
}
