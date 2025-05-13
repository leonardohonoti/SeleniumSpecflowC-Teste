using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TstBNB.Pages;

namespace TstBNB.StepDefinitions
{
    [Binding]
    public sealed class CadastroDeProdutoTela03
    {
        private IWebDriver driver;
        CadastroProdutoPage cadastroProdutoPage;

        public CadastroDeProdutoTela03(IWebDriver driver)
        {
            this.driver = driver;
            cadastroProdutoPage = new CadastroProdutoPage(driver);
        }

        [Given(@"Entro na terceira tela de cadastro de produto")]
        public void GivenEntroNaTerceiraTelaDeCadastroDeProduto()
        {
            driver.Url = "file:///C:/SpecFlow/TstBNB/test_files/teste-3.html";
            Thread.Sleep(1000);
        }

        [When(@"digito a data de validade valida ""([^""]*)""")]
        public void WhenDigitoADataDeValidadeValida(string validade)
        {
            cadastroProdutoPage.DigitarDataValidadeProduto(validade);
        }

        [When(@"digito a data de validade invalida ""([^""]*)""")]
        public void WhenDigitoADataDeValidadeInvalida(string validade)
        {
            cadastroProdutoPage.DigitarDataValidadeProduto(validade);
        }
    }
}


