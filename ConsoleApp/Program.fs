open System
open CompoundInterestService.LoanRequestMarshaller

[<EntryPoint>]
let main argv =

    let loanAmount = float argv.[0]
    let loanLengthInYears = 1.5
    let filePath = argv.[1]
    
    getLoanRequestResponse loanAmount loanLengthInYears filePath |> ignore

    0 
