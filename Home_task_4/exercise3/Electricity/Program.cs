using System.Globalization;

namespace Electricity
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string filePath = @"c:\Users\zhuzn\source\repos\Electricity\Electricity\my.txt";

            List<ElectricityData> data = ElectricityData.ReadDataFromFile(filePath);

            Console.WriteLine(ElectricityData.GenerateReport(data));

            Console.WriteLine("Finding apartment:");
            ElectricityData apartmentData = ElectricityData.FindApartment(data);
            ElectricityData.PrintApartmentData(apartmentData);

            Console.WriteLine("Apartment with smallest meter:");
            ElectricityData unusedApartment = ElectricityData.FindApartmentSmallestMeter(data);
            ElectricityData.PrintApartmentData(unusedApartment);

            double costPerKilowatt = ElectricityData.ReadCostPerKilowattFromConsole();
            ElectricityData.CalculateTotalCost(data, costPerKilowatt);
            ElectricityData.FindBiggestDebtOwner(data, costPerKilowatt);
            ElectricityData.CalculateNumberOfDays(data);
        }
    }
}