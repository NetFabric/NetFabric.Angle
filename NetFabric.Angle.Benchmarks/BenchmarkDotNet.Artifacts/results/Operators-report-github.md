``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i5 CPU M 520 2.40GHz, ProcessorCount=4
Frequency=2337875 Hz, Resolution=427.7389 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2098.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.7.2098.0


```
 |      Method |     Mean |     Error |    StdDev |
 |------------ |---------:|----------:|----------:|
 |         Sin | 39.78 ns | 0.1016 ns | 0.0848 ns |
 |    SinByRef | 38.33 ns | 0.2955 ns | 0.2620 ns |
 |         Add | 13.01 ns | 0.2992 ns | 0.2798 ns |
 |    AddByRef | 12.71 ns | 0.3619 ns | 0.3386 ns |
 | AddOperator | 12.75 ns | 0.1388 ns | 0.1159 ns |
