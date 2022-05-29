using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRepositories.INavigation
{
    public interface ICheckOutOverviewPage
    {

        void checkOut_overView_Completion();
        void checkOut_overView_Cancel();


        //void InputLogin(string userName, string password);
        //void proceedToLogin();
        //bool isLoginSuccess();
        //string errorMessage();
    }
}
