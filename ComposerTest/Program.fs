open System
open System.IO

[<EntryPoint>]
let main argv = 
    let score = "8e1 4g1 4b1 4g2 4e2 4- 4e2 8#f2 4e2 4d2 4- 8d2 4- 8e1 4g1 4b1 4g2 4e2 4- 4e2 8#f2 4e2 4d2"
    let produce (score:string) (filename:string) =
        match Assembly.Assembler.assembleToPackedStream score with
            | Choice2Of2 ms -> 
                use fs = new FileStream(Path.Combine(__SOURCE_DIRECTORY__, filename), FileMode.Create)
                ms.WriteTo(fs)
            | Choice1Of2 err -> failwith err
    produce score "dzwon.wav"
    0 // return an integer exit code
