using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationDetails.Models
{
    public class StaffDetails
    {
        public string StaffID;
        public required string StaffFirstName { get; set; }
        public required string StaffLastName { get; set; }
        public string? StaffOtherNames { get; set; }
        public string StaffFullName
        {
            get { return $"{StaffLastName} {StaffFirstName} {StaffOtherNames}"; }
        }

        public required string StaffRole { get; set; }

        public string StaffReportsToID { get; set; }
        
        
        

        public StaffDetails(string firstName, string lastName, string role, string reportsToID, string? otherNames = null)
        {
            StaffID = GenerateStaffID();  // You can implement this method to generate unique IDs
            StaffFirstName = firstName;
            StaffLastName = lastName;
            StaffOtherNames = otherNames;
            StaffRole = role;
            StaffReportsToID = reportsToID;
        }

        private static string GenerateStaffID()
        {
            string staffID = "EmpID";

            return staffID;
        }
    }
}
