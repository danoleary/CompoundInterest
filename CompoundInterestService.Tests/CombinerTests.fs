module CombinerTests

open System
open Xunit
open TestHelpers
open CompoundInterestCalculator.Types
open CompoundInterestCalculator.Combiner

[<Fact>]
let ``loans are combined correctly`` () =
    let loan1 = {LoanAmount = 180.0; Rate = 0.05;MonthlyRepayment = 10.0;TotalRepayment = 180.0;}
    let loan2 = {LoanAmount = 180.0; Rate = 0.1;MonthlyRepayment = 10.0;TotalRepayment = 180.0;}
    let loans = [loan1; loan2]
    let expectedResult = {LoanAmount = 180.0; Rate = 7.5;MonthlyRepayment = 20.0;TotalRepayment = 360.0;}
    let result = combineLoans loans 180.0
    Assert.Equal(expectedResult, result)