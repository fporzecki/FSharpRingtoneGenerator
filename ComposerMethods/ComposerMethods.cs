using System;
using Microsoft.VisualBasic;
using Microsoft.FSharp.Collections;

namespace ComposerMethods
{
    public static class ComposerMethods
    {
        public static void packSounds(string score, string filename, float bpm)
        {
            if (score == null || score == "")
                throw new ArgumentException("There's no score to produce!");
            if (filename == null || filename == "")
                throw new ArgumentException("There's no filename!");
            if (Strings.Right(filename, 4) != ".wav")
                filename += ".wav";
            
            /*var result = Parser.Parsing.parse(score, bpm);
            if (result.IsChoice2Of2)
                throw new ArgumentException("The score could not be parsed!");*/
            Assembly.Assembler.produce(score, filename, bpm);
        }
    }
}
