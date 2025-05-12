using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TstBNB.Pages
{
    public class CadastroProdutoPage
    {
        private IWebDriver driver;

        public CadastroProdutoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By campoNomeProduto = By.XPath("//*[@name='nome']");

        By campoPrecoProduto = By.XPath("//*[@name='preco']");

        By campoDataValidadeProduto = By.XPath("//*[@name='validade']");

        By botaoAdicionar = By.XPath("//button[text()='Adicionar']");

        By produtoAdicionadoSemDados = By.XPath("//tbody[contains(., '1')]");

        By nomeProdutoAdicionado = By.XPath("//td[contains(., 'agua')]");

        By msgErroNomeInvalido = By.XPath("(//*[contains(., 'Nome invalido')])[10]");

        By msgErroPrecoInvalido = By.XPath("(//*[contains(., 'Preço invalido')])[10]");

        By msgErroValidadeInvalida = By.XPath("(//*[contains(., 'Validade Invalida')])[10]");


        public void DigitarNomeProduto(string nome)
        {
            driver.FindElement(campoNomeProduto).SendKeys(nome);
        }

        public void DigitarPrecoProduto(string preco)
        {
            driver.FindElement(campoPrecoProduto).SendKeys(preco);
        }

        public void DigitarDataValidadeProduto(string validade)
        {
            driver.FindElement(campoDataValidadeProduto).SendKeys(validade);
        }

        public void ClicarBotaoAdicionar()
        {
            driver.FindElement(botaoAdicionar).Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public string ValidarNomeProdutoAdicionado(string nome)
        {
            return driver.FindElement(nomeProdutoAdicionado).Text;
        }

        public string ValidarMensagemErroNomeProduto(string nomeInvalido)
        {
            return driver.FindElement(msgErroNomeInvalido).Text;
        }

        public string ValidarMensagemErroPrecoProduto(string precoInvalido)
        {
            return driver.FindElement(msgErroPrecoInvalido).Text;
        }

        public string ValidarMensagemErroDataValidadeProduto(string validadeInvalida)
        {
            return driver.FindElement(msgErroValidadeInvalida).Text;
        }

        public string ValidarProdutoAdicionadoSemDados(string item1)
        {
            return driver.FindElement(produtoAdicionadoSemDados).Text;
        }
    }
}
    
