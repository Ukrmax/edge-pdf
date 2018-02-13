using EdgeTest.Views;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeTest
{
    [TestFixture]
    public class PdfPageObjectTests
    {
        private WindowsDriver<WindowsElement> _driver;
        private BrowserStandartView _testClassView;

        [SetUp]
        public void TestIn()
        {
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge");
            appCapabilities.SetCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _testClassView = new BrowserStandartView(_driver);
        }

        [TearDown]
        public void TestCleanUp()
        {
            System.Threading.Thread.Sleep(3000);
            if (_driver != null)
            {
                _driver.Close();
                //_driver = null;
            }

            try
            {
                _testClassView.ExitConfirmationWindow.Click();
            }
            catch
            {
            }
        }

        [Test]
        [Description("Verifying file openning functionality")]
        public void OpenFileTest()
        {
            _testClassView.OpenPdfFile(_testClassView.simplePdfFile);
            Assert.AreEqual(_driver.FindElementByAccessibilityId("Microsoft.Windows.PDF.DocumentView").GetAttribute("Name"), "PDF file,  containing 1 pages");
        }


        [Test]
        [Description("Verifying drobdown element selection fucntuionality")]
        public void DropDownSelect()
        {
            _testClassView.OpenPdfFile(_testClassView.pdfFormExample);
            _testClassView.SelectElementComboBox();
            Assert.AreEqual(_testClassView.Country_list.Text, "Bulgaria");
        }

        [Test]
        [Description("Verifying fill out the text box")]
        public void FillOutTextField()
        {
            _testClassView.OpenPdfFile(_testClassView.pdfFormExample);
            _testClassView.FillOutTextBox(_testClassView.GivenNameTextBox, "John");
            Assert.AreEqual(_testClassView.GivenNameTextBox.Text, "John");
        }

        [Test]
        [Description("Verifying deleting text from the text box")]
        public void CleanTextField()
        {
            _testClassView.OpenPdfFile(_testClassView.pdfFormExample);
            _testClassView.FillOutTextBox(_testClassView.GivenNameTextBox, "John");
            _testClassView.CleanTextBox(_testClassView.GivenNameTextBox);
            Assert.AreEqual(_testClassView.GivenNameTextBox.Text, String.Empty);
        }

        [Test]
        [Description("Vefyfing multiple words search")]
        public void TwoColumnsFileMultipleWordsSearch()
        {
            _testClassView.OpenPdfFile(_testClassView.pdfTwoColumn);
            _testClassView.SearchText("on the insert");
            Assert.AreEqual(_testClassView.SearchResultStatus.Text, "1 of 27");
        }

        [Test]
        [Description("Verifying search with the Match Case option")]
        public void TwoColumnsFileTextSearchMatchCase()
        {
            _testClassView.OpenPdfFile(_testClassView.pdfTwoColumn);
            _testClassView.SearchText("Insert");
            _testClassView.SelectMatchCaseOption();
            Assert.AreEqual(_testClassView.SearchResultStatus.Text, "1 of 27");
        }

    }
}
