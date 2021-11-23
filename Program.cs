using System;
using System.Diagnostics;
using TreasuryChallenge.Model;
using TreasuryChallenge.controller;
using TreasuryChallenge.Common;

namespace TreasuryChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.NUMBER_OF_LINES_TO_ENTER);
            int inputValue = int.Parse(Console.ReadLine());
            var stopwatch = Stopwatch.StartNew();

            TemplateFile txtFile = new TXTFile(Constants.FILE_NAME, 7);
            WriteFileController write = new WriteFileController(inputValue);     

            write.WriteCodeInFile(txtFile);

            stopwatch.Stop();
            System.Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}