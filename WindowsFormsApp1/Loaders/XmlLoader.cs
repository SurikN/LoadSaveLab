using System;
using System.IO;
using System.Text;
using System.Xml;
using WindowsFormsApp1.Interfaces;
using WindowsFormsApp1.Structures;

namespace WindowsFormsApp1.Loaders
{
    class XmlLoader : ILoader
    {
        /// <summary>
        /// Loading data from XML file
        /// </summary>
        /// <returns><see cref="StartData"/> object with data from XML file</returns>
        StartData ILoader.Load()
        {
            int height, width, xCoord, yCoord;
            string text;
            bool check1, check2;
            //TODO: rewrite this to not contain exception-based code flow
            using (XmlTextReader x = new XmlTextReader(new StreamReader(new FileStream("./params.xml", FileMode.OpenOrCreate))))
            {
                try
                {
                    x.Read();
                    x.MoveToNextAttribute();
                    height = int.Parse(x.Value);
                    x.MoveToNextAttribute();
                    width = int.Parse(x.Value);
                    x.MoveToNextAttribute();
                    xCoord = int.Parse(x.Value);
                    x.MoveToNextAttribute();
                    yCoord = int.Parse(x.Value);
                    x.Read();
                    x.MoveToNextAttribute();
                    text = x.Value;
                    x.Read();
                    x.MoveToNextAttribute();
                    check1 = bool.Parse(x.Value);
                    x.Read();
                    x.MoveToNextAttribute();
                    check2 = bool.Parse(x.Value);
                }
                catch (Exception) // I know this is wrong and not really acceptble, but I'm writing this at 4 AM and have no other ideas
                {
                    height = StartData.DefaultHeight;
                    width = StartData.DefaultWidth;
                    xCoord = StartData.DefaultX;
                    yCoord = StartData.DefaultY;
                    text = StartData.DefaultText;
                    check1 = StartData.DefaultCheck1;
                    check2 = StartData.DefaultCheck2;
                }
            }
            return new StartData(height, width, xCoord, yCoord, text, check1, check2);
        }

        /// <summary>
        /// Saving data into XML file
        /// </summary>
        /// <param name="data"><see cref="StartData"/> object with data to be saved</param>
        void ILoader.Save(StartData data)
        {
            using (XmlTextWriter x = new XmlTextWriter("./params.xml", Encoding.Default))
            {
                x.WriteStartElement("Form");
                x.WriteAttributeString("Height", data.Height.ToString());
                x.WriteAttributeString("Width", data.Width.ToString());
                x.WriteAttributeString("Xcoord", data.Xcoord.ToString());
                x.WriteAttributeString("Ycoord", data.Ycoord.ToString());
                x.WriteStartElement("Textbox");
                x.WriteAttributeString("Text", data.Text);
                x.WriteEndElement();
                x.WriteStartElement("Checkbox1");
                x.WriteAttributeString("Checked", data.Check1.ToString());
                x.WriteEndElement();
                x.WriteStartElement("Checkbox2");
                x.WriteAttributeString("Checked", data.Check2.ToString());
                x.WriteEndElement();
            }
        }
    }
}
