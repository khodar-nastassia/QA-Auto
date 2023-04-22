using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal interface IPayment
    {
        float MakePayment(float amount);
        float TopUp(float amount);
        bool CheckBalanceSufficiency(float amount);
        float GetBalance();
        string ToString();

    }
}
