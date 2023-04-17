using System.Globalization;

namespace Electricity
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string filePath = @"c:\Users\zhuzn\Desktop\.NetCamp\SSWU_DariaSushchenko_NET_CAMP\Home_task_4\exercise3\Electricity\my.txt";

            List<ElectricityData> data = ElectricityData.ReadDataFromFile(filePath);

            Console.WriteLine(ElectricityData.GenerateReport(data));

            ElectricityData apartmentData = ElectricityData.FindApartment(data);
            ElectricityData.PrintApartmentData(apartmentData);

            ElectricityData unusedApartment = ElectricityData.FindApartmentSmallestMeter(data);
            ElectricityData.PrintApartmentData(unusedApartment);

            double costPerKilowatt = ElectricityData.ReadCostPerKilowattFromConsole();
            ElectricityData.CalculateTotalCost(data, costPerKilowatt);
            ElectricityData.FindBiggestDebtOwner(data, costPerKilowatt);
            ElectricityData.CalculateNumberOfDays(data);
        }
    }
}