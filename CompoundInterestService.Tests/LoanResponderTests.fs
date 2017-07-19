module LoanResponderTests

open System
open Xunit

open CompoundInterestService.LoanResponder
open CompoundInterestService.LoanMatcher

[<Theory>]
[<InlineData(50)>]
[<InlineData(99)>]
[<InlineData(1)>]
[<InlineData(140)>]
[<InlineData(1129)>]
[<InlineData(15001)>]
let ``if the loan amount is not between 100 and 15000 and a multiple of 100 then a failure message is returned `` (loanAmount) =
    let loanLengthInYears = 10.0
    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=640.0;}
            {Name = "Jane";  Rate=0.069; Available=480.0;}
            {Name = "Fred";  Rate=0.071; Available=520.0;}
            {Name = "Mary";  Rate=0.104; Available=170.0;}
            {Name = "John";  Rate=0.081; Available=320.0;}
            {Name = "Dave";  Rate=0.074; Available=140.0;}
            {Name = "Angela";  Rate=0.071; Available=60.0;}
        ]
    let result = getLoanResponse loanAmount loanLengthInYears availableLenders
    let expectedResult = RejectionMessage "No loan available"
    Assert.Equal(expectedResult, result)

[<Theory>]
[<InlineData(50)>]
[<InlineData(99)>]
[<InlineData(1)>]
[<InlineData(140)>]
[<InlineData(14554)>]
[<InlineData(15001)>]
let ``if the loan amount is higher than the total of the lenders amounts then a rejection message is returned `` (loanAmount) =
    let loanLengthInYears = 10.0
    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=640.0;}
            {Name = "Jane";  Rate=0.069; Available=480.0;}
            {Name = "Fred";  Rate=0.071; Available=520.0;}
            {Name = "Mary";  Rate=0.104; Available=170.0;}
            {Name = "John";  Rate=0.081; Available=320.0;}
            {Name = "Dave";  Rate=0.074; Available=140.0;}
            {Name = "Angela";  Rate=0.071; Available=60.0;}
        ]
    let result = getLoanResponse loanAmount loanLengthInYears availableLenders
    let expectedResult = RejectionMessage "No loan available"
    Assert.Equal(expectedResult, result)




