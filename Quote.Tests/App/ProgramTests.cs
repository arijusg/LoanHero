using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Quote.Tests.App
{
    [TestFixture]
    public class ProgramTests
    {
        private string _testMarketCsvPath;

        [OneTimeSetUp]
        public void Init()
        {
            _testMarketCsvPath = $"{AssemblyDirectory}{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}market.csv";
        }

        //This is used to make nCrunch and Resharper play nicely 
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

        private string GetOutputFromTheApp(string[] args)
        {
            var fakeConsoleOutput = new StringWriter();
            Console.SetOut(fakeConsoleOutput);
            RateCalculator.Main(args);
            return fakeConsoleOutput.ToString();
        }

        [Test]
        public void GenerateQuoteOutput()
        {
            int loanAmount = 1000;
            string consoleOutput = GetOutputFromTheApp(new[] {loanAmount.ToString(), _testMarketCsvPath});

            string expectedOutput = $"Requested amount: £1000{Environment.NewLine}" +
                            $"Rate: 7.0%{Environment.NewLine}" +
                            $"Monthly repayment: £30.88{Environment.NewLine}" +
                            $"Total repayment: £1111.53{Environment.NewLine}";

            Assert.AreEqual(expectedOutput, consoleOutput);
        }

        [Test]
        public void LoanAmountIn100Increments()
        {
            int loanAmount = 1111;
            string consoleOutput = GetOutputFromTheApp(new[] { loanAmount.ToString(), _testMarketCsvPath });

            string expectedOutput = $"The amount you wish to borrow should be in increments of £100{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, consoleOutput);
        }

        [Test]
        public void LoanAmountMinimum1000()
        {
            int loanAmount = 50;
            string consoleOutput = GetOutputFromTheApp(new[] { loanAmount.ToString(), _testMarketCsvPath });

            string expectedOutput = $"The minimum amount you can borrow is £1000{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, consoleOutput);
        }

        [Test]
        public void LoanAmountMaximum15000()
        {
            int loanAmount = 20000;
            string consoleOutput = GetOutputFromTheApp(new[] { loanAmount.ToString(), _testMarketCsvPath });

            string expectedOutput = $"The maximum amount you can borrow is £15000{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, consoleOutput);
        }

        [Test]
        public void ItIsNotPossibleToProvideAQuoteAtThisTime()
        {
            int loanAmount = 15000;
            string consoleOutput = GetOutputFromTheApp(new[] { loanAmount.ToString(), _testMarketCsvPath });

            string expectedOutput = $"It is not possible to provide a quote at this time{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, consoleOutput);
        }

        //TODO Only testing happy path
        [Test]
        public void InvalidArgumentsEtc_WeAreTestingOnlyHappyPathForThisExercise()
        {
            string consoleOutput = GetOutputFromTheApp(null);

            string expectedOutput = $"Application error :({Environment.NewLine}";
            Assert.AreEqual(expectedOutput, consoleOutput);
        }
    }
}
