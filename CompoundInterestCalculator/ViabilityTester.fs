namespace CompoundInterestCalculator

module ViabilityTester =

    open Types

    let private loanIsWithinBounds loanAmount =
        loanAmount >= 1000.0 && loanAmount <= 15000.0

    let private loanisWithinAvailableAmount availableAmount loanAmount  =
        loanAmount >= availableAmount

    let private loanIsMultipleOf100 loanAmount =
        loanAmount % 100.0 = 0.0

    let isLoanViable loanAmount (lenders: Lender list) =
        let totalAvailable = lenders |> List.sumBy (fun x -> x.Available) |> float
        loanIsWithinBounds loanAmount && loanisWithinAvailableAmount loanAmount totalAvailable && loanIsMultipleOf100 loanAmount

        
