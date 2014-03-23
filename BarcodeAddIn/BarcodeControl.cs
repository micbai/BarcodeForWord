using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace BarcodeAddIn
{
    public partial class BarcodeControl : UserControl
    {
        private const string configOptions = "mbcBarcode.config";
        private EncodingOptions encodingOptions;

        /// <summary>
        /// Constructor
        /// </summary>
        public BarcodeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When starting up populate the combo box with available barcodes supplied by zxing
        /// try to restore previous settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarcodeControl_Load(object sender, EventArgs e)
        {
            foreach (var format in MultiFormatWriter.SupportedWriters)
                cmbEncoderType.Items.Add(format);

            loadEncodingSettings();
        }

        /// <summary>
        /// Listen to user activities when the selected bar code is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEncoderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEncoderType.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a barcode format first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                EncodingOptions options;
                switch ((BarcodeFormat)cmbEncoderType.SelectedItem)
                {
                    case BarcodeFormat.DATA_MATRIX:
                        options = new ZXing.Datamatrix.DatamatrixEncodingOptions
                        {
                            SymbolShape = ZXing.Datamatrix.Encoder.SymbolShapeHint.FORCE_SQUARE
                        };
                        break;

                    default:
                        options = new EncodingOptions();
                        break;
                }

                options.Height = encodingOptions.Height;
                options.Width = encodingOptions.Width;
                options.PureBarcode = encodingOptions.PureBarcode;
                encodingOptions = options;
                this.propOptions.SelectedObject = (EncodingOptions)options;
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Listen to the property panel for any user activities
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void propOptions_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            encodingOptions = (EncodingOptions)this.propOptions.SelectedObject;
        }

        /// <summary>
        /// When user clicks the Encode button a barcode is generated and the current settings are saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncode_Click(object sender, EventArgs e)
        {
            try
            {
                writeBarcode(txtContent.Text);
                saveEncodingSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        /// <summary>
        /// writeBarcode will generate the picture with the barcode
        /// </summary>
        /// <param name="text"></param>
        private void writeBarcode(string text)
        {
            try
            {
                var writer = new BarcodeWriter
                {
                    Format = (BarcodeFormat)cmbEncoderType.SelectedItem,
                    Options = encodingOptions
                };

                picEncodedBarCode.Image = writer.Write(text);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Copy the encoded image to the clip board and paste it into cursor location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertBarcode_Click(object sender, EventArgs e)
        {            
            try
            {
                Clipboard.SetImage(picEncodedBarCode.Image);
                if (picEncodedBarCode != null)
                    ThisAddIn.SelectionInsertClipboard();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Save the encoding settings after pressing the encode button to temp dir
        /// </summary>
        private void saveEncodingSettings()
        {
            string appFileName = Path.Combine(Path.GetTempPath(), configOptions);

            try
            {
                using (TextWriter textWriter = File.CreateText(appFileName))
                {
                    BarcodeSetting bc = new BarcodeSetting();
                    bc.Height = encodingOptions.Height;
                    bc.Width = encodingOptions.Width;
                    bc.Type = cmbEncoderType.SelectedItem.ToString();
                    bc.Text = txtContent.Text;
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(BarcodeSetting));
                    x.Serialize(textWriter, bc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cannot save Barcode Settings:" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }


        /// <summary>
        /// Load Encoding settings on startup from temp dir
        /// Default is DATA_MATRIX encoding
        /// Fill the combobox and call the writeBarcode function to show data
        /// </summary>
        private void loadEncodingSettings()
        {
            string appFileName = Path.Combine(Path.GetTempPath(), configOptions);
            encodingOptions = new EncodingOptions { Height = picEncodedBarCode.Height, Width = picEncodedBarCode.Width, PureBarcode = true };
            string barcodeFormat = "DATA_MATRIX";

            if (File.Exists(appFileName))
            {
                try
                {
                    using (TextReader textReader = File.OpenText(appFileName))
                    {
                        BarcodeSetting bc = new BarcodeSetting();
                        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(BarcodeSetting));
                        bc = (BarcodeSetting)x.Deserialize(textReader);
                        encodingOptions.Height = bc.Height;
                        encodingOptions.Width = bc.Width;
                        barcodeFormat = bc.Type;
                        txtContent.Text = bc.Text;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Cannot start Barcode plugin:" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            cmbEncoderType.SelectedItem = Enum.Parse(typeof(BarcodeFormat), barcodeFormat);
            writeBarcode(string.IsNullOrEmpty(txtContent.Text) ? "mbc" : txtContent.Text);
        }
    }
}