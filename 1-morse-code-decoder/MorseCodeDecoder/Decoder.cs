using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCodeDecoder
{
    public class Decoder
    {
        private static readonly Dictionary<char, string> LetterToMorse = new Dictionary<char, string>()
        {
            {'A' , ".-"},
            {'B' , "-..."},
            {'C' , "-.-."},
            {'D' , "-.."},
            {'E' , "."},
            {'F' , "..-."},
            {'G' , "--."},
            {'H' , "...."},
            {'I' , ".."},
            {'J' , ".---"},
            {'K' , "-.-"},
            {'L' , ".-.."},
            {'M' , "--"},
            {'N' , "-."},
            {'O' , "---"},
            {'P' , ".--."},
            {'Q' , "--.-"},
            {'R' , ".-."},
            {'S' , "..."},
            {'T' , "-"},
            {'U' , "..-"},
            {'V' , "...-"},
            {'W' , ".--"},
            {'X' , "-..-"},
            {'Y' , "-.--"},
            {'Z' , "--.."},
            {'0' , "-----"},
            {'1' , ".----"},
            {'2' , "..---"},
            {'3' , "...--"},
            {'4' , "....-"},
            {'5' , "....."},
            {'6' , "-...."},
            {'7' , "--..."},
            {'8' , "---.."},
            {'9' , "----."},
            {' ', "......." }
        };

        private static readonly Dictionary<string, char> MorseToLetter = LetterToMorse.Keys.ToDictionary(k => LetterToMorse[k], k => k);

        public string Decode(string morseCode)
        {
            if (!string.IsNullOrEmpty(morseCode))
                throw new NotSupportedException();
           
           return string.Join("", morseCode.Split(' ').Select(code => MorseToLetter[code]));
        }
    }
}
