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

        [When(@"Entro na segunda tela de cadastro de produto")]
        public void WhenEntroNaSegundaTelaDeCadastroDeProduto()
        {
            driver.Url = "file:///C:/Users/Basis/AppData/Local/Temp/Rar$EXa27500.15782/TST/teste-2.html";
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



