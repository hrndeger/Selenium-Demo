using System;
using System.Linq;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Keys = OpenQA.Selenium.Keys;

namespace SeleniumDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var webDriver = new FirefoxDriver())
                {
                    webDriver.Navigate().GoToUrl("http://yemek.com/");

                    webDriver.Manage().Window.Maximize();
                    IWebElement btn = webDriver.FindElementByClassName("popupLoginButton");
                    btn.Click();

                    webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());

                    //list of inputState css classes
                    var textboxList = webDriver.FindElementsByClassName("inputState");

                    IWebElement username = textboxList[0];
                    IWebElement password = textboxList[1];

                    username.SendKeys(tbEmail.Text.Trim());
                    password.SendKeys(tbPassword.Text.Trim());

                    webDriver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);

                    //Close child window
                    System.Threading.Thread.Sleep(3000);
                    webDriver.Close();

                    webDriver.SwitchTo().DefaultContent();
                    Clear();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var webDriver = new FirefoxDriver())
                {
                    webDriver.Navigate().GoToUrl("http://yemek.com/");

                    webDriver.Manage().Window.Maximize();
                    IWebElement btn = webDriver.FindElementByClassName("popupRegisterButton");
                    btn.Click();

                    webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());

                    //list of inputState css classes
                    var textboxList = webDriver.FindElementsByClassName("inputState");

                    IWebElement username = textboxList[0];
                    IWebElement email = textboxList[1];
                    IWebElement password = textboxList[2];

                    IWebElement agreement = webDriver.FindElementById("agreement");

                    bool selected = cbAgreement.Checked;

                    if (selected)
                    {
                        username.SendKeys(tbUsername.Text.Trim());
                        email.SendKeys(tbEmail.Text.Trim());
                        password.SendKeys(tbPassword.Text.Trim());
                        agreement.Click();
                        System.Threading.Thread.Sleep(3000);
                        webDriver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
                    }
                    else
                    {
                        username.SendKeys(tbUsername.Text.Trim());
                        email.SendKeys(tbEmail.Text.Trim());
                        password.SendKeys(tbPassword.Text.Trim());
                        System.Threading.Thread.Sleep(3000);
                        webDriver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);     
                    }

                    //Close child window
                    System.Threading.Thread.Sleep(3000);
                    webDriver.Close();
                    
                    webDriver.SwitchTo().DefaultContent();
                    Clear();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Clear()
        {
            tbUsername.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPassword.Text = string.Empty;
        }
    }
}
