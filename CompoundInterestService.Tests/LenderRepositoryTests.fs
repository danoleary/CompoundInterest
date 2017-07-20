module LenderRepositoryTests

open System
open Xunit
open CompoundInterestCalculator.LenderRepository
open TestHelpers
open CompoundInterestCalculator.Types

[<Fact>]
let ``given a valid file path then the contents of the csv is returned as a list of lenders`` () =
    let result = getLenders "C:\\Users\\DOLear01\\Documents\\GitHub\\CompoundInterest\\CompoundInterestCalculator\\Market Data for Exercise.csv"
    let expectedResult = [
            {Name = "Bob";  Rate=0.075; Available=640.0;}
            {Name = "Jane";  Rate=0.069; Available=480.0;}
            {Name = "Fred";  Rate=0.071; Available=520.0;}
            {Name = "Mary";  Rate=0.104; Available=170.0;}
            {Name = "John";  Rate=0.081; Available=320.0;}
            {Name = "Dave";  Rate=0.074; Available=140.0;}
            {Name = "Angela";  Rate=0.071; Available=60.0;}
        ]
    Assert.True(listsMatch expectedResult result)