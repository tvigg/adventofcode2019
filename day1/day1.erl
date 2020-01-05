-module('day1').
-author("tvigg").
-export([part1/0, part2/0, recList/1]).

part1() ->
  {ok, Binary} = file:read_file("input.txt"),
  Txt = [binary_to_integer(Bin) div 3 -2|| 
    Bin <- binary:split(Binary, <<"\n">>,[global]), Bin =/= << >>],
  lists:sum(Txt).


part2() ->
  {ok, Binary} = file:read_file("input.txt"),
  Txt = [lists:sum(recList((binary_to_integer(Bin) div 3) -2))|| 
    Bin <- binary:split(Binary, <<"\n">>,[global]), Bin =/= << >>],
  lists:sum(Txt).

recList(0) -> [0];
recList(N) when N < 0 -> [0];
recList(N) -> recList((N div 3) - 2) ++ [N].


