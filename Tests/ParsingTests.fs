module ParsingTests

open NUnit.Framework
open Parser.Parsing

[<TestFixture>]
type ``When parsing a score`` ()=

    [<Test>]
    member this.``it should parse a simple score`` ()=
        let score = "32.#d3 16-"
        let result = parse score
        let assertFirstToken token =
            Assert.AreEqual({fraction = Thirtyseconth; extended = true}, token.length)
            Assert.AreEqual(Tone (DSharp, Three), token.sound)
        let assertSecondToken {length=length; sound=sound} =
            Assert.AreEqual({fraction = Sixteenth; extended = false}, length)
            Assert.AreEqual(Rest, sound)

        match result with
            | Choice1Of2 errorMsg -> Assert.Fail(errorMsg)
            | Choice2Of2 tokens -> 
                Assert.AreEqual(2, List.length tokens)
                List.head tokens |> assertFirstToken
                List.item 1 tokens |> assertSecondToken
                ()