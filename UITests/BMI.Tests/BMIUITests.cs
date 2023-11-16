using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BMI.UITests
{
    public class BMIUITests
    {
        IWebDriver _webDriver;

        public BMIUITests() { _webDriver = new ChromeDriver(); }

        public void Dispose() { _webDriver.Quit(); }
        [Fact]
        public void OnInitialLoadCalculateButtonIsDisabled()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:7020");
            Thread.Sleep(1000);
            IWebElement calculateButton = _webDriver.FindElement(By.TagName("button"));
            calculateButton.Enabled.Should().BeFalse();

            /*Thread.Sleep(1000);
            webDriver.FindElement(By.PartialLinkText("Opleidingen")).Click();*/
        }

        [Fact]
        public void WhenFieldsFilledInCalculateButtonIsEnabled()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:7020");
            Thread.Sleep(1000);
            IWebElement heightField = _webDriver.FindElement(By.Name("height"));
            IWebElement weightField = _webDriver.FindElement(By.Name("weight"));
            IWebElement calculateButton = _webDriver.FindElement(By.TagName("button"));

            heightField.SendKeys("180");
            weightField.SendKeys("80");

            calculateButton.Enabled.Should().BeTrue();

        }
    }
}