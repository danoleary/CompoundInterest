namespace CompoundInterestService

module LoanRequestMarshaller =

    open System
    open CompoundInterestService.Types
    open CompoundInterestService.LoanCalculator
    open CompoundInterestService.LoanMatcher
    open CompoundInterestService.LoanViabilityTester
    open CompoundInterestService.LenderRepository
    open CompoundInterestService.LoanCombiner

    let getLoanRequestResponse loanAmount loanLengthInYears fileName =

        let availableLenders = getLenders fileName

        let loanIsViable = isLoanViable loanAmount availableLenders 

        if loanIsViable then
            let individualLoanParams = matchLendersToLoan availableLenders loanAmount loanLengthInYears
            let individualLoanTerms = List.map calculateLoan individualLoanParams
            let combinedLoanTerms = combineLoans individualLoanTerms loanAmount
            sprintf "Requested amount: £%.0f \n Rate: %.1f%% \n Monthly repayment: £%.2f \n Total repayment: £%.2f" 
                        combinedLoanTerms.LoanAmount combinedLoanTerms.Rate combinedLoanTerms.MonthlyRepayment combinedLoanTerms.TotalRepayment
        else
            sprintf "Loan not available"




