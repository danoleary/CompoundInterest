module MatcherTests

open System
open Xunit
open Xunit.Abstractions
open CompoundInterestCalculator.Matcher
open CompoundInterestCalculator.Types
open TestHelpers


type SomeTests(output: ITestOutputHelper) =

    [<Fact>]
    member __.``if there is only one lender and they have an available amount greater than the loan amount then the lender name and loan amount are returned`` () =

        let availableLenders = [
                {Name = "Bob";  Rate=0.075; Available=640.0;}
            ]
        let loanAmount = 500.0
        let loanLengthInYears = 10.0
        let result = matchLendersToLoan availableLenders loanAmount loanLengthInYears
        let expectedResult = [
            { Lender = "Bob"; Rate = 0.075; LoanAmount = 500.0; LoanLenthInYears = loanLengthInYears; }
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
        let loanLengthInYears = 10.0
        let result = matchLendersToLoan availableLenders loanAmount loanLengthInYears
        output.WriteLine("Some function returned {0}", result)
        let expectedResult = [
            { Lender = "Bob"; Rate=0.075; LoanAmount = 200.0; LoanLenthInYears = loanLengthInYears };
            { Lender = "Faye"; Rate=0.062; LoanAmount = 100.0; LoanLenthInYears = loanLengthInYears };
            { Lender = "Dan"; Rate=0.050; LoanAmount = 100.0; LoanLenthInYears = loanLengthInYears };
        ]
        Assert.True(listsMatch result expectedResult)




