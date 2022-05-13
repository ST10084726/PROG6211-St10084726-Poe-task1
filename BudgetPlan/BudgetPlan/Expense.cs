using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlan
{
    abstract class Expense
    {
        public string Name { get; set; }
        public float Costs { get; set; }

        public Expense(string name, float costs)
        {
            //constructors
            Name = name;
            Costs = costs;
        }
        public override string ToString()
        {
            return $"{ Name}:{ Costs:C}";
        }

    }
}
