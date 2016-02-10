using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Keys = OpenQA.Selenium.Keys;

namespace SeleniumDemo
{
    public partial class Twitter : Form
    {
        public Twitter()
        {
            InitializeComponent();
        }

        private readonly IWebDriver m_WebDriver = new FirefoxDriver();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                m_WebDriver.Navigate().GoToUrl("https://twitter.com/");

                m_WebDriver.Manage().Window.Maximize();

                IWebElement username = m_WebDriver.FindElement(By.Id("signin-email"));
                IWebElement password = m_WebDriver.FindElement(By.Id("signin-password"));

                username.SendKeys(tbUsername.Text.Trim());
                password.SendKeys(tbPassword.Text.Trim());

                m_WebDriver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);

                Screenshot ss = ((ITakesScreenshot)m_WebDriver).GetScreenshot();
                ss.SaveAsFile("c:/login.png", System.Drawing.Imaging.ImageFormat.Png);

                Thread.Sleep(2000);
                Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                m_WebDriver.Navigate().GoToUrl("https://twitter.com/");

                m_WebDriver.Manage().Window.Maximize();

                IWebElement fullName = m_WebDriver.FindElement(By.Name("user[name]"));
                IWebElement username = m_WebDriver.FindElement(By.Name("user[email]"));
                IWebElement password = m_WebDriver.FindElement(By.Name("user[user_password]"));

                fullName.SendKeys(tbFullname.Text.Trim());
                username.SendKeys(tbUsername.Text.Trim());
                password.SendKeys(tbPassword.Text.Trim());

                m_WebDriver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);

                m_WebDriver.SwitchTo().Window(m_WebDriver.WindowHandles.Last());

                IWebElement signUp = m_WebDriver.FindElement(By.Id("submit_button"));
                Thread.Sleep(2000);
                signUp.Click();
             
                Thread.Sleep(1000);

                Screenshot ss = ((ITakesScreenshot)m_WebDriver).GetScreenshot();
                ss.SaveAsFile("c:/signup.png", System.Drawing.Imaging.ImageFormat.Png);

                Thread.Sleep(1000);
                
                m_WebDriver.Close();
              
                Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Clear()
        {
            tbUsername.Text = string.Empty;
            tbFullname.Text = string.Empty;
            tbPassword.Text = string.Empty;
        }

    }
}
