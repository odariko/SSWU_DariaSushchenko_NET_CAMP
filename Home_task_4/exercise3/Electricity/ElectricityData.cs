using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Electricity
{// Ви думаєте не об'єктно-зорієнтовано!!!
    internal class ElectricityData
    {
        public int ApartmentNumber { get; set; }
        public string Address { get; set; }
        public string OwnerName { get; set; }
        public double IncomingMeterReading { get; set; }
        public double OutgoingMeterReading { get; set; }
        public DateTime DateOfReading { get; set; }

        public ElectricityData(int apartmentNumber, string address, string ownerName, double incomingMeterReading, double outgoingMeterReading, DateTime dateOfReading)
        {
            ApartmentNumber = apartmentNumber;
            Address = address;
            OwnerName = ownerName;
            IncomingMeterReading = incomingMeterReading;
            OutgoingMeterReading = outgoingMeterReading;
            DateOfReading = dateOfReading;
        }
// Не правильне проєктування. Цей метод немає належити цьому класу
        public static List<ElectricityData> ReadDataFromFile(string filePath)
        {
            var data = new List<ElectricityData>();
            using (var reader = new StreamReader(filePath))
            {
                var firstLine = reader.ReadLine().Split(' ');
                int numberOfApartments = int.Parse(firstLine[0]);
                int quarter = int.Parse(firstLine[1]);

                for (int i = 0; i < numberOfApartments; i++)
                {
                    var line = reader.ReadLine().Split(' ');
                    int apartmentNumber = int.Parse(line[0]);
                    string address = line[1];
                    string ownerName = line[2];
                    double incomingMeterReading = double.Parse(line[3], CultureInfo.InvariantCulture);
                    double outgoingMeterReading = double.Parse(line[4], CultureInfo.InvariantCulture);
                    DateTime dateOfReading = DateTime.ParseExact(line[5], "dd.MM.yy", CultureInfo.InvariantCulture);
                    data.Add(new ElectricityData(apartmentNumber, address, ownerName, incomingMeterReading, outgoingMeterReading, dateOfReading));
                }
            }
            return data;
        }

        public static string GenerateReport(List<ElectricityData> data)
        {
            var groupedData = data.GroupBy(d => new { Month = d.DateOfReading.Month, Year = d.DateOfReading.Year }).OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month);

            var report = "";
            foreach (var group in groupedData)
            {
                report += $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month)} {group.Key.Year}\n";
                report += "----------------------------------------\n";

                foreach (var apartmentData in group)
                {
                    report += $"Apartment {apartmentData.ApartmentNumber}: {apartmentData.OwnerName}\n";
                    report += $"  Incoming meter reading: {apartmentData.IncomingMeterReading,10:0.00}\n";
                    report += $"  Outgoing meter reading: {apartmentData.OutgoingMeterReading,10:0.00}\n";
                    report += $"  Date of reading: {apartmentData.DateOfReading.ToString("dd.MM.yy"),16}\n";
                }

                report += "\n";
            }

            return report;
        }

        public static ElectricityData FindApartment(List<ElectricityData> data)
        {
            int apartmentNumber = ReadApartmentNumberFromConsole();
            ElectricityData apartmentData = data.FirstOrDefault(d => d.ApartmentNumber == apartmentNumber);
            return apartmentData;
        }

        public static ElectricityData FindApartmentSmallestMeter(List<ElectricityData> data)
        {
            ElectricityData unusedApartment = data.FirstOrDefault(d => d.OutgoingMeterReading == 0);
            return unusedApartment;
        }

        public static void PrintApartmentData(ElectricityData apartmentData)
        {
            if (apartmentData != null)
            {
                Console.WriteLine($"Apartment {apartmentData.ApartmentNumber} - {apartmentData.OwnerName}:");
                Console.WriteLine($"  Address: {apartmentData.Address}");
                Console.WriteLine($"  Incoming meter reading: {apartmentData.IncomingMeterReading:0.00}");
                Console.WriteLine($"  Outgoing meter reading: {apartmentData.OutgoingMeterReading:0.00}");
                Console.WriteLine($"  Date of reading: {apartmentData.DateOfReading.ToString("dd.MM.yy")}");
                Console.WriteLine();
            }
        }

        public static void CalculateTotalCost(List<ElectricityData> data, double costPerKilowatt)
        {
            var costs = data.Select(d => new { ApartmentNumber = d.ApartmentNumber, Cost = (d.OutgoingMeterReading - d.IncomingMeterReading) * costPerKilowatt }).ToList();
            Console.WriteLine();
            Console.WriteLine("Electricity Costs:");
            Console.WriteLine("------------------");
            foreach (var cost in costs)
            {
                Console.WriteLine($"Apartment {cost.ApartmentNumber}: {cost.Cost:0.00} ₴");
            }
        }

        public static void FindBiggestDebtOwner(List<ElectricityData> data, double costPerKilowatt)
        {
            var costs = data.Select(d => new { ApartmentNumber = d.ApartmentNumber, Cost = (d.OutgoingMeterReading - d.IncomingMeterReading) * costPerKilowatt }).ToList();
            var maxCost = costs.Max(c => c.Cost);
            var ownerWithMaxDebt = data.FirstOrDefault(d => costs.FirstOrDefault(c => c.ApartmentNumber == d.ApartmentNumber)?.Cost == maxCost)?.OwnerName;
            if (ownerWithMaxDebt != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Owner with biggest debt: {ownerWithMaxDebt}");
            }
        }
        
        public static void CalculateNumberOfDays(List<ElectricityData> data)
        {
            var lastReadings = data.GroupBy(d => d.ApartmentNumber).Select(g => g.OrderByDescending(d => d.DateOfReading).FirstOrDefault()).ToList();
            var daysSinceLastReading = lastReadings.Select(d => new { ApartmentNumber = d.ApartmentNumber, Days = (DateTime.Now - d.DateOfReading).Days }).ToList();
            Console.WriteLine();
            Console.WriteLine("Days since last meter reading:");
            Console.WriteLine("------------------------------");
            foreach (var days in daysSinceLastReading)
            {
                Console.WriteLine($"Apartment {days.ApartmentNumber}: {days.Days} days");
            }
        }

        public static int ReadApartmentNumberFromConsole()
        {
            Console.Write("Enter apartment number: ");
            return int.Parse(Console.ReadLine());
        }

        public static double ReadCostPerKilowattFromConsole()
        {
            Console.Write("Enter cost per kilowatt: ");
            return double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
    }
}
