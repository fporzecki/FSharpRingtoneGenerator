open System
open System.IO

[<EntryPoint>]
let main argv = 
    let score = "tjsgjsgj"
    let produce (score:string) (filename:string) =
        match Assembly.Assembler.assembleToPackedStream score with
            | Choice2Of2 ms -> 
                use fs = new FileStream(Path.Combine(__SOURCE_DIRECTORY__, filename), FileMode.Create)
                ms.WriteTo(fs)
            | Choice1Of2 err -> raise (new System.ArgumentException("We were unable to do things"))
    produce score "dzwon.wav"
    0 // return an integer exit code
