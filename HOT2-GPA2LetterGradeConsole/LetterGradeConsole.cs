using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Console;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace HOT2_GPA2LetterGradeConsole
{
    internal class LetterGradeConsole
    {
        static void Main(string[] args)
        {
            decimal grade = 0;
            bool line;
            string letter = "";

            while (true) { 
            WriteLine("Enter GPA");
            line = Decimal.TryParse(ReadLine(), out grade);                 
            if (grade >= 0M && grade < 1.0M)
            {
                letter = "F";
            }
            else if (grade >= 1.0M && grade < 1.5M)
            {
                letter = "D";
            }
            else if (grade >= 1.5M && grade < 2.5M)
            {
                letter = "C";
            }
            else if (grade >= 2.5M && grade < 3.2M)
            {
                letter = "B";
            }
            else if (grade >= 3.2M && grade <= 4.0M)
            {
                letter = "A";
            }
                if (grade <= 0M || grade > 4.0M)
                    WriteLine("GPA OUT OF RANGE");
                else if (!line)
                {
                    WriteLine("Your Letter Grade is : " + letter);
                }
        }
        }
    }
}