using Microsoft.Office.Tools.Ribbon;

namespace BarcodeAddIn
{
    public partial class BarcodeRibbon
    {
        private void BarcodeRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnShowBarcode_Click(object sender, RibbonControlEventArgs e)
        {
            if (!Globals.ThisAddIn.TaskPaneVisible)
            {
                Globals.ThisAddIn.AddAllBarcodeTaskPanes();
            }
            else
            {
                Globals.ThisAddIn.RemoveAllBarcodeTaskPanes();
            }
        }
    }
}