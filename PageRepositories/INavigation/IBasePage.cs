using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRepositories.INavigation
{
    public interface IBasePage
    {
        void NavigatetoInventoryScreen();
        void InputLogin(string userName, string password);
        void proceedToLogin();
       // bool isLoginSuccess();
        
    }
}
