namespace CompoundInterestService

module LoanMatcher =

    open System
    open CompoundInterestService.LoanCalculator

    type Lender = 
        {
            Name: string
            Rate: float
            Available: float
        }

    let matchLendersToLoan (availableLenders: Lender list) amount =
        let orderedLenders = availableLenders |> List.sortBy (fun x -> x.Rate)
        let rec matchLenders amountLeft lenders lenderLoans =
            if amountLeft = 0.0 then
                lenderLoans
            else
                let lender = (List.head lenders)
                let newLenderLoan = 
                    {
                        Lender = lender.Name;
                        LoanAmount = if amountLeft < lender.Available then amountLeft else lender.Available;
                        Rate = lender.Rate;
                        LoanLenthInYears = -1.0;
                    }
                let newAmountLeft = amountLeft - newLenderLoan.LoanAmount
                let remainingLenders = List.filter (fun x -> x.Name <> lender.Name) lenders
                let newLenderLoands = newLenderLoan :: lenderLoans
                matchLenders newAmountLeft remainingLenders newLenderLoands
        matchLenders amount orderedLenders []


