using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TstBNB.Pages;

namespace TstBNB.StepDefinitions
{
    [Binding]
    public sealed class CadastroDeProdutoTela02
    {
        private IWebDriver driver;
        CadastroProdutoPage cadastroProdutoPageTela01;

        public CadastroDeProdutoTela02(IWebDriver driver)
        {
            this.driver = driver;
            cadastroProdutoPageTela01 = new CadastroProdutoPage(driver);
        }

        [Given(@"Entro na segunda tela de cadastro de produto")]
        public void GivenEntroNaSegundaTelaDeCadastroDeProduto()
        {
            driver.Url = "file:///C:/SpecFlow/TstBNB/test_files/teste-2.html";
            Thread.Sleep(1000);
        }

        [Then(@"Vejo a mensagem no campo nome ""([^""]*)""")]
        public void ThenVejoAMensagemNoCampoNome(string nomeInvalido)
        {
            String validarTexto = cadastroProdutoPageTela01.ValidarMensagemErroNomeProduto(nomeInvalido);
            validarTexto.Contains(nomeInvalido);
        }

        [Then(@"Vejo a mensagem no campo preço ""([^""]*)""")]
        public void ThenVejoAMensagemNoCampoPreco(string precoInvalido)
        {
            String validarTexto = cadastroProdutoPageTela01.ValidarMensagemErroPrecoProduto(precoInvalido);
            validarTexto.Contains(precoInvalido);
        }

        [Then(@"Vejo a mensagem no campo Validade ""([^""]*)""")]
        public void ThenVejoAMensagemNoCampoValidade(string validadeInvalida)
        {
            String validarTexto = cadastroProdutoPageTela01.ValidarMensagemErroDataValidadeProduto(validadeInvalida);
            validarTexto.Contains(validadeInvalida);
        }

    }
}


