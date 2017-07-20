module TestHelpers

let listsMatch expected actual =
    let compareLists = List.compareWith Operators.compare
    compareLists actual expected = 0