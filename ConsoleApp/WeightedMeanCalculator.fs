namespace CompoundInterestService

module WeightedMeanCalculator =

    open Types

    let getWeightedMean loans =
        let totalLoanAmount = List.sumBy (fun x -> x.LoanAmount) loans
        loans
            |> List.map (fun x -> 
                (x, (x.LoanAmount / totalLoanAmount) * 100.0)
              )
            |> List.map (fun x -> (fst x).Rate * (snd x))
            |> List.sum