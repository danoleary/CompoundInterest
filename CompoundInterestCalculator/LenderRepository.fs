namespace CompoundInterestCalculator

module LenderRepository =

    open FSharp.Data
    open Types
    
    type Lenders = CsvProvider<"C:\\Users\\DOLear01\\Documents\\GitHub\\CompoundInterest\\CompoundInterestCalculator\\Market Data for Exercise.csv">

    let getLenders (filePath: string) =
        let lendersFile = Lenders.Load filePath
        lendersFile.Rows 
        |> Seq.map (fun x-> {Name = x.Lender;  Rate=float x.Rate; Available= float x.Available;})
        |> List.ofSeq
