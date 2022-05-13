using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlan
{
    // Inherit the Abstract class
    class Home_Loan : Expense
    {
        public Home_Loan(string name, float costs) : base(name, costs)
        {

        }

        public static float emi_calculator(float p, float r, float t)
        {
            float emi;
            // one month interest
            r = r / (12 * 100);
            // one month period
            t = t * 12;
            emi = (p * r * (float)Math.Pow(1 + r, t)) / (float)(Math.Pow(1 + r, t) - 1);

            return (emi);
        }



    }
}
