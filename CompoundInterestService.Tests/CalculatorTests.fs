module LoanCalculatorTests

open System
open Xunit
open CompoundInterestCalculator.Calculator
open CompoundInterestCalculator.Types

[<Fact>]
let ``loan calculation is correct`` () =
    let loanAmount = 5000.0
    let rate = 0.05
    let loanParams = 
        {
            Lender = "someone";
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