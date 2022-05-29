using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementRepositories.ElementFactory
{
    public class TextBoxElement : ITextBoxElement
    {
       public WebElement webElement { get; set; }

        public void Entertext(string text)
        {
            this.webElement.SendKeys(text);            
        }
        public void Click()
        {
            this.webElement.Click();
        }

        public string GetValue()
        {
            return this.webElement.GetAttribute("innerText");
        }
    }
}
