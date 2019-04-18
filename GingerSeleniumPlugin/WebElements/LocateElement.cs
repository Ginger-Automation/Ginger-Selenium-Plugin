using Amdocs.Ginger.Plugin.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static Amdocs.Ginger.Plugin.Core.ActionsLib.ActInfo;

namespace GingerSeleniumPlugin.WebElements
{
   public class LocateElement
    {

        public static IWebElement LocateElementByLocator(IWebDriver Driver, eLocateBy locateBy, string LocateValue)
        {
            IWebElement elem = null;



            if (locateBy == eLocateBy.ByID)
            {
                if (LocateValue.IndexOf("{RE:") >= 0)
                    elem = FindElementReg(Driver, locateBy, LocateValue);
                else
                    elem = Driver.FindElement(By.Id(LocateValue));
            }

            else if (locateBy == eLocateBy.ByName)
            {
                if (LocateValue.IndexOf("{RE:") >= 0)
                    elem = FindElementReg(Driver, locateBy, LocateValue);
                else
                    elem = Driver.FindElement(By.Name(LocateValue));
            }

            else if (locateBy == eLocateBy.ByHref)
            {
                string pattern = @".+:\/\/[^\/]+";
                string sel = "//a[contains(@href, '@RREEPP')]";
                sel = sel.Replace("@RREEPP", new Regex(pattern).Replace(LocateValue, ""));
                try
                {
                    if (LocateValue.IndexOf("{RE:") >= 0)
                        elem = FindElementReg(Driver, locateBy, LocateValue);
                    else
                        elem = Driver.FindElement(By.XPath(sel));
                }
                catch (NoSuchElementException ex)
                {

                    sel = "//a[href='@']";
                    sel = sel.Replace("@", LocateValue);
                    elem = Driver.FindElement(By.XPath(sel));


                }

            }

            else if (locateBy == eLocateBy.ByLinkText)
            {
                LocateValue = LocateValue.Trim();
                try
                {
                    if (LocateValue.IndexOf("{RE:") >= 0)
                        elem = FindElementReg(Driver, locateBy, LocateValue);
                    else
                    {
                        elem = Driver.FindElement(By.LinkText(LocateValue));
                        if (elem == null)
                            elem = Driver.FindElement(By.XPath("//*[text()='" + LocateValue + "']"));
                    }
                }
                catch (NoSuchElementException ex)
                {


                    elem = Driver.FindElement(By.XPath("//*[text()='" + LocateValue + "']"));
                }
            }





            else if (locateBy == eLocateBy.ByXPath || locateBy == eLocateBy.ByRelXPath)
            {
                elem = Driver.FindElement(By.XPath(LocateValue));
            }

            else if (locateBy == eLocateBy.ByValue)
            {
                if (LocateValue.IndexOf("{RE:") >= 0)
                    elem = FindElementReg(Driver, locateBy, LocateValue);
                else
                    elem = Driver.FindElement(By.XPath("//*[@value=\"" + LocateValue + "\"]"));
            }

            else if (locateBy == eLocateBy.ByAutomationID)
            {
                elem = Driver.FindElement(By.XPath("//*[@data-automation-id=\"" + LocateValue + "\"]"));
            }

            else if (locateBy == eLocateBy.ByCSS)
            {
                elem = Driver.FindElement(By.CssSelector(LocateValue));
            }

            else if (locateBy == eLocateBy.ByClassName)
            {
                elem = Driver.FindElement(By.ClassName(LocateValue));
            }

            else if (locateBy == eLocateBy.ByMulitpleProperties)
            {
                elem = GetElementByMutlipleAttributes(Driver, LocateValue);
            }


            return elem;
        }


        private static IWebElement FindElementReg(IWebDriver Driver, eLocateBy LocatorType, string LocValue)
        {
            Regex reg = new Regex(LocValue.Replace("{RE:", "").Replace("}", ""), RegexOptions.Compiled);

            var searchTags = new[] { "a", "link", "h1", "h2", "h3", "h4", "h5", "h6", "label", "input", "selection", "p" };
            var elem = Driver.FindElements(By.XPath("//*")).Where(e => searchTags.Contains(e.TagName.ToLower()));

            switch (LocatorType)
            {
                case eLocateBy.ByID:
                    foreach (IWebElement e in elem)
                    {
                        if (e.GetAttribute("id") != null)
                            if (reg.Matches(e.GetAttribute("id")).Count > 0)
                                return e;
                    }
                    break;
                case eLocateBy.ByName:
                    foreach (IWebElement e in elem)
                    {
                        if (e.GetAttribute("name") != null)
                            if (reg.Matches(e.GetAttribute("name")).Count > 0)
                                return e;
                    }
                    break;
                case eLocateBy.ByLinkText:
                    foreach (IWebElement e in elem)
                    {
                        if (e.Text != null)
                            if (reg.Matches(e.Text).Count > 0)
                                return e;
                    }
                    break;
                case eLocateBy.ByValue:
                    foreach (IWebElement e in elem)
                    {
                        if (e.GetAttribute("value") != null)
                            if (reg.Matches(e.GetAttribute("value")).Count > 0)
                                return e;
                    }
                    break;
                case eLocateBy.ByHref:
                    foreach (IWebElement e in elem)
                    {
                        if (e.GetAttribute("href") != null)
                            if (reg.Matches(e.GetAttribute("href")).Count > 0 && e.Text != "")
                                return e;
                    }
                    break;
            }
            return Driver.FindElements(By.XPath("//*[@value=\"" + LocValue + "\"]")).FirstOrDefault();
        }
        private static IWebElement GetElementByMutlipleAttributes(IWebDriver Driver, string LocValue)
        {

            string[] a = LocValue.Split(';');
            string[] a0 = a[0].Split('=');

            string id = null;
            if (a0[0] == "id") id = a0[1];

            string[] a1 = a[1].Split('=');
            string attr = a1[0];
            string val = a1[1];

            if (id == null)
            {
                return null;
            }
            ReadOnlyCollection<IWebElement> list = Driver.FindElements(By.Id(id));

            foreach (IWebElement e in list)
            {
                if (e.GetAttribute(attr) == val)
                {
                    return e;
                }
            }
            return null;
        }
    }
}

