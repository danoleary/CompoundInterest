module LoanMatcherTests

open System
open Xunit
open Xunit.Abstractions
open CompoundInterestService.LoanMatcher
open CompoundInterestService.LoanCalculator
open CompoundInterestService.LoanResponder

let listsMatch expected actual =
    let compareLists = List.compareWith Operators.compare
    compareLists actual expected = 0

type SomeTests(output: ITestOutputHelper) =

    [<Fact>]
    member __.``if there is only one lender and they have an available amount greater than the loan amount then the lender name and loan amount are returned`` () =

        let availableLenders = [
                {Name = "Bob";  Rate=0.075; Available=640.0;}
            ]
        let loanAmount = 500.0
        let result = matchLendersToLoan availableLenders loanAmount
        let expectedResult = [
            { Lender = "Bob"; Rate = 0.075; Amount = 500.0 }
        ]
        Assert.True(listsMatch result expectedResult)

    [<Fact>]
    member __.``if there are multiple lenders then the lenders with the lowest rates will be returned`` () =

        let availableLenders = [
                {Name = "Bob";  Rate=0.075; Available=250.0;};
                {Name = "Dan";  Rate=0.050; Available=100.0;};
                {Name = "Faye";  Rate=0.062; Available=100.0;}
            ]
        let loanAmount = 400.0
        let result = matchLendersToLoan availableLenders loanAmount
        output.WriteLine("Some function returned {0}", result)
        let expectedResult = [
            { Lender = "Bob"; Rate=0.075; Amount = 200.0 };
            { Lender = "Faye"; Rate=0.062; Amount = 100.0 };
            { Lender = "Dan"; Rate=0.050; Amount = 100.0 };
        ]
        Assert.True(listsMatch result expectedResult)




