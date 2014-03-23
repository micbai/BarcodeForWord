namespace BarcodeAddIn
{
    partial class BarcodeRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public BarcodeRibbon()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeRibbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpBarcode = this.Factory.CreateRibbonGroup();
            this.btnShowBarcode = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpBarcode.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpBarcode);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // grpBarcode
            // 
            this.grpBarcode.Items.Add(this.btnShowBarcode);
            this.grpBarcode.Label = "mbc Barcode";
            this.grpBarcode.Name = "grpBarcode";
            // 
            // btnShowBarcode
            // 
            this.btnShowBarcode.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnShowBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnShowBarcode.Image")));
            this.btnShowBarcode.Label = " ";
            this.btnShowBarcode.Name = "btnShowBarcode";
            this.btnShowBarcode.ShowImage = true;
            this.btnShowBarcode.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnShowBarcode_Click);
            // 
            // BarcodeRibbon
            // 
            this.Name = "BarcodeRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.BarcodeRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpBarcode.ResumeLayout(false);
            this.grpBarcode.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpBarcode;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnShowBarcode;
    }

    partial class ThisRibbonCollection
    {
        internal BarcodeRibbon BarcodeRibbon
        {
            get { return this.GetRibbon<BarcodeRibbon>(); }
        }
    }
}
