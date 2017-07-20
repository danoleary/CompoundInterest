namespace CompoundInterestCalculator

module Calculator =

    open System
    open Types

    let calculateLoan (loanParams: LoanCalculationParams) =
        let numberOfMonthsInYear = 12.0
        let ``r/n`` = loanParams.Rate/numberOfMonthsInYear
        let nt = numberOfMonthsInYear*loanParams.LoanLenthInYears
        let totalRepayment = loanParams.LoanAmount * ((1.0 + ``r/n``) ** nt)
        let monthlyRepayment = Math.Round(totalRepayment / (numberOfMonthsInYear * loanParams.LoanLenthInYears), 2)
        let roundedTotalRepayment = Math.Round(totalRepayment, 2)
        {
            LoanAmount = loanParams.LoanAmount;
            Rate = loanParams.Rate;
            MonthlyRepayment = monthlyRepayment;
            TotalRepayment = roundedTotalRepayment;
        }
 