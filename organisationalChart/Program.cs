using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organisationalChart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Staff ceo = new Staff("John Doe", "CEO");
            Staff cto = new Staff("Alice Smith", "CTO");
            Staff hrManager = new Staff("Bob Johnson", "HR Manager");
            Staff devManager = new Staff("Charlie Brown", "Development Manager");

            // Create an organizational chart
            Chart orgChart = new Chart();

            // Add staff to the chart
            orgChart.AddStaff(ceo, null);  // CEO reports to nobody
            orgChart.AddStaff(cto, ceo);   // CTO reports to CEO
            orgChart.AddStaff(hrManager, ceo);   // HR Manager reports to CEO
            orgChart.AddStaff(devManager, cto);  // Development Manager reports to CTO

            // Display the organizational chart
            orgChart.DisplayChart();
            Console.ReadLine();


        }
    }
}
