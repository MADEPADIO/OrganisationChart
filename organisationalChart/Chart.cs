using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organisationalChart
{
    internal class Chart
    {
        private List<Staff> staffList;

        public Chart()
        {
            staffList = new List<Staff>();
        }

        public void AddStaff(Staff staff, Staff reportsTo)
        {
            staff.ReportsTo = reportsTo;
            staffList.Add(staff);
        }

        public void DisplayChart()
        {
            foreach (var staff in staffList)
            {
                Console.WriteLine($"{staff} reports to {staff.ReportsTo?.Name ?? "Nobody"}");
            }
        }
    }
}
