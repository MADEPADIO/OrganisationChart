namespace TestTreeGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion

        private System.Windows.Forms.ToolTip tipColor;
        private System.Windows.Forms.Label lblBGColor;
        private System.Windows.Forms.Label lblLineColor;
        private System.Windows.Forms.Label lblBoxFillColor;
        private System.Windows.Forms.Label lblFontColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown nudBoxWidth;
        private System.Windows.Forms.NumericUpDown nudBoxHeight;
        private System.Windows.Forms.NumericUpDown nudMargin;
        private System.Windows.Forms.NumericUpDown nudHorizontalSpace;
        private System.Windows.Forms.NumericUpDown nudVerticalSpace;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.PictureBox picTree;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowChart;
        private System.Windows.Forms.Label lblNodeText;
        private System.Windows.Forms.Button btnRun100;
    }
}