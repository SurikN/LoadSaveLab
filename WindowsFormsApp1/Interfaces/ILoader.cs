using WindowsFormsApp1.Structures;

namespace WindowsFormsApp1.Interfaces
{
    public interface ILoader
    {
        /// <summary>
        /// Loading data from source
        /// </summary>
        /// <returns><see cref="StartData"/> object with data from source</returns>
        StartData Load();

        /// <summary>
        /// Saving data into depository
        /// </summary>
        /// <param name="data"><see cref="StartData"/> object with data to be saved</param>
        void Save(StartData data);
    }
}
