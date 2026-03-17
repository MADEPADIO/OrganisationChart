using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Datatable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        void FillingDataGridUsingDataTable()
        {
            // Creates a new datatable and instances of the class Datacolumn in order to create new columns
            DataTable data = new DataTable();
            DataColumn staffId = new DataColumn("id", typeof(int));
            DataColumn staffName = new DataColumn("name", typeof(string));
            DataColumn staffRole = new DataColumn("Role", typeof(string));
            DataColumn Department = new DataColumn("Dept", typeof(string));
            DataColumn ReportingTo = new DataColumn("Reporting To", typeof(int));
            

            // Adds the Created Columns to the DataTable
            data.Columns.Add(staffId);
            data.Columns.Add(staffName);
            data.Columns.Add(staffRole);
            data.Columns.Add(Department);
            data.Columns.Add(ReportingTo);

            // Creates an instance of the datarow and different rows wrt the columns created.
            DataRow firstDataRow = data.NewRow();
            firstDataRow[0] = 1;
            firstDataRow[1] = "PADIO";
            firstDataRow[2] = "CEO";
            firstDataRow[3] = "Executives";
            firstDataRow[4] = DBNull.Value;

            DataRow secondDataRow = data.NewRow();
            secondDataRow[0] = 2;
            secondDataRow[1] = "Jeff";
            secondDataRow[2] = "CMO";
            secondDataRow[3] = "Executives";
            secondDataRow[4] = firstDataRow[0];

            DataRow thirdDataRow = data.NewRow();
            thirdDataRow[0] = 3;
            thirdDataRow[1] = "Womo";
            thirdDataRow[2] = "CFO";
            thirdDataRow[3] = "Executives";
            thirdDataRow[4] = firstDataRow[0];

            DataRow fourthDataRow = data.NewRow();
            fourthDataRow[0] = 4;
            fourthDataRow[1] = "Vantyse";
            fourthDataRow[2] = "CTO";
            fourthDataRow[3] = "Executives";
            fourthDataRow[4] = firstDataRow[0];

            DataRow fifthDataRow = data.NewRow();
            fifthDataRow[0] = 5;
            fifthDataRow[1] = "Femi";
            fifthDataRow[2] = "COO";
            fifthDataRow[3] = "Executives";
            fifthDataRow[4] = firstDataRow[0];

            DataRow sixthDataRow = data.NewRow();
            sixthDataRow[0] = 6;
            sixthDataRow[1] = "Pudding";
            sixthDataRow[2] = "CHRO";
            sixthDataRow[3] = "Executives";
            sixthDataRow[4] = firstDataRow[0];

            DataRow seventhDataRow = data.NewRow();
            seventhDataRow[0] = 7;
            seventhDataRow[1] = "Emma";
            seventhDataRow[2] = "Operations Manager";
            seventhDataRow[3] = "Operations";
            seventhDataRow[4] = fifthDataRow[0];

            DataRow eightDataRow = data.NewRow();
            eightDataRow[0] = 8;
            eightDataRow[1] = "Emeka";
            eightDataRow[2] = "Accounting Manager";
            eightDataRow[3] = "Finance";
            eightDataRow[4] = thirdDataRow[0];

            DataRow ninthDataRow = data.NewRow();
            ninthDataRow[0] = 9;
            ninthDataRow[1] = "Joshua";
            ninthDataRow[2] = "Public Relations";
            ninthDataRow[3] = "Marketing";
            ninthDataRow[4] = secondDataRow[0];

            DataRow tenthDataRow = data.NewRow();
            tenthDataRow[0] = 10;
            tenthDataRow[1] = "MADE";
            tenthDataRow[2] = "System Admin";
            tenthDataRow[3] = "Information Technology";
            tenthDataRow[4] = fourthDataRow[0];

            DataRow eleventhDataRow = data.NewRow();
            eleventhDataRow[0] = 11;
            eleventhDataRow[1] = "Grant";
            eleventhDataRow[2] = "Logistics";
            eleventhDataRow[3] = "Operations";
            eleventhDataRow[4] = fifthDataRow[0];

            DataRow twelfthDataRow = data.NewRow();
            twelfthDataRow[0] = 12;
            twelfthDataRow[1] = "Prosper";
            twelfthDataRow[2] = "IT Guy";
            twelfthDataRow[3] = "Information Technology";
            twelfthDataRow[4] = fourthDataRow[0];

            DataRow thirteeenthDataRow = data.NewRow();
            thirteeenthDataRow[0] = 13;
            thirteeenthDataRow[1] = "Joseph";
            thirteeenthDataRow[2] = "Financial Analyst";
            thirteeenthDataRow[3] = "Finance";
            thirteeenthDataRow[4] = thirdDataRow[0];

            DataRow fourteenthDataRow = data.NewRow();
            fourteenthDataRow[0] = 14;
            fourteenthDataRow[1] = "Daniel";
            fourteenthDataRow[2] = "Digital Marketing";
            fourteenthDataRow[3] = "Marketing";
            fourteenthDataRow[4] = secondDataRow[0];

            DataRow fifteenthDataRow = data.NewRow();
            fifteenthDataRow[0] = 15;
            fifteenthDataRow[1] = "Joan";
            fifteenthDataRow[2] = "Recruitment Officer";
            fifteenthDataRow[3] = "Human Resources";
            fifteenthDataRow[4] = sixthDataRow[0];

            DataRow sixteenthDataRow = data.NewRow();
            sixteenthDataRow[0] = 16;
            sixteenthDataRow[1] = "Benita";
            sixteenthDataRow[2] = "Training and Development";
            sixteenthDataRow[3] = "Human Resources";
            sixteenthDataRow[4] = sixthDataRow[0];

            // Adds the created Rows to the DataTable
            data.Rows.Add(firstDataRow);
            data.Rows.Add(secondDataRow);
            data.Rows.Add(thirdDataRow);
            data.Rows.Add(fourthDataRow);
            data.Rows.Add(fifthDataRow);
            data.Rows.Add(sixthDataRow);
            data.Rows.Add(seventhDataRow);
            data.Rows.Add(eightDataRow);
            data.Rows.Add(ninthDataRow);
            data.Rows.Add(tenthDataRow);
            data.Rows.Add(eleventhDataRow);
            data.Rows.Add(twelfthDataRow);
            data.Rows.Add(thirteeenthDataRow);
            data.Rows.Add(fourteenthDataRow);
            data.Rows.Add(fifteenthDataRow);
            data.Rows.Add(sixteenthDataRow);

            // This makes the DataTable to be viewed according to the columns and rows created
            StaffTable.ItemsSource = data.DefaultView;

        }

        // From the Loaded Event Trigger in the Properties of the DataTable Design View
        private void StaffTable_Loaded(object sender, RoutedEventArgs e)
        {
            FillingDataGridUsingDataTable();
        }
    }
}
