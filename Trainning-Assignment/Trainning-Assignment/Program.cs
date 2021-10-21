using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Training_Assignment
{

    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Press 1 for Task1... and Press 2 For task2.... ....Press 3 For Task 3......and press -1 to Exit ");
                var inputstr = Console.ReadLine();
                int input = int.Parse(inputstr);

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter the Machine Name to find asset used...");
                        var usr_machine_name = Console.ReadLine();
                        var getAsset = GetDetails.TogetAsset("Matrix.csv", usr_machine_name);
                        foreach (var res in getAsset)
                            Console.WriteLine(res.Asset_Name);
                        break;

                    case 2:
                        Console.WriteLine("Enter the Asset name to find which machines it uses...");
                        var usr_asset_name = Console.ReadLine();
                        var getMachine = GetDetails.TogetMachine("Matrix.csv", usr_asset_name);
                        foreach (var res in getMachine)
                            Console.WriteLine(res.Machine_Name);
                        break;

                    case 3:
                        var result = GetDetails.TogetMachineByLastedSeries("Matrix.csv");
                        foreach (var res in result)
                            Console.WriteLine(res);
                        break;
                    default:
                        Console.WriteLine("Invalid Number ! Please try Again!");
                        break;

                }
                if (input == -1)
                    break;

            }


            Console.ReadLine();
        }
    }










}
