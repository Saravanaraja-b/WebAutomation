using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementRepositories.ElementFactory
{
    public interface ITextBoxElement : IElementBase
    {
        void Entertext(string text);
        void Click();
        string GetValue();
    }
}
