namespace CompoundInterestCalculator

module Matcher =

    open System
    open Types

    let matchLendersToLoan (availableLenders: Lender list) amount loanLengthInYears =
        let orderedLenders = availableLenders |> List.sortBy (fun x -> x.Rate)
        let rec matchLenders amountLeft lenders matchedLoans =
            if amountLeft = 0.0 then
                matchedLoans
            else
                let lender = (List.head lenders)
                let newMatchedLoan = 
                    {
                        Lender = lender.Name;
                        LoanAmount = if amountLeft < lender.Available then amountLeft else lender.Available;
                        Rate = lender.Rate;
                        LoanLenthInYears = loanLengthInYears;
                    }
                let newAmountLeft = amountLeft - newMatchedLoan.LoanAmount
                let remainingLenders = List.filter (fun x -> x.Name <> lender.Name) lenders
                let newMatchedLoans = newMatchedLoan :: matchedLoans
                matchLenders newAmountLeft remainingLenders newMatchedLoans
        matchLenders amount orderedLenders []


