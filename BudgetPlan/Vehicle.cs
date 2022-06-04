using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BudgetPlan
{
    // Inherit the Abstract class
    class Vehicle :Home_Loan
    {
        public Vehicle(string name, float costs) : base(name, costs)
        {

        }

        public static float BuyVehicle()
        {
            Console.WriteLine("Want to purchase a vehicle, select 1 or 2");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");

            float emivechilce = 0;
            int selectvehicle = Convert.ToInt32(Console.ReadLine());
            if(selectvehicle == 1)
            {
                Console.WriteLine("Model and make:"); 
                string make = Console.ReadLine(); 
                Console.WriteLine("Purchase cost:"); 
                float purchasePrice = 0; 
                float.TryParse(Console.ReadLine(), out purchasePrice); 
                Console.WriteLine("Total deposit:"); 
                float totalDeposit = 0; 
                float.TryParse(Console.ReadLine(), out totalDeposit); 
                Console.WriteLine("Interest rate (percentage):"); 
                float interestRate = 0; 
                float.TryParse(Console.ReadLine(), out interestRate); 
                Console.WriteLine("Estimated insurance premium:"); 
                float estInsPremium = 0; 
                float.TryParse(Console.ReadLine(), out estInsPremium); 
                emivechilce = emi_calculator(purchasePrice - totalDeposit + estInsPremium, interestRate, 5);
            }
            return emivechilce;
        }
    }
}
