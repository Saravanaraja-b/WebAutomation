using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRepositories.INavigation
{
    public interface ICartPage
    {
        void checkOut_Product();
        void checkOut_ContinueShopping();


        //void InputLogin(string userName, string password);
        //void proceedToLogin();
        //bool isLoginSuccess();
        //string errorMessage();
    }
}
