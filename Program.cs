using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestProfit
{
    class Program
    {

        public static int[] example_1 = { 100, 50, 200, 400, 20, 60, 10, 90, 300, 200};
        public static int[] example_2 = { 20, 30, 40, 10, 5, 80, 100, 60};
        public static int[] example_3 = { 20, 10, 5, 30, 60, 90, 40, 50 };
        public static int[] example_4 = { 20, 5, 15, 35, 10, 50, 80, 40 };

        static void Main(string[] args)
        {
            //selecting the example
            int[] arr = example_4;

            //displayinh the array
            Console.Write("[");
            for(int i = 0; i<arr.Length; i++) 
                Console.Write((i==0?"":",") + arr[i]);
            Console.WriteLine("]");
            Console.WriteLine("");

            //initializing the class
            ProfitCalculation pr = new ProfitCalculation();
            pr.valueInput = arr;
            
            //Declaring integers
            int buy = 0,sell=0,profit=-1,
                boughtCount=0,total=0;

            while (true)
            {
                buy = pr.getOptimumBuyIndex();  // find where to buy as a index in array
                if (buy == -1) break;           // check, is bought or not. Else "buy" value is "-1"
                sell = pr.findNextSale();       // find sale index
                if (sell == -1) break;          // check, is sold or not. Else "sell" value is "-1"
                if (profit == -1) profit = pr.valueInput[buy];  //first amount is given in here to purchase single share to codes, in first loop

                boughtCount = profit / pr.valueInput[buy];                          //calculates, how much shares are bought
                profit = (pr.valueInput[sell] - pr.valueInput[buy]) *boughtCount;   //calculates profit
                total = pr.valueInput[sell] * boughtCount;                          // calculates total amount

                Console.WriteLine("[BUY] day:"+(buy+1)+" - at:" + pr.valueInput[buy] + " - "+boughtCount+"X times 	/ [SELL] day:" + (sell+1)+ " - at:"+ pr.valueInput[sell]+ " 	/ profit: " + (profit ));

            }
            Console.WriteLine("Total: "+ total);


            Console.ForegroundColor = ConsoleColor.Red;
            
        }



    }
}
