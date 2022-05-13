using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Splash screen
            Console.WriteLine("Loading Budget Planner App...");
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);  //max 5000
            }
            while (true)
            { try
                {
                   // variables
                    float grossIncome = 0;
                    float taxDeducted = 0;
                    float groceries = 0;
                    float waterAndLights = 0;
                    float travelCosts = 0;
                    float cellPhone = 0;
                    float otherexpen = 0;
                    float monthlyRental = 0;
                    float propertyPrice = 0;
                    float totalDeposit = 0;
                    float interestRate = 0;
                    int monthrepay = 0;
                    int typeAcc = 0;
                    float eMI = 0;
                    //Array to store the expenses val
                    Dictionary<string, float> expenList = new Dictionary<string, float>();

                    //Part of the splash screen
                    Console.WriteLine("\nWelcome to the Budget Planner App !!!");
                    Console.WriteLine("-------------------------------------------------------------------");
                    Thread.Sleep(1000);

                    //store Estimated monthly tax deducted
                    Console.WriteLine("Gross monthly income (before deductions)");
                    float.TryParse(Console.ReadLine(), out grossIncome);
                    Console.WriteLine("Estimated monthly tax deducted");
                    float.TryParse(Console.ReadLine(), out taxDeducted);
                    expenList.Add("Estimated monthly tax deducted", taxDeducted);

                    //store Groceries
                    Console.WriteLine("Estimated monthly expenditures in each of the following categories");
                    Console.WriteLine("Groceries");
                    float.TryParse(Console.ReadLine(), out groceries);
                    expenList.Add("Groceries", groceries);

                    //store Water and lights
                    Console.WriteLine("Water and lights");
                    float.TryParse(Console.ReadLine(), out waterAndLights);
                    expenList.Add("Water and lights", waterAndLights);

                    //store Travel costs (including petrol)
                    Console.WriteLine("Travel costs (including petrol)");
                    float.TryParse(Console.ReadLine(), out travelCosts);
                    expenList.Add("Travel costs (including petrol)", travelCosts);

                    //store Cell phone and telephone
                    Console.WriteLine("Cell phone and telephone");
                    float.TryParse(Console.ReadLine(), out cellPhone);
                    expenList.Add("Cell phone and telephone", cellPhone);

                    //store Other expenses
                    Console.WriteLine("Other expenses");
                    float.TryParse(Console.ReadLine(), out otherexpen);
                    expenList.Add("Other expenses", otherexpen);

                    // Calling it from the abstract class
                    Expense[] ep = new Expense[]
                    {
                        new Home_Loan("Total expense",(taxDeducted + groceries + waterAndLights + travelCosts + cellPhone + otherexpen))

                    };
                    while (true)
                    {
                        Console.WriteLine("For Renting accommodation select 1 or select 2 for buying a property");
                        Console.WriteLine("1. Renting accommodation");
                        Console.WriteLine("2. Buying a property");
                        typeAcc = Convert.ToInt32(Console.ReadLine());
                        if (typeAcc == 1 || typeAcc == 2)
                        {
                            break;
                        }

                    }
                    if (typeAcc == 1)
                    {
                        //store Monthly rental amount"
                        Console.WriteLine("Monthly rental amount");
                        float.TryParse(Console.ReadLine(), out monthlyRental);
                        expenList.Add("Monthly rental amount", monthlyRental);

                    }
                    else if (typeAcc == 2)
                    {
                        Console.WriteLine("Purchase price of property");
                        float.TryParse(Console.ReadLine(), out propertyPrice);
                        Console.WriteLine("Total deposit");
                        float.TryParse(Console.ReadLine(), out totalDeposit);
                        Console.WriteLine("Interest rate (percentage)");
                        float.TryParse(Console.ReadLine(), out interestRate);
                        while (true)
                        {
                            Console.WriteLine("Number of months to repay (between 240 and 360)");
                            monthrepay = Convert.ToInt32(Console.ReadLine());
                            if (monthrepay >= 240 && monthrepay <= 360)
                            {
                                break;
                            }
                        }
                            eMI = Home_Loan.emi_calculator(propertyPrice - totalDeposit, interestRate, monthrepay / 12);
                            Console.WriteLine("Monthly home loan repayment for buying a property:" + eMI + "");
                            if (eMI > grossIncome / 3)
                            {
                                Console.WriteLine("Approval of the home loan is unlikely");
                            }
                        //store Home Loan EMI
                        expenList.Add("Home Loan EMI", eMI);
                        }
              
                        float availableMoney = 0;
                        if (typeAcc == 1)
                        {
                        availableMoney =  grossIncome - (ep.Sum(x=> x.Costs)+ monthlyRental);
                        }
                        else if (typeAcc == 2)
                        {
                            availableMoney = grossIncome - (ep.Sum(x => x.Costs) + eMI);
                        }
                        Console.WriteLine("Available monthly money after all the specified deductions have been made:{0}", availableMoney);
                        float totalExpense = 0;
                        if (typeAcc == 1)
                        {
                            totalExpense = (ep.Sum(x => x.Costs) + monthlyRental);
                        }
                        else if (typeAcc == 2)
                        {
                            totalExpense = (ep.Sum(x => x.Costs) + eMI);
                        }
                        if (totalExpense > (grossIncome * 3 / 4))
                        {
                            Console.WriteLine("Total expenses are greater than 75 percent of gross income");
                        }

                    // Display the expenses to the user in descending order by value
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("Expenses to the user in descending order by value");
                    foreach(KeyValuePair<string,float>expin in expenList.OrderBy(key => key.Value))
                    {
                        Console.WriteLine(expin.Key +" "+ expin.Value);
                    }

                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("For Next calculation enter 1 or any other value to close the application");
                        int value = 0;
                        int.TryParse(Console.ReadLine(), out value);
                        if (value == 1)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("For Next calculation enter 1 or any other value to close the application");
                    int value = 0;
                    int.TryParse(Console.ReadLine(), out value);
                    if (value == 1)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                


                    

            }
        }
    }
}
