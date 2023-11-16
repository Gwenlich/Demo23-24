using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Filters;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Todo.UITests
{

    public class TodoUITests
    {
        IWebDriver _webDriver;

        public TodoUITests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            _webDriver = new ChromeDriver(options);
        }

        public void Dispose() { _webDriver.Quit(); }

        [Fact]
        public void NoDataClickRegisterShows2Errors()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:7095/Identity/Account/Register");
            Thread.Sleep(200);
            IWebElement registerButton = _webDriver.FindElement(By.TagName("button"));
            registerButton.Click();
            IWebElement inputEmailErrorField = _webDriver.FindElement(By.Id("input_email-error"));
            IWebElement inputPasswordErrorField = _webDriver.FindElement(By.Id("input_Password-error"));
            inputEmailErrorField.Displayed.Should().BeTrue();
            inputPasswordErrorField.Displayed.Should().BeTrue();
            inputEmailErrorField.Text.Should().NotBeEmpty();
            inputPasswordErrorField.Text.Should().NotBeEmpty();
        }

        [Fact]
        public void FillInWrongDataShows3ErrorsOnClickRegister()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:7095/Identity/Account/Register");
            Thread.Sleep(1000);

            IWebElement passwordField = _webDriver.FindElement(By.Name("Input.Password"));
            IWebElement confirmPasswordField = _webDriver.FindElement(By.Name("Input.ConfirmPassword"));
            IWebElement emailField = _webDriver.FindElement(By.Name("Input.Email"));

            emailField.SendKeys("Demo" + Keys.Enter);
            passwordField.SendKeys("Demo" + Keys.Enter);
            confirmPasswordField.SendKeys("omed" + Keys.Enter);

            IWebElement inputEmailErrorField = _webDriver.FindElement(By.Id("input_email-error"));
            IWebElement inputPasswordErrorField = _webDriver.FindElement(By.Id("input_Password-error"));
            IWebElement inputConfirmPasswordErrorField = _webDriver.FindElement(By.Id("input_ConfirmPassword-error"));

            inputConfirmPasswordErrorField.Displayed.Should().BeTrue();
            inputEmailErrorField.Displayed.Should().BeTrue();
            inputPasswordErrorField.Displayed!.Should().BeTrue();

        }
    }
}