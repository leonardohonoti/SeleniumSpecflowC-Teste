﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TstBNB.Utility;

namespace TstBNB.Hooks
{
    [Binding]
    public sealed class Hooks :ExtentReport
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container) 
        { 
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario("")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Rodando antes do cenário...");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //driver.Navigate().GoToUrl("file:///C:/Users/Basis/AppData/Local/Temp/Rar$EXa27500.13932/TST/teste-1.html");

            _container.RegisterInstanceAs<IWebDriver>(driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Rodar depois de cenário...");
            var driver = _container.Resolve<IWebDriver>();

            string screenshotName = addScreenshot(driver, scenarioContext);
            _scenario.Info("Screenshot final do cenário",
                MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotName).Build());

            if (driver != null)
            { 
                driver.Quit();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Rodar depois do passo....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}