using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quote
{
    public class LenderDataReader
    {
        public List<Lender> Read(string filePath)
        {
            var lenders = new List<Lender>();

            using (var reader = new StreamReader(File.OpenRead(filePath)))
            {
                reader.ReadLine(); //Skip first line

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    string name = values[0];
                    decimal interestRate = Convert.ToDecimal(values[1]);
                    int availableCash = Convert.ToInt32(values[2]);
                    
                    lenders.Add(new Lender(name, interestRate, availableCash));
                }
                return lenders;
            }
            // var reader = new StreamReader(File.OpenRead(@"C:\test.csv"));
            //List<string> listA = new List<string>();
            //List<string> listB = new List<string>();
            //while (!reader.EndOfStream)
            //{
            //    var line = reader.ReadLine();
            //    var values = line.Split(';');

            //    listA.Add(values[0]);
            //    listB.Add(values[1]);
            //}
        }
    }
}
