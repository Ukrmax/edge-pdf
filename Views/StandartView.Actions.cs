//----------------------------------------------------------------------------------------------------------------------
// <copyright file="TestClass1.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>Defines the TestClass1 type.</summary>
//----------------------------------------------------------------------------------------------------------------------
namespace EdgeTest.Views
{
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Edge;
    using System;
    using System.Globalization;
    using System.IO;
    using WEX.Common.Managed;
    using WEX.Logging.Interop;
    using WEX.TestExecution;
    using WEX.TestExecution.Markup;
    using OpenQA.Selenium;
    using System.Reflection;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.ObjectModel;

    
    public partial class BrowserStandartView  
    {
        public BrowserStandartView(WindowsDriver<WindowsElement> driver) => _driver = driver;
        private WindowsDriver<WindowsElement> _driver;

    public void OpenPdfFile(string path)
        {
            _driver.FindElementByAccessibilityId("addressEditBox").SendKeys(path);
            _driver.FindElementByAccessibilityId("addressEditBox").SendKeys(Keys.Enter);
        }

        public void SelectElementComboBox()
        {
            Country_list.Click();
            int i = 0;
            while (i < 4)
            {
                Country_list.SendKeys(Keys.Down);
                i++;
            }
            Country_list.SendKeys(Keys.Enter);
        }

        public void FillOutTextBox(WindowsElement element, string text)
        {
            element.SendKeys(text);
        }

        public void CleanTextBox(WindowsElement element)
        {
            element.Clear();
        }

        public void SearchText(string text)
        {
            SearchButton.Click();
            FindSearchBox.SendKeys(text);
        }

        public void SelectMatchCaseOption()
        {
            if (!SearchOptionsButton.Displayed)
            {
                SearchButton.Click();
            }
            SearchOptionsButton.Click();
            MatchCaseOption.Click();

        }

        

        
}
}