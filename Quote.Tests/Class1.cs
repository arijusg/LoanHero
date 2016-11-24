using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Quote.Tests
{
    [TestFixture]
    public class Class1
    {
        private readonly string _testMarketCsvPath = $"{AssemblyDirectory}{Path.DirectorySeparatorChar}market.csv";
        private List<Lender> _lenders;

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

        //[Test]
        //public void GenerateQuoteOutput()
        //{
        //    var consoleOut = new StringWriter();
        //    Console.SetOut(consoleOut);

        //    RateCalculator.Main(null);

        //    string result = consoleOut.ToString();

        //    string expectedOutput = $"Requested amount: £1000{Environment.NewLine}" +
        //                    $"Rate: 7.0%{Environment.NewLine}" +
        //                    $"Monthly repayment: £30.78{Environment.NewLine}" +
        //                    $"Total repayment: £1108.10{Environment.NewLine}";

        //    Assert.AreEqual(expectedOutput, result);
        //}

        [Test]
        public void GenerateQuoteOutput()
        {
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            RateCalculator.Main( new [] {"1000", _testMarketCsvPath});

            string result = consoleOut.ToString();

            string expectedOutput = $"Requested amount: £1000{Environment.NewLine}" +
                            $"Rate: 7.0%{Environment.NewLine}" +
                            $"Monthly repayment: £30.88{Environment.NewLine}" +
                            $"Total repayment: £1111.53{Environment.NewLine}";

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void LoadLenders()
        {
            var lenderReader = new LenderDataReader();
            var result = lenderReader.Read(_testMarketCsvPath);

            CollectionAssert.AreEqual(_lenders, result);
        }

        [Test]
        public void LoanCalculator()
        {
            int amountToBorrow = 1000;
            var calculator = new LoanCalculator(_lenders);
            LoanQuote quote = calculator.Calculate(amountToBorrow);

           // var expectedQuote = new LoanQuote(1000, 0.07M, 30.78M, 1108.10M); //TODO Wrong example
            var expectedQuote = new LoanQuote(1000, 0.07M, 30.88M, 1111.53M);
            Assert.AreEqual(expectedQuote, quote);
        }
       

        //36 months loans
        //arguments: market.csv, loan amount
        //combine porfolio with lowest loan rates
        ////////Give back money to higer rate lenders first? or all together

        //provide details monthly repayment and repayent amount
        //repayment amounts should be 2 decimals
        //rates of the load 1 decimal
        //loan amount £100 increments minimum 1000, max 15000 inclusive
        //If not posible to quote, inform : that it is not possible to provide a quote at that time.
        //monthly compounding interest

        //output
        /*
                cmd> [application]
                [market_file]
                [loan_amount]
                Requested amount: £XXXX
                Rate: X.X%
            Monthly repayment: £XXXX.XX
            Total repayment: £XXXX.XX

            */

        /* 
         Lender,Rate,Available
Bob,0.075,640
Jane,0.069,480
Fred,0.071,520
Mary,0.104,170
John,0.081,320
Dave,0.074,140
Angela,0.071,60

         */
    }
}
