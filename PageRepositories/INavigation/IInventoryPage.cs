using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRepositories.INavigation
{
    public interface IInventoryPage
    {
        void select_Product();
        void Navigateto_cartpage();


        //void InputLogin(string userName, string password);
        //void proceedToLogin();
        //bool isLoginSuccess();
        //string errorMessage();
    }
}
