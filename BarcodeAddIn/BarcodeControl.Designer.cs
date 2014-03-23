namespace BarcodeAddIn
{
    partial class BarcodeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtContent = new System.Windows.Forms.TextBox();
            this.picEncodedBarCode = new System.Windows.Forms.PictureBox();
            this.propOptions = new System.Windows.Forms.PropertyGrid();
            this.cmbEncoderType = new System.Windows.Forms.ComboBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picEncodedBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(2, 29);
            this.txtContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(178, 38);
            this.txtContent.TabIndex = 0;
            // 
            // picEncodedBarCode
            // 
            this.picEncodedBarCode.BackColor = System.Drawing.SystemColors.Window;
            this.picEncodedBarCode.Location = new System.Drawing.Point(0, 91);
            this.picEncodedBarCode.Margin = new System.Windows.Forms.Padding(2);
            this.picEncodedBarCode.Name = "picEncodedBarCode";
            this.picEncodedBarCode.Size = new System.Drawing.Size(180, 146);
            this.picEncodedBarCode.TabIndex = 1;
            this.picEncodedBarCode.TabStop = false;
            this.picEncodedBarCode.Click += new System.EventHandler(this.insertBarcode_Click);
            // 
            // propOptions
            // 
            this.propOptions.Location = new System.Drawing.Point(2, 267);
            this.propOptions.Margin = new System.Windows.Forms.Padding(2);
            this.propOptions.Name = "propOptions";
            this.propOptions.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propOptions.Size = new System.Drawing.Size(178, 163);
            this.propOptions.TabIndex = 2;
            this.propOptions.ToolbarVisible = false;
            this.propOptions.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propOptions_PropertyValueChanged);
            // 
            // cmbEncoderType
            // 
            this.cmbEncoderType.FormattingEnabled = true;
            this.cmbEncoderType.Location = new System.Drawing.Point(2, 242);
            this.cmbEncoderType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEncoderType.Name = "cmbEncoderType";
            this.cmbEncoderType.Size = new System.Drawing.Size(179, 21);
            this.cmbEncoderType.TabIndex = 1;
            this.cmbEncoderType.SelectedIndexChanged += new System.EventHandler(this.cmbEncoderType_SelectedIndexChanged);
            // 
            // btnEncode
            // 
            this.btnEncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncode.Location = new System.Drawing.Point(2, 434);
            this.btnEncode.Margin = new System.Windows.Forms.Padding(2);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(178, 25);
            this.btnEncode.TabIndex = 3;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter text to decode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Click inside image to insert:";
            // 
            // BarcodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.cmbEncoderType);
            this.Controls.Add(this.propOptions);
            this.Controls.Add(this.picEncodedBarCode);
            this.Controls.Add(this.txtContent);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BarcodeControl";
            this.Size = new System.Drawing.Size(183, 537);
            this.Load += new System.EventHandler(this.BarcodeControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picEncodedBarCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.PictureBox picEncodedBarCode;
        private System.Windows.Forms.ComboBox cmbEncoderType;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.PropertyGrid propOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
