using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Training_Assignment
{
    public class GetDetails
    {
        public static List<CsvReader> TogetAsset(string path, string user_MachineName)
        {

            return File.ReadAllLines(path).
                Where(row => row.Length > 0).
                Select(CsvReader.ParseRow).
                Where(x => x.Machine_Name == user_MachineName).
                ToList();
        }
        public static List<CsvReader> TogetMachine(string path, string user_Asset)
        {
            user_Asset = " " + user_Asset;

            return File.ReadAllLines(path).
                Where(row => row.Length > 0).
                Select(CsvReader.ParseRow).
                Where(x => x.Asset_Name == user_Asset).
                ToList();
        }



        public static List<string> TogetMachineByLastedSeries(string path)
        {


            //var Result1 = File.ReadAllLines(path).
            //    Where(row => row.Length > 0).
            //    Select(CsvReader.ParseRow).
            //    OrderByDescending(x => x.Series_No).
            //    ThenBy(x => x.Asset_Name).
            //    GroupBy(asset => asset.Asset_Name).
            //    Select(g => g.First()).
            //    ToList();

            //var Result2 = File.ReadLines(path).
            //    Where(row => row.Length > 0).
            //    Select(CsvReader.ParseRow).
            //    ToList();

            //Console.WriteLine("Before");
            //foreach (var i in Result1)
            //    Console.WriteLine(i.Machine_Name);
            //Console.WriteLine();
            //Console.WriteLine();

            //var Temp_Result = Result2.Except(Result1, new CsvReader()).ToList();
            //var res = Temp_Result.Intersect(Result1, new AssetSeriesComparer()).ToList();
            //foreach (var i in res)
            //    Console.WriteLine(i.Machine_Name + "" + i.Asset_Name + "" + i.Series_No);
            //Result1.AddRange(res);

            //Console.WriteLine("After");
            //foreach (var i in Result1)
            //    Console.WriteLine(i.Machine_Name);
            //Console.WriteLine();
            //Console.WriteLine();
            //var another = Temp_Result.Except(res, new AssetSeriesComparer());


            //var Final_Result = Result1.Except(another, new MachineNameComparer()).Select(x=>x.Machine_Name).ToList();


            //return Final_Result;

            var machinesWithLastestAssets = File.ReadAllLines(path).
                Where(row => row.Length > 0).
                Select(CsvReader.ParseRow).
                OrderByDescending(x => x.Series_No).
                ThenBy(x => x.Asset_Name).
                GroupBy(asset => asset.Asset_Name).
                Select(g => g.First()).
                ToList();

            var machinesWithOldesAssets = File.ReadLines(path).
                Where(row => row.Length > 0).
                Select(CsvReader.ParseRow).
                Except(machinesWithLastestAssets, new MachineAssetComparer()).
                ToList();

            var remainingLastestAsset = machinesWithOldesAssets.Intersect(machinesWithLastestAssets, new AssetSeriesComparer()).ToList();
            machinesWithLastestAssets.AddRange(remainingLastestAsset);

            var removingRemainingLastestAsssetFromOldestAsset = machinesWithOldesAssets.Except(remainingLastestAsset, new AssetSeriesComparer()).ToList();


            var lastestAsssetMachines = machinesWithLastestAssets.Except(removingRemainingLastestAsssetFromOldestAsset, new MachineNameComparer()).
                                         Select(x => x.Machine_Name).ToList();

            return lastestAsssetMachines;

        }


    }
}
