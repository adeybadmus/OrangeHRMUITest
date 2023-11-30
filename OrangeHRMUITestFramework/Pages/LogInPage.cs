using OpenQA.Selenium;
using OrangeHRMUIAutomation.Hooks;

namespace OrangeHRMUIAutomation.Pages
{
    public class LogInPage
    {
        private readonly IWebDriver driver;
        private readonly string usernameData = EnvironmentData.Username;
        private readonly string passwordData = EnvironmentData.Password;
        string blankData = " ";

        private readonly By username = By.CssSelector("input[name='txtUsername']");
        private readonly By usernameErrorMessage = By.CssSelector("input[name='txtUsername-error']");
        private readonly By password = By.CssSelector("input[name='txtPassword']");
        private readonly By passwordErrorMessage = By.CssSelector("input[name='txtPassword-error']");
        private readonly By rememberMeCheckbox = By.CssSelector("input[name='rememberMe']");
        private readonly By loginButton = By.CssSelector("div button[type='submit']");
        private readonly By invalidCredentialsErrorMessage = By.CssSelector("#toast-container > div > div");

        public LogInPage(IWebDriver _driver)
        {
            driver = _driver;
        }


        public void FillValidUsername()
        {
            driver.ClearAndSendKeys(username, usernameData);
        }

        public void FillValidPassword()
        {
            driver.ClearAndSendKeys(password, passwordData);
        }

        public void FillBlankUsername()
        {
            driver.ClearAndSendKeys(password, blankData);
        }

        public void FillBlankPassword()
        {
            driver.ClearAndSendKeys(password, blankData);
        }

        public void ClickLoginButton()
        {
            driver.Click(loginButton);
        }

        public void FillInValidUsername()
        {
            driver.ClearAndSendKeys(password, WebDriverExtension.RandomUsername());
        }

        public void FillInValidPassword()
        {
            driver.ClearAndSendKeys(password, WebDriverExtension.RandomPassword());
        }

        public string VerifyUserLogin()
        {
            return driver.Url;
        }

        public void CheckRememberMeCheckBox()
        {
            driver.Click(rememberMeCheckbox);
        }

        public string ReturnInvalidCredentialsErrorMessage()
        {
            return driver.GetElementText(invalidCredentialsErrorMessage);
        }

        public string ReturnUserNameErrorMessage()
        {
            return driver.GetElementText(usernameErrorMessage);
        }

        public string ReturnPasswordErrorMessage()
        {
            return driver.GetElementText(passwordErrorMessage);
        }
    }
}
