// part1 completely stolen from https://github.com/ChrisPritchard/AdventOfCode/blob/master/2019/Day02.fs  
module Day02
open System.IO

let input = File.ReadAllText (@".\input.txt") |> fun s -> s.Split (',') |> Array.map int
let part1 (noun, verb) =

    let part1Data = Array.copy input
    part1Data.[1] <- noun
    part1Data.[2] <- verb

    let rec processor index =
        let op = part1Data.[index]
        if op = 99 || (op <> 1 && op <> 2) then ()
        else
            let v1 = part1Data.[index + 1]
            let v2 = part1Data.[index + 2]
            let o = part1Data.[index + 3]
            if op = 1 then
                part1Data.[o] <- part1Data.[v1] + part1Data.[v2]
            else
                part1Data.[o] <- part1Data.[v1] * part1Data.[v2]

            processor (index + 4)
    processor 0
    part1Data.[0]    
printf "%A %A" "Part1 = " (part1(12, 2))

let part2() =
    for noun in 0..99 do
        for verb in 0..99 do
            if part1(noun, verb) = 19690720 then
                printf "%A %A %A %A" "\nnoun = " noun "\nverb = " verb
                
part2()




