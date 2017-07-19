module LoanCalculatorTests

open System
open Xunit

open CompoundInterestService.LoanCalculator

[<Fact>]
let ``loan calculation is correct`` () =
    let loanAmount = 5000.0
    let rate = 0.05
    let loanParams = 
        {
            LoanAmount = loanAmount;
            Rate = rate;
            LoanLenthInYears = 10.0;
        }
    let result =  calculateLoan loanParams
    let expectedResult = 
        {
            LoanAmount = loanAmount;
            Rate = rate;
            MonthlyRepayment = 68.63;
            TotalRepayment = 8235.05;
        }
    Assert.Equal(expectedResult, result)