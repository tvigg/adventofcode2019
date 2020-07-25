//lots of inspiration from https://github.com/ChrisPritchard/AdventOfCode/blob/master/2019/Day01.fs
module Day01
open System.IO
let input = File.ReadAllLines (@"C:\Users\tvigg\source\repos\adventOfCodeDay1\adventOfCodeDay1\input.txt")
let part1 = input |> Array.sumBy (float >> fun v -> floor (v / 3.) - 2.) |> int


let rec fuel acc x =
    let res =  floor((float x) / 3.) - 2. |> int
    match x with
    | x when res <= 0 -> acc  
    | x -> fuel  (res + acc) res

let part2 = input |> Array.sumBy (int >> fun v -> fuel 0 v)


printfn "%A" part1
printfn "%A" part2
