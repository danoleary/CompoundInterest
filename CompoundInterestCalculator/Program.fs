open System
open CompoundInterestCalculator.RequestMarshaller

[<EntryPoint>]
let main argv =

    let loanAmount = float argv.[1]
    let loanLengthInYears = 1.5
    let filePath = argv.[0]
    
    printfn "%s" (getLoanRequestResponse loanAmount loanLengthInYears filePath)

    0 
