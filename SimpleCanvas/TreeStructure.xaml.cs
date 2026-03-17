using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace SimpleCanvas
{
    /// <summary>
    /// Interaction logic for TreeStructure.xaml
    /// </summary>
    public partial class TreeStructure : Window
    {
        private int numberOfRows;
        private IEnumerable dataItems;
        private DataTable dataTable;

        [Obsolete]
        public TreeStructure(DataTable dataTable, int numberOfRows)
        {
            //dataItems = FillingEmployeeHierarchyFromDataTable(dataTable);
            InitializeComponent();
            this.numberOfRows = numberOfRows;
            this.dataTable = dataTable;
            // Generate levels hierarchy
            Dictionary<string, List<string>> listofLevels = SetLevelsHierarchy(dataTable);
            DisplayNumberOfNodesPerLevel(listofLevels);
            DrawOrganizationalChart(listofLevels);
            //ScaleCanvasToFitOrganizationalChart();
        }




        [Obsolete]
        public void DrawOrganizationalChart(Dictionary<string, List<string>> listofLevels)
        {
            // Clear existing nodes
            DiagramCanvas.Children.Clear();

            // Set size of the canvas
            DiagramCanvas.Height = 1024;
            DiagramCanvas.Width = 1280;

            // Calculate chart width and height
            //double chartWidth = CalculateChartWidth(listofLevels);
            //double chartHeight = CalculateChartHeight(listofLevels);


            // Set size and spacing parameters
            //double rectWidth = 40; // Width of each rectangle
            //double rectHeight = 20; // Height of each rectangle
            double verticalSpacing = 100; // Vertical spacing between levels
            double horizontalSpacing = 100; // Horizontal spacing between nodes in the same level

            // Set initial position for the root nodes
            double initialX = DiagramCanvas.Width / 2;
            double initialY = 100;
            

            // Draw rectangles for each level
            foreach (var keyValuePair in listofLevels)
            {
                double startX = initialX - (keyValuePair.Value.Count * horizontalSpacing) / 2;
                double startY = initialY + (int.Parse(keyValuePair.Key.Substring(6)) - 1) * verticalSpacing;

                for (int i = 0; i < keyValuePair.Value.Count; i++)
                {
                    double nodeX = startX + i * horizontalSpacing; // Calculate the x-coordinate for each node
                    DataRow nodeData = dataTable.Select($"id = '{keyValuePair.Value[i]}'").FirstOrDefault();
                    if (nodeData != null)
                    {
                        // Get node name and role
                        string nodeName = nodeData["name"].ToString();
                        string nodeRole = nodeData["role"].ToString();

                        DrawRectangles(DiagramCanvas, nodeX, startY, nodeName, nodeRole, horizontalSpacing);
                    }

                }
            }
        }


        [Obsolete]
        public static void DrawRectangles(Canvas DiagramCanvas, double x, double y, string nodeName, string nodeRole, double horizontalSpacing)
        {
            // Create a TextBlock to display the name and role
            TextBlock textBlock = new TextBlock
            {
                Text = $"{nodeName}\n{nodeRole}",
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = horizontalSpacing - 10 // Adjust width to leave some padding
            };

            // Create a rectangle to contain the text
            Rectangle rect = new Rectangle
            {
                Width = MeasureTextWidth(textBlock) + 50,
                Height = MeasureTextHeight(textBlock),
                Fill = Brushes.LightBlue
            };

            // Position the rectangle and text block
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);


            // Add rectangle and text block to the canvas
            DiagramCanvas.Children.Add(rect);
            DiagramCanvas.Children.Add(textBlock);
        }
        // This function should scale the canvas to fit the entire organizational chart and provide enough spacing to avoid overlap
        //public void ScaleCanvasToFitOrganizationalChart()
        //{
        //    double chartWidth = CalculateChartWidth();
        //    double chartHeight = CalculateChartHeight();

        //    double canvasWidth = DiagramCanvas.Width;
        //    double canvasHeight = DiagramCanvas.Height;

        //    double widthScalingFactor = canvasWidth / chartWidth;
        //    double heightScalingFactor = canvasHeight / chartHeight;

        //    double scalingFactor = Math.Min(widthScalingFactor, heightScalingFactor);

        //    // Scale the canvas proportionally
        //    DiagramCanvas.Width = chartWidth * scalingFactor;
        //    DiagramCanvas.Height = chartHeight * scalingFactor;
        //}


        // Method to measure the width of a TextBlock
        [Obsolete]
        private static double MeasureTextWidth(TextBlock textBlock)
        {
            var formattedText = new FormattedText(
                textBlock.Text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch),
                textBlock.FontSize,
                Brushes.Black,
                new NumberSubstitution(),
                TextFormattingMode.Display);

            return formattedText.WidthIncludingTrailingWhitespace;
        }

        // Method to measure the height of a TextBlock
        [Obsolete]
        private static double MeasureTextHeight(TextBlock textBlock)
        {
            var formattedText = new FormattedText(
                textBlock.Text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch),
                textBlock.FontSize,
                Brushes.Black,
                new NumberSubstitution(),
                TextFormattingMode.Display);

            return formattedText.Height;
        }







        // THIS METHOD CREATES THE NUMBER OF LEVELS BASED ON THE GIVEN DATATABLE.
        // IT ALSO DISPLAYS THEM IN FORM OF A LIST AND THE NODES CONTAINED IN EACH LEVEL.
        public Dictionary<string, List<string>> SetLevelsHierarchy(DataTable dataTable)
        {
            Dictionary<string, List<string>> listofLevels = new Dictionary<string, List<string>>();

            // INITIALIZE LEVEL 1 LIST
            List<string> level1 = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                if ((row["Reporting To"] == DBNull.Value) || (row["Reporting To"].ToString() == null))
                {
                    level1.Add(row["id"].ToString());
                }
            }
            listofLevels.Add("Level 1", level1);

            // LOOP TO CREATE SUBSEQUENT LEVEL LISTS
            for (int level = 2; ; level++)
            {
                List<string> currentLevel = new List<string>();
                List<string> previousLevel = listofLevels[$"Level {level - 1}"];
                foreach (DataRow row in dataTable.Rows)
                {
                    string reportingToId = row["Reporting To"].ToString();
                    if (previousLevel.Contains(reportingToId))
                    {
                        currentLevel.Add(row["id"].ToString());
                    }
                }
                if (currentLevel.Count == 0)
                {
                    break; // BREAKS THE LOOP IF NO NODES ARE FOUND IN THE CURRENT LEVEL
                }
                listofLevels.Add($"Level {level}", currentLevel);
                
            }

            return listofLevels;

        }
        // Show level lists in a message box
        public void DisplayNumberOfNodesPerLevel(Dictionary<string, List<string>> listofLevels)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var keyValuePair in listofLevels)
            {
                sb.AppendLine($"{keyValuePair.Key} list:");
                foreach (string id in keyValuePair.Value)
                {
                    sb.AppendLine(id);
                }
            }
            MessageBox.Show(sb.ToString(), "Level Lists");
        }



        [Obsolete]
        //private double CalculateChartWidth(Dictionary<string, List<string>> listofLevels, DataTable dataTable)
        //{
        //    double maxWidth = 0;

        //    // Iterate through all nodes to find the maximum width
        //    foreach (var keyValuePair in listofLevels)
        //    {
        //        for (int i = 0; i < keyValuePair.Value.Count; i++)
        //        {
        //            DataRow nodeData = dataTable.Select($"id = '{keyValuePair.Value[i]}'").FirstOrDefault();
        //            if (nodeData != null)
        //            {
        //                string nodeName = nodeData["name"].ToString();
        //                string nodeRole = nodeData["role"].ToString();

        //                TextBlock textBlock = new TextBlock
        //                {
        //                    Text = nodeName + "\n" + nodeRole,
        //                    FontFamily = new FontFamily("Arial"), // You can adjust the font family as needed
        //                    FontSize = 12, // You can adjust the font size as needed
        //                    FontWeight = FontWeights.Normal // You can adjust the font weight as needed
        //                };

        //                // Calculate the width of the rectangle based on the length of the text
        //                double textWidth = MeasureTextWidth(textBlock);
        //                double nodeWidth = textWidth + 20; // Add padding

        //                // Update maxWidth if necessary
        //                if (nodeWidth > maxWidth)
        //                {
        //                    maxWidth = nodeWidth;
        //                }
        //            }
        //        }
        //    }

        //    return maxWidth;
        //}

        //private double CalculateChartHeight(Dictionary<string, List<string>> listofLevels, DataTable dataTable)
        //{
        //    double totalLevels = listofLevels.Count;
        //    double verticalSpacing = 100; // Vertical spacing between levels

        //    // Calculate the total height required based on the number of levels and vertical spacing
        //    double totalHeight = totalLevels * verticalSpacing;

        //    return totalHeight;
        //}




        private void DrawLine(double x1, double y1, double x2, double y2)
            {
                Line line = new Line
                {
                    X1 = x1,
                    Y1 = y1,
                    X2 = x2,
                    Y2 = y2,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                DiagramCanvas.Children.Add(line);
            }
    }

















    

    //public static void DisplayNodes()
    //{

    //}

    





}

















/*// EDIT: THIS IS WRONG, IT COUNTS JUST THE NUMBER OF UNIQUE REPORTING TO IDs THAT EXIST IN A GIVEN DATATABLE.
      // THERE IS NO USE FOR IT RIGHT NOW.
      public int CreateNumberOfLevels(DataTable dataTable)
      {
          List<string> levels = new List<string>();
          foreach (DataRow row in dataTable.Rows)
          {

              if (!levels.Contains(row["Reporting To"].ToString()))
                  levels.Add(row["Reporting To"].ToString());

          }
          List<string> viewLevels = levels;
          return viewLevels.Count;
      }

      public int GetViewLevelsCount(DataTable dataTable)
      {
          // Call the existing method to count the levels
          return CreateNumberOfLevels(dataTable);
      }*/
























/*
      //private void DrawEmployeeNode(Employee employee, double x, double y)
      //{
      //    // Draw a node (ellipse) for the employee
      //    Rectangle ellipse = new Rectangle
      //    {
      //        Width = 40,
      //        Height = 20,
      //        Fill = Brushes.LightBlue
      //    };

      //    // Set the position of the ellipse
      //    Canvas.SetLeft(ellipse, x - ellipse.Width / 2);
      //    Canvas.SetTop(ellipse, y - ellipse.Height / 2);




      //    // Draw a line connecting the parent and child nodes
      //    foreach (Employee child in employee.Children)
      //    {
      //        DrawLine(x, y, child.X, child.Y);
      //    }

      //    // Add the ellipse to the canvas
      //    DiagramCanvas.Children.Add(ellipse);

      //    // Set the position of the employee on the canvas
      //    employee.X = x;
      //    employee.Y = y;

      //    // Recursively draw child nodes
      //    for (int i = 0; i < employee.Children.Count; i++)
      //    {
      //        double childX = x + (i - employee.Children.Count / 2.0) * 60; // Adjust for horizontal spacing
      //        double childY = y + 100; // Adjust for vertical spacing
      //        DrawEmployeeNode(employee.Children[i], childX, childY);


      //    }


      //}

      //public List<Employee> FillingEmployeeHierarchyFromDataTable(DataTable data)
      //{
      //    List<Employee> employees = new List<Employee>();

      //    //var x = data.Rows;
      //    foreach (DataRow row in data.Rows)
      //    {

      //        Employee employee = new Employee
      //        {
      //            Id = row["id"].ToString(),
      //            Name = row["name"].ToString(),
      //            Role = row["Role"].ToString(),
      //            Department = row["Dept"].ToString()
      //        };

      //        string reportingToId = row["Reporting To"].ToString();
      //        if (!string.IsNullOrEmpty(reportingToId))
      //        {
      //            // Find the parent employee in the list
      //            Employee parentEmployee = employees.FirstOrDefault(e => e.Id == reportingToId);
      //            if (parentEmployee != null)
      //            {
      //                parentEmployee.Children.Add(employee);
      //            }
      //        }
      //        else
      //        {
      //            // Employee is a root node
      //            employees.Add(employee);
      //        }
      //    }
      //    //var x = employees;
      //    return employees;
      //}



      */

/*
 /// Store the parent nodes and their children
//List<TreeNode> rootNodes = new List<TreeNode>();

//// Loop through each row in the DataTable to map the child nodes to the parent nodes

//foreach (DataRowView parentRowView in dataItems)
//{
//    DataRow parentNode = parentRowView.Row;

//    // Create a TreeNode for the parent
//    TreeNode parentTreeNode = new TreeNode(parentNode["Reporting To"].ToString()) { ID = parentNode["id"].ToString() };

//    foreach (DataRowView childRowView in dataItems)
//    {
//        DataRow childNode = childRowView.Row;
//        if (childNode["Reporting To"].ToString() == parentNode["id"].ToString())
//        {
//            // Create a TreeNode for the child
//            TreeNode childTreeNode = new TreeNode(childNode["Reporting To"].ToString()) { ID = childNode["id"].ToString() };

//            // Add the child to the parent
//            parentTreeNode.AddChildNode(childNode["id"].ToString(), new List<TreeNode> { childTreeNode }, childNode["Reporting To"].ToString());
//        }
//    }
//    // Add the parent to the list of root nodes
//    rootNodes.Add(parentTreeNode);
//}

//public class NodePositionsManager
//{
//    private static Canvas DiagramCanvas;
//    private IEnumerable<DataRowView> dataItems;
//    private List<TreeNode> childNode;
//    public List<NodePositions> StoreNodePositions { get; private set; }

//    public NodePositionsManager()
//    {
//        StoreNodePositions = new List<NodePositions>();
//    }

//    // You can add methods here to manipulate the list if needed
//    public void AddNodePosition(NodePositions nodePosition)
//    {
//        StoreNodePositions.Add(nodePosition);
//    }

//    // Set positions based on the tree structure
//    public void SetNodePositions(TreeNode rootNode, double top, double left)
//    {
//        SetNodePositionRecursive(rootNode, top, left);
//    }

//    private void SetNodePositionRecursive(TreeNode node, double top, double left)
//    {
//        NodePositions nodePosition = new NodePositions
//        {
//            ID = node.ID,
//            Top = top,
//            Left = left
//        };

//        AddNodePosition(nodePosition);

//        // Set positions for child nodes
//        double childTop = top + 50; // You can adjust the spacing as needed
//        double childLeft = left;

//        foreach (var child in node.ChildrenIDs)
//        {
//            SetNodePositionRecursive(child, childTop, childLeft);
//            childLeft += 100; // You can adjust the horizontal spacing as needed

//            // Create a Rectangle to represent the node
//            Rectangle nodes = new Rectangle
//            {
//                Width = 80,
//                Height = 30,
//                Fill = Brushes.LightBlue, // Adjust as needed
//                Stroke = Brushes.Black,
//                StrokeThickness = 1
//            };



//            DrawLine(left + 40, top, childLeft + 40, childTop + 30);



//            // Add a label to display the name
//            Label nameLabel = new Label
//            {
//                Content = $"{childNode[1].ToString()}\n{childNode[2].ToString()}",
//                HorizontalAlignment = HorizontalAlignment.Center,
//                VerticalAlignment = VerticalAlignment.Center
//            };

//            // Set the position of the label on the Canvas
//            Canvas.SetLeft(nameLabel, left);
//            Canvas.SetTop(nameLabel, top);

//            // Add the label to the Canvas
//            DiagramCanvas.Children.Add(nameLabel);

//        }
//    }

//public class NodePositions
//{
//    public string ID { get; set; }
//    public double Top { get; set; }
//    public double Left { get; set; }

//    public List<NodePositions> storeNodePositions = new List<NodePositions>();
//}
*/


/*
//{ 
//
// THIS WAS THE PREVIOUS CODE USED TO DRAW THE CHART IF UNCOMMENTED, SHOULD BE  PLACED WITHIN THE DRAWNODE METHOD ABOVE AS IS!!!

// Find the root node (where ReportingTo is DBNull.Value or null)
//DataRowView rootNodeView = null;
//foreach (DataRowView rowView in dataItems)
//{
//    DataRow row = rowView.Row;
//    if (row["Reporting To"] == DBNull.Value || row["Reporting To"] == null)
//    {
//        rootNodeView = rowView;
//        break;
//    }
//}

//if (rootNodeView == null)
//{
//    MessageBox.Show("Root node not found!");
//    return;
//}

//DataRow rootNodeRow = rootNodeView.Row;

//// Add the root node at the top
//double rootLeft = 400; // Adjust as needed
//double rootTop = 20; // Adjust as needed

//Rectangle rootNode = new Rectangle
//{
//    Width = 80,
//    Height = 30,
//    Fill = Brushes.LightGreen, // Adjust as needed
//    Stroke = Brushes.Black,
//    StrokeThickness = 1
//};


//// Set the position of the root node on the Canvas
//Canvas.SetLeft(rootNode, rootLeft);
//Canvas.SetTop(rootNode, rootTop);

//// Add the root node to the Canvas
//DiagramCanvas.Children.Add(rootNode);

//// Add a label for the root node
//Label rootLabel = new Label
//{
//    Content = $"{rootNodeRow["name"].ToString()}\n{rootNodeRow["role"].ToString()}",
//    HorizontalAlignment = HorizontalAlignment.Center,
//    VerticalAlignment = VerticalAlignment.Center
//};

//// Set the position of the root label on the Canvas
//Canvas.SetLeft(rootLabel, rootLeft);
//Canvas.SetTop(rootLabel, rootTop);

//// Add the root label to the Canvas
//DiagramCanvas.Children.Add(rootLabel);

//    foreach (DataRowView rowView in dataItems)
//{
//    DataRow row = rowView.Row;

//    if (row == rootNodeRow)
//        continue; // Skip drawing the root node again

//    double left = 100 * Convert.ToInt32(row["id"]); // Adjust as needed
//    double top = 100 * Convert.ToInt32(row["Reporting To"]) + 70; // Adjust as needed

//    // Create a Rectangle to represent the node
//    Rectangle node = new Rectangle
//    {
//        Width = 80,
//        Height = 30,
//        Fill = Brushes.LightBlue, // Adjust as needed
//        Stroke = Brushes.Black,
//        StrokeThickness = 1
//    };

//    // Set the position of the node on the Canvas
//    Canvas.SetLeft(node, left);
//    Canvas.SetTop(node, top);

//    // Add the node to the Canvas
//    DiagramCanvas.Children.Add(node);

//foreach (DataRowView   in Title)
//{

//}

//foreach (DataRowView rowView2 in dataItems)
//{
//    DataRow row2= rowView2.Row;
//    if (row2 == rootNodeRow)
//        continue; // Skip drawing the root node again
//    if (Convert.ToInt32(row2["Reporting To"]) == Convert.ToInt32(rootNodeView["id"]))
//    {
//        // Draw a line connecting nodes based on the "Reporting To" column
//        DrawLine(left + 40, top, rootLeft + 40, rootTop + 30);
//    }
//}

//else if ((row["Reporting To"] != rootNodeRow["id"]) && (row["Reporting To"] == row["id"]))
//{
//    DrawLine(left + 40, top, left + 40, top + 30);
//}

//switch (row["id"])
//{
//    case row["Reporting To"]:
//        DrawLine(left + 40, top, rootLeft + 40, rootTop + 30);
//        break;
//    default:
//}


//    // Add a label to display the name
    //Label nameLabel = new Label
    //{
    //    Content = $"{row["name"].ToString()}\n{row["role"].ToString()}",
    //    HorizontalAlignment = HorizontalAlignment.Center,
    //    VerticalAlignment = VerticalAlignment.Center
    //};

//    // Set the position of the label on the Canvas
//    Canvas.SetLeft(nameLabel, Left);
//    Canvas.SetTop(nameLabel, top);

//    // Add the label to the Canvas
//    DiagramCanvas.Children.Add(nameLabel);
//}
// this method redraws the tree diagram based on the size of the canvas
//private void DiagramCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
//{
//    // Adjust the size of the Canvas when the grid size changes
//    DiagramCanvas.Width = e.NewSize.Width;
//    DiagramCanvas.Height = e.NewSize.Height;
//}

//}
*/