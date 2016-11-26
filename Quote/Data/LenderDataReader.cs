using System;
using System.Collections.Generic;
using System.IO;
using Quote.Models;

namespace Quote
{
    public class LenderDataReader
    {
        public List<Lender> Read(string filePath)
        {
            var lenders = new List<Lender>();

            using (var reader = new StreamReader(File.OpenRead(filePath)))
            {
                reader.ReadLine(); //TODO //Skip first line, validate

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
        }
    }
}
