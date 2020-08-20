using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Interfaces;
using WindowsFormsApp1.Loaders;

namespace WindowsFormsApp1.Providers
{
    public static class LoaderProvider
    {
        /// <summary>
        /// Provides loader to perform Load/Save operations
        /// </summary>
        /// <returns><see cref="ILoader"/> implementation</returns>
        public static ILoader GetLoader()
        {
            // uncomment neccessary 'return' statement
            //return new BinaryLoader();
            //return new RegistryLoader();
            //return new TxtLoader();
            return new XmlLoader();
        }
    }
}
