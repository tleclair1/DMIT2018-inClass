using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLoan
{
    class Program
    {
        #region Fields and Constructors
        // THe readonly keyword means that the value for this field MUST be set via the constructor. After that, it CANNOT be changed.
        private readonly string[] _InputArguments;

        public Program(string[] args)
        {
            this._InputArguments = args;
        }
        #endregion

        #region Main Driver
        static void Main(string[] args)
        {
            Console.WriteLine("==-- Student Loan App --==");
            var app = new Program(args);
            app.Run();
        }

        private void Run()
        {
            if (_InputArguments == null || _InputArguments.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must include arguments when running this program.");
                Console.ResetColor();
                ShowHelp();
            }
            else if (_InputArguments[0] == "-h")
                ShowHelp();
            else if (_InputArguments[0] == "-c")
                ShowCredits();

            Console.WriteLine("\n\n\n\n");
        }
        #endregion

        #region Application Behaviours
        private void ShowHelp()
        {
            Console.WriteLine("Usage: -tba-");
            Console.WriteLine("Options:");
            Console.WriteLine("\t\t-h\tShow the help");
        }

        private void ShowCredits()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Created by Tripope Leclair");
            Console.ResetColor();
        }
        #endregion
    }
}
