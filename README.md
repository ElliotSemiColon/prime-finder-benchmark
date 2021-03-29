# benchmark by finding primes (requires netcore 3.1)
this is an implementation of the Sieve of Eratosthenes\
it's run as many times as possible in ~5 seconds to test ***per-thread*** performance\
to try this program out, download the repo and run the executable inside its folder **(only run executables from people you trust)**

## making sense of the result
the higher the number of *iterations*, the faster your ***per-thread*** performance\
iterations are reflected by score in points (points are adjusted for the time it took to run the benchmark)

## performance table
some results i've seen to give context
| processor  | # threads | score (points) |
| ------------- | ------------- | ------------- |
| i7-1065G7 | 8 | 789 |
| ryzen 9 3900x | 24 | 767 |
| i5-9600K | 6 | 693 |
| i5-6600 | 4 | 423 |
