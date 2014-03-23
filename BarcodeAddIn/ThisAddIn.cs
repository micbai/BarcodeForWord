using Word = Microsoft.Office.Interop.Word;

namespace BarcodeAddIn
{
    public partial class ThisAddIn
    {
        // Main part of this section is based on Microsoft article:
        // Managing Task Panes in Multiple Word and InfoPath Documents
        // http://msdn.microsoft.com/en-us/library/bb264456(v=office.12).aspx
        // 

        private const string title = "mbc Barcode";
        private Microsoft.Office.Tools.CustomTaskPane _taskPane;
        private bool _taskPaneVisible;

        public bool TaskPaneVisible
        {
            get
            {
                return _taskPaneVisible;
            }
            set
            {
                _taskPaneVisible = value;
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _taskPaneVisible = false;
            Word.Application wordApplication;
            wordApplication = this.Application;

            wordApplication.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(wordApplication_DocumentOpen);
            ((Word.ApplicationEvents4_Event)wordApplication).NewDocument += new Word.ApplicationEvents4_NewDocumentEventHandler(wordApplication_NewDocument);
            wordApplication.DocumentChange += new Word.ApplicationEvents4_DocumentChangeEventHandler(wordApplication_DocumentChange);            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            Word.Application wordApplication;
            wordApplication = this.Application;
            wordApplication.DocumentOpen -= new Word.ApplicationEvents4_DocumentOpenEventHandler(wordApplication_DocumentOpen);
            ((Word.ApplicationEvents4_Event)wordApplication).NewDocument -= new Word.ApplicationEvents4_NewDocumentEventHandler(wordApplication_NewDocument);
            wordApplication.DocumentChange -= new Word.ApplicationEvents4_DocumentChangeEventHandler(wordApplication_DocumentChange);
        }

        public void AddAllBarcodeTaskPanes()
        {
            if (Globals.ThisAddIn.Application.Documents.Count > 0)
            {
                if (this.Application.ShowWindowsInTaskbar == true)
                {
                    foreach (Word.Document _doc in this.Application.Documents)
                    {
                        addBarcodeTaskPane(_doc);
                    }
                }
                else
                {
                    if (!_taskPaneVisible)
                    {
                        addBarcodeTaskPane(this.Application.ActiveDocument);
                    }
                }
                _taskPaneVisible = true;
            }
        }

        public void RemoveAllBarcodeTaskPanes()
        {
            for (int i = this.CustomTaskPanes.Count; i > 0; i--)
            {
                _taskPane = this.CustomTaskPanes[i - 1];
                if (_taskPane.Title == title)
                {
                    this.CustomTaskPanes.Remove(_taskPane);
                }
            }
            _taskPaneVisible = false;
        }

        private void addBarcodeTaskPane(Word.Document doc)
        {
            _taskPane = this.CustomTaskPanes.Add(new BarcodeControl(), title, doc.ActiveWindow);
            _taskPane.Visible = true;
        }

        private void wordApplication_NewDocument(Word.Document Doc)
        {
            if (_taskPaneVisible && this.Application.ShowWindowsInTaskbar)
            {
                addBarcodeTaskPane(Doc);
            }
        }

        private void wordApplication_DocumentOpen(Word.Document Doc)
        {
            if (_taskPaneVisible && this.Application.ShowWindowsInTaskbar)
            {
                addBarcodeTaskPane(Doc);
            }
        }

        private void wordApplication_DocumentChange()
        {
            // remove orphand panes
            for (int i = this.CustomTaskPanes.Count; i > 0; i--)
            {
                _taskPane = this.CustomTaskPanes[i - 1];
                if (_taskPane.Window == null)
                {
                    this.CustomTaskPanes.Remove(_taskPane);
                }
            }
        }

        public static void SelectionInsertClipboard()
        {
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;

            // Store the user's current Overtype selection
            bool userOvertype = Globals.ThisAddIn.Application.Options.Overtype;

            // Make sure Overtype is turned off.
            if (Globals.ThisAddIn.Application.Options.Overtype)
            {
                Globals.ThisAddIn.Application.Options.Overtype = false;
            }

            object objTrue = true;
            object objFalse = false;
            object objMissing = System.Reflection.Missing.Value;
            object objPlacement = Microsoft.Office.Interop.Word.WdOLEPlacement.wdFloatOverText;
            currentSelection.PasteSpecial(ref objMissing, ref objMissing, ref objPlacement, ref objMissing, ref objMissing, ref objMissing, ref objMissing);
            //currentSelection.Paste();

            // Restore the user's Overtype selection
            Globals.ThisAddIn.Application.Options.Overtype = userOvertype;
        }


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion VSTO generated code
    }
}