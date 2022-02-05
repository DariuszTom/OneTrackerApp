using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConForConsumeService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new DbService.OneTrackerDbServiceClient();
            int randomeNumber = new Random().Next();
            string expectedMsg = $"You entered: {randomeNumber}";
            Console.WriteLine(string.Equals(expectedMsg, host.GetData(randomeNumber)));
            Console.WriteLine(host.DataBaseExists());
            Console.WriteLine(host.UserInDB(1));
            var listOfDep = host.GetAllDepartmentsRecords();
            
            Console.ReadKey();
        }
    }
}
