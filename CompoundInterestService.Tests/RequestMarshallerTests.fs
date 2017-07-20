module RequestMarshallerTests

open System
open Xunit
open CompoundInterestCalculator.RequestMarshaller

[<Theory>]
[<InlineData(900, "C:\\Users\\DOLear01\\Documents\\GitHub\\CompoundInterest\\CompoundInterestCalculator\\Market Data for Exercise.csv", "Loan not available")>]
[<InlineData(16000, "C:\\Users\\DOLear01\\Documents\\GitHub\\CompoundInterest\\CompoundInterestCalculator\\Market Data for Exercise.csv", "Loan not available")>]
[<InlineData(1550, "C:\\Users\\DOLear01\\Documents\\GitHub\\CompoundInterest\\CompoundInterestCalculator\\Market Data for Exercise.csv", "Loan not available")>]
[<InlineData(10000, "C:\\Users\\DOLear01\\Documents\\GitHub\\CompoundInterest\\CompoundInterestCalculator\\Market Data for Exercise.csv", "Loan not available")>]
[<InlineData(1000, "C:\\Users\\DOLear01\\Documents\\GitHub\\CompoundInterest\\CompoundInterestCalculator\\Market Data for Exercise.csv", "Requested amount: £1000 \nRate: 7.0% \nMonthly repayment: £61.70 \nTotal repayment: £1110.44" )>]
let ``output is correct`` loanAmount fileName expectedResult =
    let loanLengthInYears = 1.5
    let result = getLoanRequestResponse loanAmount loanLengthInYears fileName
    Assert.Equal(expectedResult, result)