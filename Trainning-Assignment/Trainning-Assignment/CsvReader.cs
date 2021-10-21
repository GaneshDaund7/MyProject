using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training_Assignment
{
    public class CsvReader
    {

        public string Machine_Name { get; set; }
        public string Asset_Name { get; set; }
        public string Series_No { get; set; }



        public static CsvReader ParseRow(string row)
        {
            var column = row.Split(',');

            //foreach(var i in column)
            //Console.WriteLine(i);

            try
            {
                return new CsvReader()
                {
                    Machine_Name = column[0],
                    Asset_Name = column[1],
                    Series_No = column[2],


                };

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured" + e.Message);
                return null;
            }

        }

       
    }

    public class MachineAssetComparer:IEqualityComparer<CsvReader>
    {
        public bool Equals(CsvReader x, CsvReader y)
        {
            if (x.Asset_Name == y.Asset_Name && x.Machine_Name == y.Machine_Name && x.Series_No == y.Series_No)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(CsvReader obj)
        {
            return (obj.Series_No + obj.Machine_Name + obj.Asset_Name).GetHashCode();
        }

    }

    public class MachineNameComparer : IEqualityComparer<CsvReader>
    {

        public bool Equals(CsvReader x, CsvReader y)
        {
            if (x.Machine_Name == y.Machine_Name)
                return true;
            return false;

        }

        public int GetHashCode(CsvReader obj)
        {
            return (obj.Machine_Name).GetHashCode();
        }
    }
    public class AssetSeriesComparer : IEqualityComparer<CsvReader>
    {
        public bool Equals(CsvReader x, CsvReader y)
        {
            if (x.Asset_Name == y.Asset_Name && x.Series_No == y.Series_No)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(CsvReader obj)
        {
            return (obj.Series_No + obj.Asset_Name).GetHashCode();
        }
    }




}
