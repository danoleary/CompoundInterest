module LoanRequestAccepterTests

open System
open Xunit
open CompoundInterestService.Types
open CompoundInterestService.WeightedMeanCalculator

[<Fact>]
let ``correct weighted mean is calculated`` () =
    let loan1 = {LoanAmount = 180.0; Rate = 0.05;MonthlyRepayment = 10.0;TotalRepayment = 180.0;}
    let loan2 = {LoanAmount = 180.0; Rate = 0.1;MonthlyRepayment = 10.0;TotalRepayment = 180.0;}
    let loans = [loan1; loan2]
    let expectedResult = 7.5
    let result = getWeightedMean loans
    Assert.Equal(expectedResult, result)