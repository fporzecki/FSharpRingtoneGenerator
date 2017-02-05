// Wrapping of sound generator and parses together
// Functions here write to .wav file
namespace Assembly
    module Assembler =

        open Generator.SignalGenerator
        open Parser.Parsing
        open Packer.WavePacker
        open System.IO

        let tokenToSound token = 
            generateSamples (durationFromToken token) (frequency token)

        let assemble tokens =
            List.map tokenToSound tokens |> Seq.concat

        let assembleToPackedStream (score:string) =
            match parse score with
                | Choice1Of2 errorMsg -> Choice1Of2 errorMsg
                | Choice2Of2 tokens -> 
                    assemble tokens 
                        |> Array.ofSeq
                        |> pack 
                        |> Choice2Of2

        let produce (score:string) (filename:string) =
            match assembleToPackedStream score with
                | Choice2Of2 ms -> 
                    use fs = new FileStream(Path.Combine(".", filename), FileMode.Create)
                    ms.WriteTo(fs)
                | Choice1Of2 err -> raise (new System.ArgumentException("We were unable to do things"))