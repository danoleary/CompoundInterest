module ViabilityTesterTests

open System
open Xunit
open CompoundInterestCalculator.Types
open CompoundInterestCalculator.Matcher
open CompoundInterestCalculator.ViabilityTester

[<Theory>]
[<InlineData(50.0)>]
[<InlineData(999.0)>]
[<InlineData(900.0)>]
[<InlineData(100.0)>]
[<InlineData(-1.0)>]
let ``if the loan amount is lower than 1000 then the loan is not viable`` (loanAmount) =
    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=640.0;}
            {Name = "Jane";  Rate=0.069; Available=480.0;}
            {Name = "Fred";  Rate=0.071; Available=520.0;}
            {Name = "Mary";  Rate=0.104; Available=170.0;}
            {Name = "John";  Rate=0.081; Available=320.0;}
            {Name = "Dave";  Rate=0.074; Available=140.0;}
            {Name = "Angela";  Rate=0.071; Available=60.0;}
        ]
    let result = isLoanViable loanAmount availableLenders
    Assert.False(result)

[<Theory>]
[<InlineData(15001.0)>]
[<InlineData(1000000.0)>]
let ``if the loan amount is greater than 15000 then the loan is not viable`` (loanAmount) =
    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=640.0;}
            {Name = "Jane";  Rate=0.069; Available=480.0;}
            {Name = "Fred";  Rate=0.071; Available=520.0;}
            {Name = "Mary";  Rate=0.104; Available=170.0;}
            {Name = "John";  Rate=0.081; Available=320.0;}
            {Name = "Dave";  Rate=0.074; Available=140.0;}
            {Name = "Angela";  Rate=0.071; Available=60.0;}
        ]
    let result = isLoanViable loanAmount availableLenders
    Assert.False(result)

[<Theory>]
[<InlineData(150.0)>]
[<InlineData(1239.0)>]
let ``if the loan amount is not a multiple of 100 then the loan is not viable`` (loanAmount) =
    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=640.0;}
            {Name = "Jane";  Rate=0.069; Available=480.0;}
            {Name = "Fred";  Rate=0.071; Available=520.0;}
            {Name = "Mary";  Rate=0.104; Available=170.0;}
            {Name = "John";  Rate=0.081; Available=320.0;}
            {Name = "Dave";  Rate=0.074; Available=140.0;}
            {Name = "Angela";  Rate=0.071; Available=60.0;}
        ]
    let result = isLoanViable loanAmount availableLenders
    Assert.False(result)


[<Theory>]
[<InlineData(510.0)>]
[<InlineData(1100.0)>]
let ``if the loan amount is higher than the total of the lenders amounts then a rejection message is returned `` (loanAmount) =
    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=100.0;}
            {Name = "Jane";  Rate=0.069; Available=400.0;}
        ]
    let result = isLoanViable loanAmount availableLenders
    Assert.False(result)

[<Theory>]
[<InlineData(1000.0)>]
[<InlineData(2500.0)>]
[<InlineData(1500.0)>]
let ``if the loan amount is equal to or higher than the total of the lenders amounts, equal to or greater than 100, less than or equal to 15000 and a multiple of 100 it is viable `` (loanAmount) =
    let availableLenders = [
            {Name = "Bob";  Rate=0.075; Available=1000.0;}
            {Name = "Jane";  Rate=0.069; Available=1500.0;}
        ]
    let result = isLoanViable loanAmount availableLenders
    Assert.True(result)




