using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TstBNB.Pages;

namespace TstBNB.StepDefinitions
{
    [Binding]
    public sealed class CadastroDeProdutoTela01
    {
        private IWebDriver driver;
        CadastroProdutoPage cadastroProdutoPage;

        public CadastroDeProdutoTela01(IWebDriver driver)
        {
            this.driver = driver;
            cadastroProdutoPage = new CadastroProdutoPage(driver);
        }

        [Given(@"Entro na tela de cadastro de produto")]
        public void GivenEntroNaTelaDeCadastroDeProduto()
        {
            driver.Url = "file:///C:/Users/Basis/AppData/Local/Temp/Rar$EXa27500.13932/TST/teste-1.html";
            Thread.Sleep(1000);
        }

        [When(@"Digito o nome do produto ""([^""]*)""")]
        public void WhenDigitoONomeDoProduto(string nome)
        {
            cadastroProdutoPage.DigitarNomeProduto(nome);
        }

        [When(@"digito o preço do produto ""([^""]*)""")]
        public void WhenDigitoOPrecoDoProduto(string preco)
        {
            cadastroProdutoPage.DigitarPrecoProduto(preco);
        }

        [When(@"digito a data de validade ""([^""]*)""")]
        public void WhenDigitoADataDeValidade(string validade)

        {
            cadastroProdutoPage.DigitarDataValidadeProduto(validade);
        }

        [When(@"clico em adicionar")]
        public void WhenClicoEmAdicionar()
        {
            cadastroProdutoPage.ClicarBotaoAdicionar();
            Thread.Sleep(2000);
        }

        [Then(@"Verifico que o produto foi adicionado sem dados como intem ""([^""]*)""")]
        public void ThenVerificoQueOProdutoFoiAdicionadoSemDadosComoIntem(string item1)
        {
            String validarItem = cadastroProdutoPage.ValidarProdutoAdicionadoSemDados(item1);
            validarItem.Contains(item1);
        }

        [Then(@"Verifico que o produto ""([^""]*)"" foi adicionado")]
        public void ThenVerificoQueOProdutoFoiAdicionado(string nome)
        {
            String validarTexto = cadastroProdutoPage.ValidarNomeProdutoAdicionado(nome);
            validarTexto.Contains(nome);
        }
    }
}




