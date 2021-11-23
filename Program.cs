using System;
using System.Diagnostics;
using TreasuryChallenge.Model;
using TreasuryChallenge.controller;

namespace TreasuryChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tell me the number of lines do you need and press enter.");
            int inputValue = int.Parse(Console.ReadLine());
            var stopwatch = Stopwatch.StartNew();

            TemplateFile txtFile = new TXTFile("aleatory-file", 7);
            WriteFileController write = new WriteFileController(inputValue);     

            write.WriteCodeInFile(txtFile);

            stopwatch.Stop();
            System.Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}