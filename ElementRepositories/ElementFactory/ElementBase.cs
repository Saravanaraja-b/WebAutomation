using ElementRepositories.ElementFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementRepositories.ElementFactory
{
    public abstract class ElementBase : IElementBase
    {        
        public WebElement webElement { get; set ; }
    }
}
