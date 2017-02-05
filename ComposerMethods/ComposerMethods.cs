using System;
using Microsoft.VisualBasic;

namespace ComposerMethods
{
    public static class ComposerMethods
    {
        public static void packSounds(string score, string filename)
        {
            if (score == null || score == "")
                throw new ArgumentException("There's no score to produce!");
            if (filename == null || filename == "")
                throw new ArgumentException("There's no filename!");
            if (Strings.Right(filename, 4) != ".wav")
                filename += ".wav";

            var result = Parser.Parsing.tryIfPossible(Parser.Parsing.pscore, score);
            if(result.IsEmpty)
                throw new ArgumentException("The score could not be parsed!");
            Assembly.Assembler.produce(score, filename);
        }
    }
}
