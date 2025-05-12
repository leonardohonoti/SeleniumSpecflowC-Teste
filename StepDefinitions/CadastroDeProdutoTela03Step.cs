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

        [When(@"Entro na terceira tela de cadastro de produto")]
        public void WhenEntroNaTerceiraTelaDeCadastroDeProduto()
        {
            driver.Url = "file:///C:/Users/Basis/AppData/Local/Temp/Rar$EXa27500.16181/TST/teste-3.html";
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

