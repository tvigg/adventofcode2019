part1 :: FilePath -> IO Integer
part1 path = do
  contents <- readFile path
  let someInts = map read  . lines $ contents
  let answer = sum $ map fuel someInts
  return answer

part2 :: FilePath -> IO Integer
part2 path = do
  contents <- readFile path
  let someInts = map read  . lines $ contents
  let answer = sum $ map fuelModule someInts
  return answer

fuel = max 0 . subtract 2 . (`div` 3)

fuelModule :: Integer -> Integer
fuelModule 0 = 0
fuelModule n | n > 0 = fuel n + fuelModule ( (n `div` 3) -2 )
             | otherwise = 0

