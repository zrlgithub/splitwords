using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splitwords
{
    class fileHandler
    {
        public string clientName {get; set; }
        public string ipSource{ get; set; }
        string fileName { get; set; }
        

        public fileHandler(string ipSource, string clientName)
        {
            this.ipSource = ipSource;
            this.clientName = clientName;
        }
        public fileHandler(string nameFile)
        {
            this.fileName = nameFile;

            var splitName=nameFile;
            string[] splits = splitName.Split(' ');

            this.ipSource=splits[0];
            this.clientName = splits[1].ToString().Remove(splits[1].Length-4);
        }
    }
}
