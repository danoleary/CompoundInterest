namespace CompoundInterestService

module LoanCombiner =

    open System
    open Types
    open WeightedMeanCalculator
    
    let combineLoans loans loanAmount =
        let rate = getWeightedMean loans
        {
            LoanAmount = loanAmount;
            Rate = Math.Round(rate, 1);
            MonthlyRepayment = Math.Round(loans |> List.sumBy (fun x -> x.MonthlyRepayment),2);
            TotalRepayment = Math.Round(loans |> List.sumBy (fun x -> x.TotalRepayment),2);
        }
