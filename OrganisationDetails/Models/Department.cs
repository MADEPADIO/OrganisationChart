using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationDetails.Models
{
    public class Department
    {
        public int ID;
        public string Name;


        public Department(int departmentID, string departmentName)
        {
            ID = departmentID;
            Name = departmentName;
        }
    }

    
}
