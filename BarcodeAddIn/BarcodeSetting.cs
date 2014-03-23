using System;

namespace BarcodeAddIn
{
    [Serializable]
    public class BarcodeSetting
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }
    }
}