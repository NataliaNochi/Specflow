using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Teste_Exemplo.Exemplo.Pages;

namespace Teste_Exemplo.Exemplo.Steps
{
    [Binding]
    public class CadastrarUsuarioSteps
    {
        private readonly IWebDriver _driver;
        public CadastrarUsuarioSteps(IWebDriver driver) => _driver = driver;

        private CadastrarUsuarioPage cadastrarUsuarioPage;

        [Given(@"o login no sistema")]
        public void DadoOLoginNoSistema()
        {
            LoginPage login = new LoginPage(_driver);
            login.Login("admin", "admin");
        }

        [Given(@"o acesso ao cadastro de usuários")]
        public void DadoOAcessoAoCadastroDeUsuarios()
        {
            cadastrarUsuarioPage = new CadastrarUsuarioPage(_driver);
            cadastrarUsuarioPage.AcessarMenuUsuario();
        }

        [When(@"os dados do usuário preenchidos são salvos")]
        public void QuandoOsDadosDoUsuarioPreenchidosSaoSalvos(Table dadosUsuario)
        {
            cadastrarUsuarioPage.CadastrarUsuario(dadosUsuario);
        }

        [Then(@"a o pop-up com a mensagem de cadastro com sucesso deve ser exibida")]
        public void EntaoAOPop_UpComAMensagemDeCadastroComSucessoDeveSerExibida()
        {
            cadastrarUsuarioPage.ValidarExibicaoPopUp();
        }
    }
}
