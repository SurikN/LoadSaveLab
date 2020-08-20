using System.IO;
using WindowsFormsApp1.Interfaces;
using WindowsFormsApp1.Structures;

namespace WindowsFormsApp1.Loaders
{
    class TxtLoader : ILoader
    {
        /// <summary>
        /// Loading data from text file
        /// </summary>
        /// <returns><see cref="StartData"/> object with data from text file</returns>
        StartData ILoader.Load()
        {
            int height = StartData.DefaultHeight, width = StartData.DefaultWidth, 
                xCoord = StartData.DefaultX, yCoord = StartData.DefaultY;
            string text = StartData.DefaultText;
            bool check1 = StartData.DefaultCheck1, check2 = StartData.DefaultCheck2;
            using (StreamReader sr = new StreamReader(new FileStream("./params.txt", FileMode.OpenOrCreate)))
            {
                if (!sr.EndOfStream)
                {
                    height = int.Parse(sr.ReadLine());
                    width = int.Parse(sr.ReadLine());
                    xCoord = int.Parse(sr.ReadLine());
                    yCoord = int.Parse(sr.ReadLine());
                    text = sr.ReadLine();
                    check1 = bool.Parse(sr.ReadLine());
                    check2 = bool.Parse(sr.ReadLine());
                }
            }
            return new StartData(height, width, xCoord, yCoord, text, check1, check2);
        }

        /// <summary>
        /// Saving data into text file
        /// </summary>
        /// <param name="data"><see cref="StartData"/> object with data to be saved</param>
        void ILoader.Save(StartData data)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("./params.txt", FileMode.Create)))
            {
                sw.WriteLine(data.Height);
                sw.WriteLine(data.Width);
                sw.WriteLine(data.Xcoord);
                sw.WriteLine(data.Ycoord);
                sw.WriteLine(data.Text);
                sw.WriteLine(data.Check1);
                sw.WriteLine(data.Check2);
            }
        }
    }
}
