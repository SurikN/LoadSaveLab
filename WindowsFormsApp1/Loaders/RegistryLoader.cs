using Microsoft.Win32;
using WindowsFormsApp1.Interfaces;
using WindowsFormsApp1.Structures;

namespace WindowsFormsApp1.Loaders
{
    class RegistryLoader : ILoader
    {

        static string userRoot = Registry.CurrentUser.Name;
        static string subkey = "FormParams";
        static string keyName = userRoot + "\\" + subkey;

        /// <summary>
        /// Loading data from registry
        /// </summary>
        /// <returns><see cref="StartData"/> object with data from registry</returns>
        public StartData Load()
        {
            int height, width, xCoord, yCoord;
            string text;
            bool check1, check2;
            // TryParse needed to register registry key and 'if' body will be called only once per device
            if(!int.TryParse(Registry.GetValue(keyName, "Height", StartData.DefaultHeight).ToString(), out height))
            {
                Registry.SetValue(keyName, "Height", StartData.DefaultHeight);
                Registry.SetValue(keyName, "Width", StartData.DefaultWidth);
                Registry.SetValue(keyName, "Xcoord", StartData.DefaultX);
                Registry.SetValue(keyName, "Ycoord", StartData.DefaultY);
                Registry.SetValue(keyName, "Text", StartData.DefaultText);
                Registry.SetValue(keyName, "Check1", StartData.DefaultCheck1);
                Registry.SetValue(keyName, "Check2", StartData.DefaultCheck2);
                height = StartData.DefaultHeight;
            }
             width = int.Parse(Registry.GetValue(keyName, "Width", StartData.DefaultWidth).ToString());
             xCoord = int.Parse(Registry.GetValue(keyName, "XCoord", StartData.DefaultX).ToString());
             yCoord = int.Parse(Registry.GetValue(keyName, "Ycoord", StartData.DefaultY).ToString());
             text = (string)Registry.GetValue(keyName, "Text", StartData.DefaultText);
             check1 = bool.Parse(Registry.GetValue(keyName, "Check1", StartData.DefaultCheck1).ToString());
             check2 = bool.Parse(Registry.GetValue(keyName, "Check2", StartData.DefaultCheck2).ToString());
            return new StartData(height, width, xCoord, yCoord, text, check1, check2);
        }

        /// <summary>
        /// Saving data into registry
        /// </summary>
        /// <param name="data"><see cref="StartData"/> object with data to be saved</param>
        public void Save(StartData data)
        {
            Registry.SetValue(keyName, "Height", data.Height);
            Registry.SetValue(keyName, "Width", data.Width);
            Registry.SetValue(keyName, "Xcoord", data.Xcoord);
            Registry.SetValue(keyName, "Ycoord", data.Ycoord);
            Registry.SetValue(keyName, "Text", data.Text);
            Registry.SetValue(keyName, "Check1", data.Check1);
            Registry.SetValue(keyName, "Check2", data.Check2);
        }
    }
}
