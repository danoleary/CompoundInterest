open System
open CompoundInterestService.LoanResponder
open CompoundInterestService.LoanMatcher

[<EntryPoint>]
let main argv =

    let loanAmount = 1000.0

    let loanLengthInYears = 1.5

    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=640.0;}
            {Name = "Jane";  Rate=0.069; Available=480.0;}
            {Name = "Fred";  Rate=0.071; Available=520.0;}
            {Name = "Mary";  Rate=0.104; Available=170.0;}
            {Name = "John";  Rate=0.081; Available=320.0;}
            {Name = "Dave";  Rate=0.074; Available=140.0;}
            {Name = "Angela";  Rate=0.071; Available=60.0;}
        ]

    let response = getLoanResponse loanAmount loanLengthInYears availableLenders

    printfn "%A" response
        
    0 // return an integer exit code
