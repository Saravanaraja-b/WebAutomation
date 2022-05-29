using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRepositories.INavigation
{
    public interface ICartCheckoutInformation
    {
        void fill_Information(string firstName, string lastName, string postalCode);
        void continue_checkOut();
        void cancel_checkOut();


        //void InputLogin(string userName, string password);
        //void proceedToLogin();
        //bool isLoginSuccess();
        //string errorMessage();
    }
}
