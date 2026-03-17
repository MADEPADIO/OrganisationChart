using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Forms;
using TreeGenerator;
using System.Xml;

namespace TreeStructure
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

        private void btnShowTree_Click(object sender, EventArgs e)
        {

        }
        // private TreeGenerator.
        private TreeBuilder myTree = null;
        private void ShowTree()
        {
            picTree.Image = Image.FromStream(myTree.GenerateTree(-1, -1, "1", System.Drawing.Imaging.ImageFormat.Bmp));
            //picTree.Image.Save(@"d:\temp\1.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private void SetControlValues()
        {
            if (myTree != null)
            {
                //lblBGColor.BackColor = myTree.BGColor;
                // lblBoxFillColor.BackColor = myTree.BoxFillColor;
                // lblFontColor.BackColor = myTree.FontColor;
                // lblLineColor.BackColor = myTree.LineColor;
                nudBoxHeight.Value = Convert.ToDecimal(myTree.BoxHeight);
                nudBoxWidth.Value = Convert.ToDecimal(myTree.BoxWidth);
                nudFontSize.Value = Convert.ToDecimal(myTree.FontSize);
                nudHorizontalSpace.Value = Convert.ToDecimal(myTree.HorizontalSpace);
                nudLineWidth.Value = Convert.ToDecimal(myTree.LineWidth);
                nudMargin.Value = Convert.ToDecimal(myTree.Margin);
                nudVerticalSpace.Value = Convert.ToDecimal(myTree.VerticalSpace);


            }

        }

        private void lblFontColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.FontColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblBoxFillColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.BoxFillColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblLineColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.LineColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblBGColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.BGColor = colorDialog1.Color;
            ShowTree();
        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            myTree.LineWidth = (float)nudLineWidth.Value;
            ShowTree();
        }

        private void nudFontSize_ValueChanged(object sender, EventArgs e)
        {
            myTree.FontSize = (int)nudFontSize.Value;
            ShowTree();
        }

        private void nudVerticalSpace_ValueChanged(object sender, EventArgs e)
        {
            myTree.VerticalSpace = (int)nudVerticalSpace.Value;
            ShowTree();
        }

        private void nudHorizontalSpace_ValueChanged(object sender, EventArgs e)
        {
            myTree.HorizontalSpace = (int)nudHorizontalSpace.Value;
            ShowTree();
        }

        private void nudMargin_ValueChanged(object sender, EventArgs e)
        {
            myTree.Margin = (int)nudMargin.Value;
            ShowTree();
        }

        private void nudBoxHeight_ValueChanged(object sender, EventArgs e)
        {
            myTree.BoxHeight = (int)nudBoxHeight.Value;
            ShowTree();
        }

        private void nudBoxWidth_ValueChanged(object sender, EventArgs e)
        {
            myTree.BoxWidth = (int)nudBoxWidth.Value;
            ShowTree();
        }

        private void picOrgChart_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle currentRect;
            //determine if the mouse clicked on a box, if so, show the  node description.
            string SelectedNode = "No Node";
            //find the node
            foreach (XmlNode oNode in myTree.xmlTree.SelectNodes("//Node"))
            {
                //iterate through all nodes until found.
                currentRect = myTree.getRectangleFromNode(oNode);
                if (e.X >= currentRect.Left &&
                    e.X <= currentRect.Right &&
                    e.Y >= currentRect.Top &&
                    e.Y <= currentRect.Bottom)
                {
                    SelectedNode = oNode.Attributes["nodeDescription"].InnerText;
                    break;
                }


            }

            //MessageBox.Show(SelectedNode);
            lblNodeText.Text = string.Format("Last Clicked:{0}", SelectedNode);
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            ShowTree();

        }

    }
}
