using OrganisationDetails.Models;



namespace OrganisationDetails
{
    public class Class1
    {
        Department[] allDepartments = new Department[]
         {
            new Department(1, "Executives"),
            new Department(2, "Information Technology"),
            new Department(3, "Operations"),
            new Department(4, "Finance"),
            new Department(5, "Human Resources"),
            new Department(6, "Marketing"),
            new Department(7, "Sales"),
            new Department(8, "Research and Development"),
            new Department(9, "Customer Support")
             // Add more departments as needed
         };

        public StaffRole CreateNewRoles()
        {
            StaffRole newRole = new StaffRole("001", "Chief Executive Officer", allDepartments);
            return newRole;
        }


    }
}