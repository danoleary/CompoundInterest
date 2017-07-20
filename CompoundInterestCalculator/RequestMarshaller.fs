namespace CompoundInterestCalculator

module RequestMarshaller =

    open System
    open Types
    open Calculator
    open Matcher
    open ViabilityTester
    open LenderRepository
    open Combiner

    let getLoanRequestResponse loanAmount loanLengthInYears fileName =

        let availableLenders = getLenders fileName

        let loanIsViable = isLoanViable loanAmount availableLenders 

        if loanIsViable then
            let individualLoanParams = matchLendersToLoan availableLenders loanAmount loanLengthInYears
            let individualLoanTerms = List.map calculateLoan individualLoanParams
            let combinedLoanTerms = combineLoans individualLoanTerms loanAmount
            sprintf "Requested amount: £%.0f \nRate: %.1f%% \nMonthly repayment: £%.2f \nTotal repayment: £%.2f" 
                        combinedLoanTerms.LoanAmount combinedLoanTerms.Rate combinedLoanTerms.MonthlyRepayment combinedLoanTerms.TotalRepayment
        else
            sprintf "Loan not available"




