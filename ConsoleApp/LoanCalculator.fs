namespace CompoundInterestService

module LoanCalculator =

    open System

    type LoanCalculationParams = 
        {
            Lender: string;
            LoanAmount: float;
            Rate: float;
            LoanLenthInYears: float;
        }

    type LoanCalculationResponse = 
        {
            LoanAmount: float
            Rate: float
            MonthlyRepayment: float
            TotalRepayment: float
        }

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
    
    let combineLoans loans =
        {
            LoanAmount = loans |> List.sumBy (fun x -> x.LoanAmount);
            Rate = 0.0;
            MonthlyRepayment = loans |> List.sumBy (fun x -> x.MonthlyRepayment);
            TotalRepayment = loans |> List.sumBy (fun x -> x.TotalRepayment);
        }
