using System;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumDemo.Test
{
    [TestFixture]
    public class TwitterFixture
    {
        private IWebDriver m_Driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            m_Driver = new FirefoxDriver();
            baseURL = "https://twitter.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                m_Driver.Quit();
            }
            catch (Exception)
            {

            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void LoginWhenParamIsValid()
        {
            m_Driver.Navigate().GoToUrl(baseURL);
            m_Driver.FindElement(By.Id("signin-email")).Clear();
            m_Driver.FindElement(By.Id("signin-email")).SendKeys("test35@gmail.com");
            m_Driver.FindElement(By.Id("signin-password")).Clear();
            m_Driver.FindElement(By.Id("signin-password")).SendKeys("147852");
            m_Driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);

            Assert.AreEqual("", m_Driver.Title);
        }

        [Test]
        public void LoginWhenParamIsNotValid()
        {
            m_Driver.Navigate().GoToUrl(baseURL);
            m_Driver.FindElement(By.Id("signin-email")).Clear();
            m_Driver.FindElement(By.Id("signin-email")).SendKeys("test35@gmail.com");
            m_Driver.FindElement(By.Id("signin-password")).Clear();
            m_Driver.FindElement(By.Id("signin-password")).SendKeys("123456");
            m_Driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);

            Assert.AreEqual("Twitter'dan Giriş yap", m_Driver.Title);
        }

        [Test]
        public void SignUpWhenParamIsValid()
        {
            m_Driver.Navigate().GoToUrl(baseURL);

            m_Driver.FindElement(By.Name("user[name]")).Clear();
            m_Driver.FindElement(By.Name("user[name]")).SendKeys("testest3555");
            m_Driver.FindElement(By.Name("user[email]")).Clear();
            m_Driver.FindElement(By.Name("user[email]")).SendKeys("test355@gmail.com");
            m_Driver.FindElement(By.Name("user[user_password]")).Clear();
            m_Driver.FindElement(By.Name("user[user_password]")).SendKeys("147852");

            m_Driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);

            m_Driver.SwitchTo().Window(m_Driver.WindowHandles.Last());

            IWebElement signUp = m_Driver.FindElement(By.Id("submit_button"));
            Thread.Sleep(2000);
            signUp.Click();

            Thread.Sleep(1000);

            m_Driver.Close();

            Assert.AreEqual("Telefon numaranı gir", m_Driver.Title);
        }

        [Test]
        public void SignUpWhenParamIsNotValid()
        {
            m_Driver.Navigate().GoToUrl(baseURL);

            m_Driver.FindElement(By.Name("user[name]")).Clear();
            m_Driver.FindElement(By.Name("user[name]")).SendKeys(string.Empty);
            m_Driver.FindElement(By.Name("user[email]")).Clear();
            m_Driver.FindElement(By.Name("user[email]")).SendKeys("test355@gmail.com");
            m_Driver.FindElement(By.Name("user[user_password]")).Clear();
            m_Driver.FindElement(By.Name("user[user_password]")).SendKeys("147852");

            m_Driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);

            Assert.AreEqual("Twitter'a kaydol", m_Driver.Title);
        }
    }
}