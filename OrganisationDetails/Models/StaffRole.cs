using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationDetails.Models
{
    public class StaffRole
    {
        public string StaffRoleID;
        public string StaffRoleTitle;
        public Department[]? Department;

        
        public StaffRole(string roleID, string roleTitle, Department[] department) 
        {
            StaffRoleID = roleID;
            StaffRoleTitle = roleTitle;
            //Department[] allDepartments = new Department[]
            //{
            //    new Department(1, "Executives"),
            //    new Department(2, "Information Technology"),
            //    new Department(3, "Operations"),
            //    new Department(4, "Finance"),
            //    new Department(5, "Human Resources"),
            //    new Department(6, "Marketing"),
            //    new Department(7, "Sales"),
            //    new Department(8, "Research and Development"),
            //    new Department(9, "Customer Support")
            //      // Add more departments as needed
            //};
        }
    }
}
