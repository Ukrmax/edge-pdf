using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeTest.Views
{
    partial class BrowserStandartView
    {
        public string simplePdfFile = filesPath + "1_No_LTR_1029.6_396.pdf";
        public string pdfFormExample = filesPath + "OoPdfFormExample.pdf";
        public string pdfTwoColumn = filesPath + "9_TwoColumnLeft_RTL_612_792_P1.pdf";
        public static string filesPath = "C:\\Users\\v-makiva\\Desktop\\TestFiles\\";

        //form locators
        public WindowsElement Country_list => _driver.FindElementByName("Country Combo Box");
        public WindowsElement GivenNameTextBox => _driver.FindElementByName("Given Name Text Box");

        
        public WindowsElement ExitConfirmationWindow => _driver.FindElementByAccessibilityId("m_button0Text");

        //search menu locators
        public WindowsElement FindSearchBox => _driver.FindElementByAccessibilityId("FindSearchBox");
        public WindowsElement SearchButton => _driver.FindElementByAccessibilityId("EdgeSearchButton");
        public WindowsElement SearchResultStatus => _driver.FindElementByAccessibilityId("FindStatusTextBox");
        public WindowsElement SearchOptionsButton => _driver.FindElementByAccessibilityId("FindOptionsButton");
        public WindowsElement MatchCaseOption => _driver.FindElementByAccessibilityId("FindOnPageMatchCase");

    }
}
