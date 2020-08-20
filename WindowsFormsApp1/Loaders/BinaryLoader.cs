using System.IO;
using WindowsFormsApp1.Interfaces;
using WindowsFormsApp1.Structures;

namespace WindowsFormsApp1.Loaders
{
    public class BinaryLoader : ILoader
    {
        /// <summary>
        /// Loading data from binary file
        /// </summary>
        /// <returns><see cref="StartData"/> object with data from binary file</returns>
        public StartData Load()
        {
            int height = StartData.DefaultHeight, width = StartData.DefaultWidth, 
                xCoord = StartData.DefaultX, yCoord = StartData.DefaultY;
            string text = StartData.DefaultText;
            bool check1 = StartData.DefaultCheck1, check2 = StartData.DefaultCheck2;
            using (BinaryReader br = new BinaryReader(new FileStream("./params.dat", FileMode.OpenOrCreate)))
            {
                if (br.BaseStream.Length > 0)
                {
                    height = br.ReadInt32();
                    width = br.ReadInt32();
                    xCoord = br.ReadInt32();
                    yCoord = br.ReadInt32();
                    check1 = br.ReadBoolean();
                    check2 = br.ReadBoolean();
                    text = br.ReadString();
                }

                return new StartData(height, width, xCoord, yCoord, text, check1, check2);
            }
        }

        /// <summary>
        /// Saving data into binary file
        /// </summary>
        /// <param name="data"><see cref="StartData"/> object with data to be saved</param>
        public void Save(StartData data)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream("./params.dat", FileMode.Create)))
            {
                bw.Write(data.Height);
                bw.Write(data.Width);
                bw.Write(data.Xcoord);
                bw.Write(data.Ycoord);
                bw.Write(data.Check1);
                bw.Write(data.Check2);
                bw.Write(data.Text);
            }
        }
    }
}
