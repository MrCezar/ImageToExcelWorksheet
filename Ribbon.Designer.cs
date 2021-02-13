
namespace ImageToExcelWorksheet
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.ImgToExcelWorksheet = this.Factory.CreateRibbonGroup();
            this.btnOpenMainWindow = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.ImgToExcelWorksheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.ImgToExcelWorksheet);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // ImgToExcelWorksheet
            // 
            this.ImgToExcelWorksheet.Items.Add(this.btnOpenMainWindow);
            this.ImgToExcelWorksheet.Label = "Image To Excel Worksheet";
            this.ImgToExcelWorksheet.Name = "ImgToExcelWorksheet";
            // 
            // btnOpenMainWindow
            // 
            this.btnOpenMainWindow.Label = "Open Add-in";
            this.btnOpenMainWindow.Name = "btnOpenMainWindow";
            this.btnOpenMainWindow.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOpenMainWindow_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.ImgToExcelWorksheet.ResumeLayout(false);
            this.ImgToExcelWorksheet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ImgToExcelWorksheet;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOpenMainWindow;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
