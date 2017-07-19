namespace CompoundInterestService

module LoanResponder =

    open CompoundInterestService.LoanCalculator
    open CompoundInterestService.LoanMatcher

    type LoanRequestResponse =
        LoanOffer of LoanCalculationResponse
        | RejectionMessage of string

    let getLoanResponse loanAmount loanLengthInYears (availableLenders: Lender list) =
        let totalAvailable = availableLenders |> List.sumBy (fun x -> x.Available) |> float
        if loanAmount < 100.0 || 
            loanAmount > totalAvailable || 
            loanAmount > 15000.0 ||
            loanAmount % 100.0 <> 0.0
        then
            RejectionMessage "No loan available"
        else
            let lenderLoans = matchLendersToLoan availableLenders loanAmount
            let loans = lenderLoans 
                        |> List.map (fun x -> 
                            let loanParams = 
                                {
                                    Lender = x.Lender
                                    LoanAmount = x.LoanAmount;
                                    Rate = x.Rate;
                                    LoanLenthInYears = loanLengthInYears;
                                }
                            calculateLoan loanParams
                           )
            LoanOffer (combineLoans loans)
                         
