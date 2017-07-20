namespace CompoundInterestCalculator

module Types =

    type Lender = 
        {
            Name: string
            Rate: float
            Available: float
        }

    type LoanCalculationParams = 
        {
            Lender: string
            LoanAmount: float
            Rate: float
            LoanLenthInYears: float
        }

    type LoanCalculationResponse = 
        {
            LoanAmount: float
            Rate: float
            MonthlyRepayment: float
            TotalRepayment: float
        }