using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Quote.Tests
{
    public class LenderDataReaderTests
    {
        private string _testMarketCsvPath;
        private List<Lender> _lenders;

        [OneTimeSetUp]
        public void InitOnce()
        {
            _testMarketCsvPath = $"{AssemblyDirectory}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}market.csv";
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        [SetUp]
        public void Init()
        {
            _lenders = new List<Lender>
            {
                new Lender("Bob", 0.075M, 640),
                new Lender("Jane", 0.069M, 480),
                new Lender("Fred", 0.071M, 520),
                new Lender("Mary", 0.104M, 170),
                new Lender("John", 0.081M, 320),
                new Lender("Dave", 0.074M, 140),
                new Lender("Angela", 0.071M, 60)
            };
        }

        [Test]
        public void LoadLenders()
        {
            var lenderReader = new LenderDataReader();
            var result = lenderReader.Read(_testMarketCsvPath);

            CollectionAssert.AreEqual(_lenders, result);
        }
    }
}
