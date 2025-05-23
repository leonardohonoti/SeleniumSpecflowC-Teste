﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace TstBNB.Utility
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");


        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Reporte";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "TestBNB");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            {
                // Garante que a pasta TestResults exista
                if (!Directory.Exists(testResultPath))
                    Directory.CreateDirectory(testResultPath);

                // Cria nome seguro e único para o arquivo
                string safeTitle = string.Concat(scenarioContext.ScenarioInfo.Title.Split(Path.GetInvalidFileNameChars()));
                string fileName = $"{safeTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string screenshotLocation = Path.Combine(testResultPath, fileName);

                // Captura e salva a imagem
                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                Screenshot screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);

                // Retorna apenas o nome do arquivo (relativo à pasta do relatório)
                return fileName;
            }
        }
    }
}
