namespace WindowsFormsApp1.Structures
{
    public struct StartData
    {
        #region Static defaults
        /// <summary>
        /// Default height of the form
        /// </summary>
        public static int DefaultHeight = 150;

        /// <summary>
        /// Default width of the form
        /// </summary>
        public static int DefaultWidth = 220;

        /// <summary>
        /// Default X coordinate of starting position of the form
        /// </summary>
        public static int DefaultX = 0;

        /// <summary>
        /// Default Y coordinate of starting position of the form
        /// </summary>
        public static int DefaultY = 0;

        /// <summary>
        /// Default text of textbox in the form
        /// </summary>
        public static string DefaultText = string.Empty;

        /// <summary>
        /// Default state of first checkbox in the form
        /// </summary>
        public static bool DefaultCheck1 = false;

        /// <summary>
        /// Default state of second checkbox in the form
        /// </summary>
        public static bool DefaultCheck2 = false;
        #endregion

        #region Properties
        public int Height { get; set; }
        public int Width { get; set; }
        public int Xcoord { get; set; }
        public int Ycoord { get; set; }
        public string Text { get; set; }
        public bool Check1 { get; set; }
        public bool Check2 { get; set; }
        #endregion

        public StartData(int height, int width, int x, int y, string text, bool check1, bool check2)
        {
            Height = height;
            Width = width;
            Xcoord = x;
            Ycoord = y;
            Text = text;
            Check1 = check1;
            Check2 = check2;
        }
    }
}
