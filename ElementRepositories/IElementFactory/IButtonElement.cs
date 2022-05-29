using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementRepositories.ElementFactory
{
    public interface IButtonElement: IElementBase
    {
       // WebElement webElement { get; set; }
       // WebElement parentElement { get; set; }

        void Click();
    }
}
