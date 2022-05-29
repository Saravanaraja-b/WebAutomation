using ElementRepositories.ElementFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementRepositories.ElementFactory
{
    public class ButtonElement : IButtonElement
    {
        public WebElement webElement { get ; set; }        

        public void Click()
        {
            this.webElement.Click();
        }
    }
}
