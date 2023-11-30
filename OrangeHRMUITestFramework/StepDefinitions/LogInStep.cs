﻿using NUnit.Framework;
using OrangeHRMUIAutomation.Pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace OrangeHRMUIAutomation.StepDefinitions
{
    [Binding]
    public class LogInSteps
    {
        private LogInPage loginPage;
        

        public LogInSteps(LogInPage _loginpage)
        {
            loginPage = _loginpage;
        }


        [When(@"a user fill valid Username and Password data")]
        public void WhenAUserFillValidUsernameAndPasswordData()
        {
            loginPage.FillValidUsername();
            loginPage.FillValidPassword();

        }

        [When(@"a user clicks on login button")]
        public void WhenAUserClicksOnLoginButton()
        {
             loginPage.ClickLoginButton();
        }

        [Then(@"the user should login")]
        public void ThenTheUserShouldLogin()
        {
            Thread.Sleep(2000);
            string actualResult = loginPage.VerifyUserLogin();
            string expectedResult = ($"{EnvironmentData.BaseUrl}/client/#/dashboard");
            Assert.AreEqual(expectedResult, actualResult);
        }


        [When(@"a user checks the remember me checkbox")]
        public void WhenAUserChecksTheRememberMeCheckbox()
        {
            loginPage.CheckRememberMeCheckBox();
        }

        [When(@"a user fill Login page with (.*) and (.*) data")]
        public void WhenAUserFillLoginPageWithValidAndInvalidData(string username, string password)
        {
            if (username.Equals("valid"))
            {
                loginPage.FillValidUsername();
            }
            else if (username.Equals("invalid"))
            {
                loginPage.FillInValidUsername();
            }
            else if (username.Equals(""))
            {
                loginPage.FillBlankUsername();
            }

            if (password.Equals("valid"))
            {
                loginPage.FillValidPassword();
            }
            else if (password.Equals("invalid"))
            {
                loginPage.FillInValidPassword();
            }
            else if (password.Equals(""))
            {
                loginPage.FillBlankPassword();
            }
        }
            

        [Then(@"a error message (.*) should be displayed")]
        public void ThenAErrorMessageShouldBeDisplayed(string expectedErrorMessage)
        {
            //Thread.Sleep(1000);
            string actualErrorMessage = string.Empty;

            switch (expectedErrorMessage)
            {
                case "Invalid Credentials":
                    actualErrorMessage = loginPage.ReturnInvalidCredentialsErrorMessage();
                    break;

                case "Username cannot be empty":
                    actualErrorMessage = loginPage.ReturnUserNameErrorMessage();
                    break;

                case "Password cannot be empty":
                    actualErrorMessage = loginPage.ReturnPasswordErrorMessage();
                    break;
            }

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, $"{expectedErrorMessage} is not equal to {actualErrorMessage}");
        }
    }
}
