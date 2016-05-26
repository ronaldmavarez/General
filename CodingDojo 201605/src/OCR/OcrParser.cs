using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR
{
    public class OcrParser
    {
        const string One = "     |  |";
        const string Two = " _  _||_ ";
        const string Three = " _  _| _|";
        const string Four = "   |_|  |";
        const string Five = " _ |_  _|";
        const string Six = " _ |_ |_|";
        const string Seven = " _   |  |";
        const string Eight = " _ |_||_|";
        const string Nine = " _ |_| _|";

        private static Dictionary<string, string> _numbers = new Dictionary<string, string>
        {
            { One,"1" },
            { Two,"2" },
            { Three,"3" },
            { Four,"4" },
            { Five,"5" },
            { Six,"6" },
            { Seven,"7" },
            { Eight,"8" },
            { Nine,"9" },
        };


        public string Parse(string input)
        {
            if (input.Length <= 6)
            {
                return "";
            }
            var currentNumber = new StringBuilder();
            var rawInput = input.Replace("\r", "");
            var lines = rawInput.Split('\n').ToArray();
            if (lines[0].Length <3)
            {
                return "";
            }
            currentNumber.Append(lines[0].Substring(0, 3));
            currentNumber.Append(lines[1].Substring(0, 3));
            currentNumber.Append(lines[2].Substring(0, 3));

            var number = GetNumber(currentNumber.ToString());

            if (number == null)
                return "";
            if (lines[0].Length <= 3)
            {
                return number;
            }
            var theRest = new StringBuilder();
            theRest.Append(lines[0].Substring(3));
            theRest.AppendLine("");

            theRest.Append(lines[1].Substring(3));
            theRest.AppendLine("");

            theRest.Append(lines[2].Substring(3));
            theRest.AppendLine("");
            
            return $"{number}{Parse(theRest.ToString())}";
            //return number + Parse(theRest.ToString());
        }

        private string GetNumber(string input)
        {
            if (_numbers.ContainsKey(input))
                return _numbers[input];
            else
                return "?";

        }
    }
}