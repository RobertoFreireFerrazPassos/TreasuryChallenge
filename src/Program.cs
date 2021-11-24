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

            IContent content = new Content(7, inputValue);
            IFile file = new TXTFile();
            WriteFileController write = new WriteFileController(file, content);

            write.WriteCodeInFile(inputValue);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}